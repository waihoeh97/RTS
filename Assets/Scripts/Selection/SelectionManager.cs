using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseNPC
{
	void MoveUnit(Vector2 targetPos);
}

public class CompositeGroup : IBaseNPC
{
	public List<IBaseNPC> npcGroup = new List<IBaseNPC>();
	public void MoveUnit(Vector2 targetPos)
	{
		for (int i = 0; i < npcGroup.Count; i++)
		{
			npcGroup[i].MoveUnit(targetPos);
		}
	}

	public void AddUnit (IBaseNPC npc)
	{
		npcGroup.Add(npc);
	}

	public void RemoveUnit (IBaseNPC npc)
	{
		npcGroup.Remove(npc);
	}

	public void ResetGroup()
	{
		npcGroup.Clear();
	}
}

public class SelectionManager : MonoBehaviour 
{
	private static SelectionManager _instance;
	public static SelectionManager Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject obj = GameObject.FindGameObjectWithTag("SelectionManager");
				if (obj != null)
				{
					_instance = obj.GetComponent<SelectionManager>();
				}
				else
				{
					obj = new GameObject();
					obj.name = "_SelectionManager";
					obj.tag = ("SelectionManager");
					obj.GetComponent<SelectionManager>();
					_instance = obj.GetComponent<SelectionManager>();
				}
			}
			return _instance;
		}
	}

	public IBaseNPC controlUnit;

	// Use this for initialization
	void Start () 
	{

	}

	public void CreateGroup(List<IBaseNPC> selectedGroup)
	{
		if (selectedGroup.Count == 1)
		{
			controlUnit = selectedGroup[0];
		}
		else if (selectedGroup.Count > 1)
		{
			CompositeGroup tempGroup = new CompositeGroup();
			for (int i = 0; i < selectedGroup.Count; i++)
			{
				tempGroup.AddUnit(selectedGroup[i]);
			}
			controlUnit = tempGroup;
		}
		else if (selectedGroup.Count == 0)
		{
			CompositeGroup tempGroup = new CompositeGroup();
			tempGroup.ResetGroup();
			controlUnit = tempGroup;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(2))
		{
			Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (controlUnit != null)
			{
				controlUnit.MoveUnit(targetPos);
			}
		}
	}
}

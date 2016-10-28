using UnityEngine;
using System.Collections.Generic;
using System;


public class PoolController : MonoBehaviour
{
	public static PoolController Instance { get; private set; }

	[Serializable]
	private class PoolItemData
	{
		public GameObject prefab;
		public int count;
	}

	[SerializeField]
	private PoolItemData[] items;

	private Dictionary<string, Stack<GameObject>> instancesDict;


	private void OnEnable()
	{
		Instance = this;
		instancesDict = new Dictionary<string, Stack<GameObject>> ();
		GenerateItemInstances ();
	}

	private void OnDisable()
	{
		ClearItemInstances ();
		Instance = null;
		instancesDict = null;
	}

	private void GenerateItemInstances()
	{
		foreach (var item in items)
		{
			Stack<GameObject> instancesStack = new Stack<GameObject> ();

			for (int i = 0; i < item.count; i++)
			{
				instancesStack.Push (CreateItemInstance (item.prefab));
			}

			instancesDict.Add (item.prefab.name, instancesStack);
		}
	}

	private void ClearItemInstances()
	{
		foreach (var key in instancesDict.Keys)
		{
			foreach (var item in instancesDict[key])
				Destroy (item);

			instancesDict [key].Clear ();
		}

		instancesDict.Clear ();
	}

	private GameObject CreateItemInstance(GameObject item)
	{
		GameObject go = Instantiate<GameObject> (item);

		go.transform.SetParent (this.transform);
		go.transform.localPosition = Vector3.zero;
		go.transform.localEulerAngles = Vector3.one;
		go.SetActive (false);
		go.name = item.name;

		return go;
	}

	public GameObject Get(GameObject item)
	{
		if (instancesDict.ContainsKey(item.name))
		{
			if (instancesDict [item.name].Count > 0)
				return instancesDict [item.name].Pop ();
			else
				return CreateItemInstance (item);
		}

		return null;
	}

	public void Retrieve(GameObject instance)
	{
		if (instancesDict.ContainsKey(instance.name))
		{
			instancesDict [instance.name].Push (instance);
			instance.transform.SetParent (this.transform);
			instance.SetActive (false);
		}
	}
}


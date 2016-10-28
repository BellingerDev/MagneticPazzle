using UnityEngine;
using System;


[Serializable]
public class GameConditionElementsCount : GameConditionBase
{
	[SerializeField]
	private int countToWin;

	public override bool Check (object data)
	{
		return true;
	}
}


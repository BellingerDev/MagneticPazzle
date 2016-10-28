using UnityEngine;


public abstract class GameConditionBase : MonoBehaviour
{
	[SerializeField]
	private GameRewardBase[] rewards;

	public abstract bool Check(object data);

	public virtual void DispatchRewards()
	{
		foreach (var r in rewards)
			r.Dispatch ();
	}
}


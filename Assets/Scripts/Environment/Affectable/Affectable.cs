using UnityEngine;


public abstract class Affectable : MonoBehaviour
{
    public enum State
    {
        Activated, Deactivated
    }

	[SerializeField]
	private bool isActivateOnEnable = false;

    public State CurrentState { get; private set; }


    protected virtual void Awake()
    {
        CurrentState = State.Deactivated;
    }

	protected virtual void OnEnable()
	{
		if (isActivateOnEnable)
			Activate ();
	}

    public virtual void Activate()
    {
        CurrentState = State.Activated;
    }

    public virtual void Deactivate()
    {
        CurrentState = State.Deactivated;
    }
}

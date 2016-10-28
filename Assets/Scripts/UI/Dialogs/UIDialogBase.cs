using UnityEngine;


public abstract class UIDialogBase : MonoBehaviour 
{
	[SerializeField]
	private float showTime = 0;

	[SerializeField]
	private bool hideOnAwake = true;

	public bool Active { get; private set; }
    
	private float hideTime = 0;


	protected virtual void Awake()
	{
		if (hideOnAwake)
			Disable ();
		else
			Enable ();
	}

	protected virtual void OnEnable()
	{
		
	}

	protected virtual void OnDisable()
	{
		
	}

	private void Enable()
	{
        this.gameObject.SetActive(true);
	}

	private void Disable()
	{
        this.gameObject.SetActive(false);
    }

	protected virtual void Update()
	{
		if (Active)
			if (showTime > 0)
				if (Time.time > hideTime)
					Hide ();
	}

	public virtual void Show()
	{
		Active = true;
		hideTime = Time.time + showTime;

		Enable ();
	}

	public virtual void Hide()
	{
		Active = false;
		Disable ();
	}
}

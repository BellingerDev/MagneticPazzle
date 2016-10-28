using Player;
using UnityEngine;
using Utils;


public class PortalController : MonoBehaviour 
{/*
	[SerializeField]
	private PortalController other;

	public ColliderTriggerController ColliderTrigger { get; set; }

    private bool isReceive = false;
    private bool isObtain = false;

	private void OnEnable()
	{
		ColliderTrigger = GetComponentInChildren<ColliderTriggerController> ();
		ColliderTrigger.OnTriggerEnterCallback += OnEnter;
	}

	private void OnDisable()
	{
		ColliderTrigger.OnTriggerEnterCallback -= OnEnter;
		ColliderTrigger = null;
	}

	private void OnEnter(Collider col)
	{
        Portable item = null;
        if (col.tag == Player.PlayerController.PlayerTag || col.tag == ElementController.ElementTag)
        {
            item = col.GetComponent<Portable>();
            if (item == null)
                item = col.GetComponentInParent<Portable>();
        }

        if (item.CurrentState == Affectable.State.Activated)
        {
            item.Deactivate();
        }
        else
        {
            if (item.CurrentState == Affectable.State.Deactivated)
            {
                item.Activate();
                item.transform.position = other.transform.position;
            }
        }

    }*/
}

using UnityEngine;
using System;


public abstract class UIMenuBase : MonoBehaviour
{
	public virtual void Show ()
	{
        this.gameObject.SetActive(true);
	}

	public virtual void Hide ()
    {
        this.gameObject.SetActive(false);
    }
}


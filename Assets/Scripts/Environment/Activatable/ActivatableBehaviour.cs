using System;
using System.Collections.Generic;
using UnityEngine;


namespace Environment
{
    public class ActivatableBehaviour : MonoBehaviour
    {
        [Serializable]
        protected struct ActivatableData
        {
            public GameObject[] listeners;
            public bool isActivateCallback;
            public bool isDeactivateCallback;
        }

        [SerializeField]
        protected ActivatableData data;

        private List<IActivatable> currentListeners;


        protected virtual void OnEnable()
        {
            currentListeners = new List<IActivatable>();

            foreach (var l in data.listeners)
                currentListeners.Add(l.GetComponent(typeof(IActivatable)) as IActivatable);
        }

        protected virtual void OnDisable()
        {
            currentListeners.Clear();
            currentListeners = null;
        }

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            if (data.listeners != null)
                foreach (var l in data.listeners)
                    Gizmos.DrawLine(transform.position, l.transform.position);
        }

        protected void Activate()
        {
            if (data.isActivateCallback)
                foreach (var l in currentListeners)
                    l.Activate();
        }

        protected void Deactivate()
        {
            if (data.isDeactivateCallback)
                foreach (var l in currentListeners)
                    l.Deactivate();
        }
    }
}
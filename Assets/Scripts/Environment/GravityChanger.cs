using UnityEngine;
using System;


namespace Environment
{
    public class GravityChangeController : MonoBehaviour, IActivatable
    {
        public enum State
        {
            Positive, Negative
        }

        public static Action<State> OnGravityChanged;

        [SerializeField]
        private State state;

        private Vector3 gravity;

        private void Awake()
        {
            gravity = Physics.gravity;
        }

        #region Activatable

        public void Activate()
        {
            if (state == State.Positive)
                Physics.gravity = gravity * 1;
            else
                Physics.gravity = gravity * -1;

            if (OnGravityChanged != null)
                OnGravityChanged(state);
        }

        public void Deactivate()
        {

        }

        #endregion
    }
}


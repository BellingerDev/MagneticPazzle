using System;
using UnityEngine;


namespace Environment
{
    public class GateController : MonoBehaviour, IActivatable
    {
        private enum State
        {
            Opened, Closed
        }

        [Serializable]
        private struct FlapData
        {
            public GameObject flap;

            public Vector3 openedPosition;
            public Vector3 closedPosition;

            public LeanTweenType openTween;
            public LeanTweenType closeTween;

            public float openTime;
            public float closeTime;
        }

        [SerializeField]
        private FlapData[] flaps;

        [SerializeField]
        private State state;

        private bool isBusy;


        public void Open()
        {
            if (isBusy)
                return;

            isBusy = true;
            foreach (var fd in flaps)
            {
                fd.flap.transform.localPosition = fd.closedPosition;
                LeanTween.moveLocal(fd.flap, fd.openedPosition, fd.openTime)
                    .setEase(fd.openTween)
                    .setOnComplete(OnOpenCallback);
            }
        }

        private void OnOpenCallback()
        {
            isBusy = false;
        }

        public void ForceOpen()
        {
            foreach (var fd in flaps)
            {
                fd.flap.transform.localPosition = fd.openedPosition;
            }
        }

        public void Close()
        {
            if (isBusy)
                return;

            isBusy = true;
            foreach (var fd in flaps)
            {
                fd.flap.transform.localPosition = fd.openedPosition;
                LeanTween.moveLocal(fd.flap, fd.closedPosition, fd.closeTime)
                    .setEase(fd.closeTween)
                    .setOnComplete(OnCloseCallback);
            }
        }

        private void OnCloseCallback()
        {
            isBusy = false;
        }

        public void ForceClose()
        {
            foreach (var fd in flaps)
            {
                fd.flap.transform.localPosition = fd.closedPosition;
            }
        }

        private void OnEnable()
        {
            isBusy = false;

            switch (state)
            {
                case State.Opened:
                    ForceOpen();
                    break;

                case State.Closed:
                    ForceClose();
                    break;
            }
        }

        private void OnDrawGizmos()
        {
            if (flaps != null)
            {
                foreach (var fd in flaps)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireSphere(this.transform.TransformPoint(fd.openedPosition), 0.5f);

                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(this.transform.TransformPoint(fd.closedPosition), 0.5f);

                    Gizmos.color = Color.white;
                    Gizmos.DrawLine(this.transform.TransformPoint(fd.openedPosition), this.transform.TransformPoint(fd.closedPosition));
                }
            }
        }

        #region Activatable

        public void Activate()
        {
            Open();
        }

        public void Deactivate()
        {
            Close();
        }

        #endregion
    }
}

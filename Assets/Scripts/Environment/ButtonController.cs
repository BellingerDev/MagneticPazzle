using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Environment
{
	public class ButtonController : ActivatableBehaviour 
	{
        [SerializeField]
        public string[] filteredTags;

        [SerializeField]
        private GameObject buttonTop;

        [SerializeField]
        private Vector3 pressedPosition;

        [SerializeField]
        private Vector3 releasedPosition;

        [SerializeField]
        private LeanTweenType pressTween;

        [SerializeField]
        private LeanTweenType releaseTween;

        [SerializeField]
        private float pressTime;

        [SerializeField]
        private float releaseTime;

        private List<Collider> colliders;
        private bool isBusy;
        private bool isPressed;


        #region Activation Logic

        public void Press()
        {
            if (isPressed)
                return;

            isPressed = true;
            buttonTop.transform.localPosition = releasedPosition;
            LeanTween.moveLocal(buttonTop, pressedPosition, pressTime)
                .setEase(pressTween)
                .setOnComplete(Activate);
        }

        public void Release()
        {
            if (!isPressed)
                return;

            isPressed = false;
            buttonTop.transform.localPosition = pressedPosition;
            LeanTween.moveLocal(buttonTop, releasedPosition, releaseTime)
                .setEase(releaseTween)
                .setOnComplete(Deactivate);
        }

        #endregion

        #region Unity Events

        protected override void OnEnable()
        {
            isBusy = false;
            isPressed = false;
            colliders = new List<Collider>();

            base.OnEnable();
        }

        protected override void OnDisable()
        {
            colliders.Clear();
            colliders = null;

            base.OnDisable();
        }

        private void OnTriggerEnter(Collider col)
        {
            if (filteredTags.Contains(col.tag))
                if (!colliders.Contains(col))
                    colliders.Add(col);
        }

        private void OnTriggerExit(Collider col)
        {
            if (filteredTags.Contains(col.tag))
                if (colliders.Contains(col))
                    colliders.Remove(col);
        }

        private void Update()
        {
            if (colliders.Count > 0)
            {
                if (!isBusy && data.isActivateCallback)
                {
                    isBusy = true;
                    Press();
                }
            }
            else
            {
                if (isBusy && data.isDeactivateCallback)
                {
                    isBusy = false;
                    Release();
                }
            }
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(this.transform.TransformPoint(pressedPosition), 0.5f);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.TransformPoint(releasedPosition), 0.5f);

            Gizmos.color = Color.white;
            Gizmos.DrawLine(this.transform.TransformPoint(pressedPosition), this.transform.TransformPoint(releasedPosition));
        }

        #endregion
    }
}
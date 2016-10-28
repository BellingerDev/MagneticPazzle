using UnityEngine;
using System.Collections.Generic;


namespace Environment
{
    public class PressablePlatformController : MonoBehaviour
    {
        [SerializeField]
        private string playerTag;

        [SerializeField]
        private string elementTag;

        [SerializeField]
        private GameObject platform;

        [SerializeField]
        private Vector3 pressedPoint;

        [SerializeField]
        private Vector3 releasedPoint;

        [SerializeField]
        private LeanTweenType pressTween;

        [SerializeField]
        private LeanTweenType releaseTween;

        [SerializeField]
        private float pressTime;

        [SerializeField]
        private float releaseTime;

        [SerializeField]
        private float activationDelay;

        [SerializeField]
        private int maxElementsWeight;

        [SerializeField]
        private TextMesh weightIndicator;

        [SerializeField]
        private string weightIndicatorFormat;

        private List<Collider> collectedElements;
        private bool isPlayerDetected;
        private bool isBusy;


        private void OnEnable()
        {
            collectedElements = new List<Collider>();
            isPlayerDetected = false;
            isBusy = false;
            ForceRelease();
        }

        private void OnDisable()
        {
            collectedElements.Clear();
            collectedElements = null;
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.tag == elementTag)
                if (!collectedElements.Contains(col))
                    collectedElements.Add(col);

            if (col.tag == playerTag)
                isPlayerDetected = true;
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.tag == elementTag)
                if (collectedElements.Contains(col))
                    collectedElements.Remove(col);

            if (col.tag == playerTag)
                isPlayerDetected = false;
        }

        private void Update()
        {
            if (maxElementsWeight != -1)
            {
                weightIndicator.text = string.Format(weightIndicatorFormat, collectedElements.Count, maxElementsWeight);
                if (isPlayerDetected)
                {
                    if (collectedElements.Count > maxElementsWeight)
                        Press();
                }
                else
                    Release();
            }
            else
            {
                weightIndicator.text = string.Format(weightIndicatorFormat, collectedElements.Count + (isPlayerDetected ? 1 : 0));
                if (isPlayerDetected || collectedElements.Count > 0)
                    Press();
                else
                    Release();
            }
        }

        private void Press()
        {
            if (isBusy)
                return;

            isBusy = true;
            LeanTween.cancel(platform);
            LeanTween.move(platform, this.transform.TransformPoint(pressedPoint), pressTime)
                .setEase(pressTween)
                .setOnComplete(delegate () { isBusy = false; });
        }

        private void ForcePress()
        {
            platform.transform.position = this.transform.TransformPoint(pressedPoint);
        }

        private void Release()
        {
            if (isBusy)
                return;

            isBusy = true;
            LeanTween.cancel(platform);
            LeanTween.move(platform, this.transform.TransformPoint(releasedPoint), releaseTime)
                .setEase(releaseTween)
                .setOnComplete(delegate () { isBusy = false; });
        }

        private void ForceRelease()
        {
            platform.transform.position = this.transform.TransformPoint(releasedPoint);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.TransformPoint(pressedPoint), 0.5f);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(this.transform.TransformPoint(releasedPoint), 0.5f);

            Gizmos.color = Color.white;
            Gizmos.DrawLine(this.transform.TransformPoint(pressedPoint), this.transform.TransformPoint(releasedPoint));
        }
    }
}
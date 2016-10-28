using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Environment
{
    public class ActivatableAreaController : ActivatableBehaviour, IIndicatable
    {
        [SerializeField]
        private string playerTag;

        [SerializeField]
        private string[] filteredTags;

        [SerializeField]
        private int elementsToActivate;

        private List<Collider> collectedElements;
        private bool isPlayerDetected;


        public int ElementsCount
        {
            get
            {
                return collectedElements.Count;
            }
        }

        protected override void OnEnable()
        {
            collectedElements = new List<Collider>();
            isPlayerDetected = false;

            base.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            collectedElements.Clear();
            collectedElements = null;
        }

        private void OnTriggerEnter(Collider col)
        {
            if (filteredTags.Contains(col.tag))
                if (!collectedElements.Contains(col))
                    collectedElements.Add(col);

            if (col.tag == playerTag)
                isPlayerDetected = true;
        }

        private void OnTriggerExit(Collider col)
        {
            if (filteredTags.Contains(col.tag))
                if (collectedElements.Contains(col))
                    collectedElements.Remove(col);

            if (col.tag == playerTag)
                isPlayerDetected = false;
        }

        private void Update()
        {
            if (collectedElements.Count > 0 && isPlayerDetected)
            {
                Activate();
            }

            if (collectedElements.Count == 0 && isPlayerDetected)
                Deactivate();

            if (collectedElements.Count == -1)
            {
                if (isPlayerDetected)
                    Activate();
                else
                    Deactivate();
            }
        }
    }
}

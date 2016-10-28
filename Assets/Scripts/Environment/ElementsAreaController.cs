using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Player;

namespace Environment
{
    public class ElementsAreaController : MonoBehaviour
    {
        [SerializeField]
        private string playerTag;

        [SerializeField]
        private string[] filteredTags;

        [SerializeField]
        private int elementsToPass;

        private List<Collider> collectedElements;
        private bool isPlayerDetected;

        private void OnEnable()
        {
            collectedElements = new List<Collider>();
        }

        private void OnDisable()
        {
            isPlayerDetected = false;
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
            //foreach (var e in collectedElements)


            if (isPlayerDetected)
            {
                if (collectedElements.Count < elementsToPass)
                {
                    foreach (var e in collectedElements)
                    {
                        Affectable elementAffectable = e.GetComponent<ElementsAreaAffectable>();
                        if (elementAffectable != null)
                            elementAffectable.Activate();
                    }

                    collectedElements.Clear();

                    Affectable playerAffectable = PlayerController.Instance.GetComponent<ElementsAreaAffectable>();
                    if (playerAffectable != null)
                        playerAffectable.Activate();

                    if (PlayerController.OnPlayerDied != null)
                        PlayerController.OnPlayerDied();
                }
            }
        }
    }
}

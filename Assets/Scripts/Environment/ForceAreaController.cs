using System.Linq;
using UnityEngine;


namespace Environment
{
    public class ForceAreaController : MonoBehaviour
    {
        [SerializeField]
        private string[] filteredTags;

        [SerializeField]
        private Vector3 direction;

        [SerializeField]
        private float force;


        private void OnTriggerStay(Collider col)
        {
            if (filteredTags.Contains(col.tag))
            {
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.velocity = direction * force;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().bounds.size);
            Gizmos.DrawLine(transform.position, direction * force);
        }
    }
}

using UnityEngine;


public class MagneticAreaController : MonoBehaviour
{
    [SerializeField]
    private Vector3 force;

    [SerializeField]
    private string tag;


    private void OnTriggerStay(Collider col)
    {
        if (col.tag == tag)
        {
            Rigidbody rb = col.GetComponentInParent<Rigidbody>();
            rb.velocity = force;
        }
    }
}

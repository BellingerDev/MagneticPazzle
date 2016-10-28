using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class FracturedPartController : MonoBehaviour
{
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == Player.PlayerController.PlayerTag)
            rb.isKinematic = false;
    }
}

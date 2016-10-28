using UnityEngine;


public class GizmoSphere : MonoBehaviour
{
    private float radius = 0.5f;
    private Color color = Color.red;


    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}

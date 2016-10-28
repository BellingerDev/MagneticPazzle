using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LineController : MonoBehaviour
{
    [SerializeField]
    private string[] tags;

    private LineRenderer line;
    private List<Collider> colliders;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        colliders = new List<Collider>();
    }

    private void Update()
    {
        for (int i = 0; i < colliders.Count; i++)
            line.SetPosition(i, colliders[i].transform.position);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (tags.Contains(col.tag))
        {
            colliders.Add(col);
            line.SetVertexCount(colliders.Count);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (tags.Contains(col.tag))
        {
            colliders.Remove(col);
            line.SetVertexCount(colliders.Count);
        }
    }
}

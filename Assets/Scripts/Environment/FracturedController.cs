using UnityEngine;


public class FracturedController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] originObjects;

    [SerializeField]
    private Rigidbody[] fracturedParts;


    private void Awake()
    {
        SetActiveFracturedParts(true);
        SetActiveOriginObjects(false);
    }

    private void SetActiveOriginObjects(bool state)
    {
        foreach (var o in originObjects)
            if (o.activeSelf != state)
                o.SetActive(state);
    }

    private void SetActiveFracturedParts(bool state)
    {
        foreach (var f in fracturedParts)
            if (f.gameObject.activeSelf != state)
                f.gameObject.SetActive(state);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == Player.PlayerController.PlayerTag)
        {
            SetActiveFracturedParts(true);
            SetActiveOriginObjects(false);
        }
    }
}

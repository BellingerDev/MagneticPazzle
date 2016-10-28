using UnityEngine;


public class AI_PlayerPoolRetrieveArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PlayerBall")
        {
            GameObject instance = col.transform.parent.gameObject;
            instance.SetActive(false);
            PoolController.Instance.Retrieve(instance);
        }
    }
}

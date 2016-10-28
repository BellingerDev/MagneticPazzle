using System.Linq;
using UnityEngine;


namespace Utils.Poolable
{
    public class PoolableRetrieveArea : MonoBehaviour
    {
        [SerializeField]
        private string[] tags;


        private void OnTriggerEnter(Collider col)
        {
            if (tags.Contains(col.tag))
            {
				PoolController.Instance.Retrieve (col.gameObject);
            }
        }
    }
}
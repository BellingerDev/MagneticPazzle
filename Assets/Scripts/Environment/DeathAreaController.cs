using Player;
using UnityEngine;


namespace Environment
{
    [RequireComponent(typeof(Collider))]
    public class DeathAreaController : MonoBehaviour
    {
        [SerializeField]
        private string playerTag;

        [SerializeField]
        private string AffectableTypeName;


        private void OnTriggerEnter(Collider col)
        {
            if (playerTag == col.tag)
            {
                Affectable a = GetComponent(AffectableTypeName) as Affectable;
                if (a == null)
                    a = col.transform.parent.GetComponent(AffectableTypeName) as Affectable;

                if (a != null)
                    a.Activate();

                if (PlayerController.OnPlayerDied != null)
                    PlayerController.OnPlayerDied();
            }
        }
    }
}

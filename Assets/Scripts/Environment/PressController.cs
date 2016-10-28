using UnityEngine;


namespace Environment
{
    public class PressController : MonoBehaviour, IActivatable
    {
        [SerializeField]
        private GameObject massObject;

        [SerializeField]
        private LeanTweenType pushTween;

        [SerializeField]
        private LeanTweenType popTween;

        [SerializeField]
        private float pushTime;

        [SerializeField]
        private float popTime;

        [SerializeField]
        private Vector3 startPos;

        [SerializeField]
        private Vector3 endPos;


        #region Unity Events

        private void OnEnable()
        {
            Push();
        }

        private void OnDisable()
        {

        }

        #endregion

        private void Push()
        {
            massObject.transform.position = this.transform.TransformPoint(startPos);
            LeanTween.move(massObject, this.transform.TransformPoint(endPos), pushTime)
                .setEase(pushTween)
                .setOnComplete(OnPushComplete);
        }

        private void Pop()
        {
            massObject.transform.position = this.transform.TransformPoint(endPos);
            LeanTween.move(massObject, this.transform.TransformPoint(startPos), popTime)
                .setEase(popTween)
                .setOnComplete(OnPopComplete);
        }

        private void OnPushComplete()
        {
            Pop();
        }

        private void OnPopComplete()
        {
            Push();
        }

        public void Activate()
        {
            Push();
        }

        public void Deactivate()
        {

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.TransformPoint(startPos), 0.5f);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(this.transform.TransformPoint(endPos), 0.5f);

            Gizmos.color = Color.white;
            Gizmos.DrawLine(this.transform.TransformPoint(startPos), this.transform.TransformPoint(endPos));
        }
    }
}


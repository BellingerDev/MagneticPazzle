using UnityEngine;


namespace Environment
{
    public class LiftController : MonoBehaviour, IActivatable
    {
        private enum Direction
        {
            Up,
            Down
        }

        [SerializeField]
        private string[] filteredTags;

        [SerializeField]
        private GameObject platform;

        [SerializeField]
        private Vector3 topPoint;

        [SerializeField]
        private Vector3 bottomPoint;

        [SerializeField]
        private LeanTweenType upTween;

        [SerializeField]
        private LeanTweenType downTween;

        [SerializeField]
        private float upTime;

        [SerializeField]
        private float downTime;

        [SerializeField]
        private Direction direction;

        private bool isBusy;


        private void OnEnable()
        {
            isBusy = false;
            ForceLift(direction);
        }

        private void Lift(Direction dir)
        {
            if (isBusy)
                return;

            isBusy = true;
            LeanTween.cancel(platform);
            LeanTween.move(platform,
                this.transform.TransformPoint(dir == Direction.Up ? topPoint : bottomPoint), 
                dir == Direction.Up ? upTime : downTime)
                .setEase(dir == Direction.Up ? upTween : downTween)
                .setOnComplete(delegate(){ isBusy = false; });
        }

        private void ForceLift(Direction dir)
        {
            platform.transform.position = this.transform.TransformPoint(dir == Direction.Up ? topPoint : bottomPoint);
        }

        public void Activate()
        {
            Debug.Log("Activate Lift Top");
            Lift(Direction.Up);
        }

        public void Deactivate()
        {
            Debug.Log("Activate Lift Bottom");
            Lift(Direction.Down);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(this.transform.TransformPoint(topPoint), 0.5f);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.TransformPoint(bottomPoint), 0.5f);

            Gizmos.color = Color.white;
            Gizmos.DrawLine(this.transform.TransformPoint(topPoint), this.transform.TransformPoint(bottomPoint));
        }
    }
}

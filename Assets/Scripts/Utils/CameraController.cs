using Environment;
using Player;
using UnityEngine;
using Utils.CameraControllers;


public class CameraController : MonoBehaviour
{
	public static CameraController Instance  { get; private set; }

	[SerializeField]
	private LeanTweenType rotateEase;

	[SerializeField]
	private float rotateTime;

	[SerializeField]
	private LeanTweenType moveEase;

	[SerializeField]
	private float moveTime;

	private bool isRotating = false;
	private bool isMove = false;

	private FollowTarget follower;

	public GameObject Target
	{
		get { return follower.Target; }
		set { follower.Target = value; }
	}

	public bool IsFollowTarget { get; set; }


	private void OnEnable()
	{
		Instance = this;
		follower = GetComponent<FollowTarget> ();
        GravityChangeController.OnGravityChanged += OnGravityChanged;
	}

	private void OnDisable()
	{
        GravityChangeController.OnGravityChanged -= OnGravityChanged;
		follower = null;
		Instance = null;
	}

    private void Update()
    {
		if (IsFollowTarget)
		{
			if (follower.Target == null)
			{
				PlayerController controller = GameObject.FindObjectOfType<PlayerController>();
				if (controller != null)
					follower.Target = controller.gameObject;
			}
		}
    }

	private void OnGravityChanged(GravityChangeController.State state)
	{
		if (!isRotating)
		{
			follower.OffsetY = -follower.OffsetY;
			Rotate (transform.rotation.z + 180);
		}
	}

	private void Rotate(float angle)
	{
		isRotating = true;

		LeanTween.rotateZ (this.gameObject, angle, rotateTime)
			.setEase (rotateEase)
			.setOnComplete (x => { isRotating = false; });
	}

	private void Move(Vector3 target)
	{
		isMove = true;

		LeanTween.move (this.gameObject, target, moveTime)
			.setEase (moveEase)
			.setOnComplete (x => {
			isMove = false;
		});
	}
}


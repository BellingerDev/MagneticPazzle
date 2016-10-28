using UnityEngine;


public abstract class GameMechanicsBase : MonoBehaviour
{
	[SerializeField]
	private Camera mainCamera;

	[SerializeField]
	private Vector3 cameraStartPosition;

	[SerializeField]
	private float cameraTweenDuration;

	[SerializeField]
	private LeanTweenType cameraTween;

	[SerializeField]
	private bool isCameraFollowTarget;

	//private vars
	private CameraController mainCameraController;

	protected CheckpointController[] Checkpoints { get; set; }

	// camera data
	protected Camera MainCamera { get { return mainCamera; } }
	protected CameraController MainCameraController { get { return mainCameraController; } }

	// methods
	public virtual void OnStart()
	{
		mainCameraController = mainCamera.GetComponent<CameraController> ();
		MainCameraController.IsFollowTarget = false;
		MoveCameraToStartPosition ();
	}

	protected virtual void OnCameraMoveCallback()
	{
		MainCameraController.IsFollowTarget = isCameraFollowTarget;
	}

    public virtual void OnFinish()
	{
		mainCameraController = null;
	}

	// camera methods
	private void MoveCameraToStartPosition()
	{
		LeanTween.move (mainCamera.gameObject, CameraStartPosition () + CameraStartPositionOffset (), cameraTweenDuration)
			.setEase (cameraTween)
			.setOnComplete (OnCameraMoveCallback);
	}

	protected virtual Vector3 CameraStartPositionOffset ()
	{
		return Vector3.zero;
	}

	protected virtual Vector3 CameraStartPosition ()
	{
		return cameraStartPosition;
	}

	protected virtual float CameraTweenDuration ()
	{
		return cameraTweenDuration;
	}

	protected virtual LeanTweenType CameraTween ()
	{
		return cameraTween;
	}

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(cameraStartPosition, 1);
    }
}
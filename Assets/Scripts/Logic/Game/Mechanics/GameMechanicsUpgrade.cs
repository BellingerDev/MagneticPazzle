using UI;
using UnityEngine;
using Player;
using Utils;


public class GameMechanicsUpgrade : GameMechanicsCheckpointsBase
{
	[SerializeField]
	private Vector3 cameraCheckpointOffset;

	[SerializeField]
	private Vector3 magnetPoseRotation;


	public override void OnStart ()
	{
		base.OnStart ();
		MainCamera.GetComponent<CameraController> ().IsFollowTarget = false;

		int checkpointId = PreferencesManager.GetProfile<InGameCheckpointsProgressPropertiesProfile> ().Load<int> ("Id");
		CheckpointController activeCheckpoint = GetCheckpoint (checkpointId);
		LeanTween.move (MainCamera.gameObject, activeCheckpoint.transform.position + CameraStartPositionOffset(), CameraTweenDuration()).setEase (CameraTween());

		Instantiate<GameObject>(GameManager.Instance.PlayerPrefab);
		PlayerController.Instance.transform.eulerAngles += magnetPoseRotation;

		activeCheckpoint.RespawnPlayer();

		UIController.Instance.ShowMenu<UIUpgradeMenu>();

		FogPreferences.Instance.Switch(FogPreferences.State.Upgrade);
	}

    public override void OnFinish ()
	{
		Destroy (PlayerController.Instance.gameObject);
			
		UIController.Instance.HideMenu<UIUpgradeMenu>();

		base.OnFinish ();
	}

	protected override Vector3 CameraStartPositionOffset ()
	{
		return cameraCheckpointOffset;
	}
}
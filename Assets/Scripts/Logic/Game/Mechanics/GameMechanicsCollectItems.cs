using Player;
using UnityEngine;
using Utils;


public class GameMechanicsCollectItems : GameMechanicsCheckpointsBase
{
	[SerializeField]
	private Vector3 playerCameraOffset;

	private CheckpointController latestCheckpoint;


    public override void OnStart()
	{
		Checkpoints = FindObjectsOfType<CheckpointController> ();
		LoadLatestCheckpoint ();

		base.OnStart ();

		GameManager.OnRespawn += OnPlayerRespawn;

		CheckpointController.OnCheckpointReached += OnCheckpointReached;
        PlayerController.OnPlayerDied += OnPlayerDied;

        FogPreferences.Instance.Switch(FogPreferences.State.InGame);
    }

	protected override void OnCameraMoveCallback ()
	{
		UIController.Instance.ShowMenu<UIHUDMenu>();

		Instantiate<GameObject>(GameManager.Instance.PlayerPrefab);
		OnPlayerRespawn ();

		base.OnCameraMoveCallback ();
	}

	protected override Vector3 CameraStartPositionOffset ()
	{
		return playerCameraOffset;
	}

	protected override Vector3 CameraStartPosition ()
	{
		return latestCheckpoint.transform.position;
	}

	private void OnCheckpointReached(CheckpointController checkpoint)
	{
		latestCheckpoint = checkpoint;
	}

	private void OnPlayerDied()
	{
        PlayerController.Instance.gameObject.SetActive(false);
        UIController.Instance.ShowDialog<GameRespawnDialog>();
	}

	private void OnPlayerRespawn()
	{
		latestCheckpoint.RespawnPlayer ();
	}

    public override void OnFinish()
	{
        PlayerController.OnPlayerDied -= OnPlayerDied;
        CheckpointController.OnCheckpointReached -= OnCheckpointReached;
		GameManager.OnRespawn -= OnPlayerRespawn;

        Destroy(PlayerController.Instance.gameObject);

        UIController.Instance.HideMenu<UIHUDMenu>();

		base.OnFinish ();
    }

	private void LoadLatestCheckpoint()
	{
		int checkpointId = PreferencesManager.GetProfile<InGameCheckpointsProgressPropertiesProfile> ().Load<int> ("Id");

		latestCheckpoint = GetCheckpoint (checkpointId);
		if (latestCheckpoint == null)
			latestCheckpoint = GetCheckpoint (0);
	}
}
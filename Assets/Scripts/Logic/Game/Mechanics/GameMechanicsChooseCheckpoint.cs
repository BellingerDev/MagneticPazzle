using System;
using UnityEngine;
using Utils;


public class GameMechanicsChooseCheckpoint : GameMechanicsCheckpointsBase
{
	public static Action<CheckpointController> onCheckpointSwitch;

	[SerializeField]
	private Vector3 checkpointCameraPositionOffset;

	//private vars
	private CheckpointController activeCheckpoint;


    public override void OnStart()
    {
		base.OnStart ();
		
		LoadLatestCheckpoint ();

        FogPreferences.Instance.Switch(FogPreferences.State.LevelChoose);
    }

	protected override void OnCameraMoveCallback ()
	{
		UIController.Instance.ShowMenu<UILevelChooseMenu>();
	}

    public override void OnFinish()
    {
        UIController.Instance.HideMenu<UILevelChooseMenu>();

		activeCheckpoint = null;

		base.OnFinish ();
    }

	protected override Vector3 CameraStartPositionOffset ()
	{
		return checkpointCameraPositionOffset;
	}

	private void LoadLatestCheckpoint()
	{
		int checkpointId = PreferencesManager.GetProfile<InGameCheckpointsProgressPropertiesProfile> ().Load<int> ("Id");

		activeCheckpoint = GetCheckpoint (checkpointId);
		if (activeCheckpoint != null)
			activeCheckpoint = GetCheckpoint (0);
	}
}
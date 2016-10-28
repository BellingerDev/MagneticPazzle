using System;


public abstract class GameMechanicsCheckpointsBase : GameMechanicsBase
{
	protected CheckpointController[] Checkpoints { get; set; }

	// methods
	public override void OnStart()
	{
		Checkpoints = FindObjectsOfType<CheckpointController> ();
		base.OnStart ();
	}

	public override void OnFinish()
	{
		Checkpoints = null;
		base.OnFinish ();
	}

	protected CheckpointController GetCheckpoint(int id)
	{
		return Array.FindLast<CheckpointController>(Checkpoints, c => c.Id == id);
	}
}
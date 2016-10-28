using Player;
using UnityEngine;
using System;
using Environment;
using Utils;


public class CheckpointController : ActivatableBehaviour
{
	[Serializable]
	private class CheckpointData
	{
		public int id;
		public int collectedItemsCount;
		public bool isAchieved;

		public CheckpointData(int id, int collectedItemsCount, bool isAchieved)
		{
			this.id = id;
			this.collectedItemsCount = collectedItemsCount;
			this.isAchieved = isAchieved;
		}

		public CheckpointData()
		{
			this.id = 0;
			this.collectedItemsCount = 0;
			this.isAchieved = false;
		}
	}

	private const string CHECKPOINT_DATA_KEY = "checkpointData";

	[SerializeField]
	private int id;

    [SerializeField]
    private string playerTag;

    [SerializeField]
    private string elementTag;

    [SerializeField]
    private GameObject spawnPoint;

	private int collectedElementsCount;
	private bool isAchieved;

    private float nextActivationTime;
    private PlayerController playerController;

	public int Id { get { return id; } }
	public int CollectedElementsCount { get { return collectedElementsCount; } }
	public bool IsAchieved { get { return isAchieved; } }

	public static Action<CheckpointController> OnCheckpointReached;

    #region Unity Events

    protected override void OnEnable()
    {
        base.OnEnable();
		LoadData ();
	}

	protected override void OnDisable()
	{
		SaveData ();
        base.OnDisable();
	}

	private void LoadData()
	{
		string dataString = PreferencesManager.GetProfile<InGameCheckpointsProgressPropertiesProfile> ().Load<string> (CHECKPOINT_DATA_KEY);

		if (!String.IsNullOrEmpty(dataString))
		{
			CheckpointData data = JsonUtility.FromJson<CheckpointData> (dataString);

			collectedElementsCount = data.collectedItemsCount;
			isAchieved = data.isAchieved;
		}
	}

	private void SaveData()
	{
		CheckpointData data = new CheckpointData (Id, CollectedElementsCount, IsAchieved);
		PreferencesManager.GetProfile<InGameCheckpointsProgressPropertiesProfile> ().Save<string> (CHECKPOINT_DATA_KEY, JsonUtility.ToJson(data));
	}

    private void OnTriggerEnter(Collider col)
    {
		if (col.tag == playerTag)
		{
            if (OnCheckpointReached != null)
                OnCheckpointReached(this);

			if (!isAchieved)
			{
				isAchieved = true;
			}

            Activate();
		}

        if (col.tag == elementTag)
        {
            collectedElementsCount++;
            PoolController.Instance.Retrieve(col.gameObject);
        }
    }

    #endregion

	public void RespawnPlayer()
    {
        PlayerController.Instance.transform.position = spawnPoint.transform.position;
        PlayerController.Instance.gameObject.SetActive(true);
    }
}

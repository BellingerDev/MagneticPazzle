using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private enum MechanicsState
    {
        InGame,
        LevelChoose,
        MainMenu,
		Upgrade
    }

	[Serializable]
	private class GamePrototiesData
	{
		public GameObject playerPrefab;
		public GameObject[] elementsPrefabs;
	}

	[Serializable]
	private class GameMechanicsData
	{
		public GameObject winConditionsObject;
		public GameObject loseConditionsObject;
		public GameObject mechanicsObject;
	}
		
    public static GameManager Instance { get; private set; }
	public GameObject PlayerPrefab { get { return propertiesData.playerPrefab; } }

	[SerializeField]
	private GamePrototiesData propertiesData;

	[SerializeField]
	private GameMechanicsData mechanicsData;

    [SerializeField]
    private MechanicsState startMechanics;

	private GameConditionBase[] winConditions;
	private GameConditionBase[] loseConditions;
	private GameMechanicsBase[] mechanics;

	private GameMechanicsBase activeMechanics;

    private GameControllerBase[] controllers;

	public static Action OnWin;
	public static Action OnLose;
    public static Action OnRespawn;

    #region Unity Events

    private void OnEnable()
    {
        Instance = this;
        InitControllers();
		InitConditions ();

		mechanics = mechanicsData.mechanicsObject.GetComponentsInChildren<GameMechanicsBase> ();
		activeMechanics = null;
    }

    private void Start()
    {
        switch (startMechanics)
        {
            case MechanicsState.LevelChoose:
                SwitchMechanics<GameMechanicsChooseCheckpoint>();
                break;

            case MechanicsState.InGame:
                SwitchMechanics<GameMechanicsCollectItems>();
                break;

			case MechanicsState.Upgrade:
				SwitchMechanics<GameMechanicsUpgrade> ();
				break;
        }
    }

    private void OnDisable()
    {
		if (activeMechanics != null)
			activeMechanics.OnFinish();
		
        mechanics = null;

		DeinitConditions ();
        DeinitControllers();
        Instance = null;
    }

    #endregion

    #region Controllers

    private void InitControllers()
    {
        controllers = new GameControllerBase[]
        {
			new GameLevelsController(),
			new GameScoreController()
        };

        foreach (var c in controllers)
            c.Init();
    }

    private void DeinitControllers()
    {
        foreach (var c in controllers)
            c.Deinit();

        controllers = null;
    }

    public T ControllerAt<T>() where T : GameControllerBase
    {
        return Array.FindLast(controllers, c => c is T) as T;
    }

    #endregion

    #region Conditions

	private void InitConditions()
	{
		winConditions = mechanicsData.winConditionsObject.GetComponents<GameConditionBase> ();
		loseConditions = mechanicsData.loseConditionsObject.GetComponents<GameConditionBase> ();
	}

    public void CheckConditions()
    {
		foreach (var c in loseConditions)
		{
			if (c.Check (null))
			{
				if (OnLose != null)
				{
					OnLose ();
					return;
				}
			}
		}

		foreach (var c in winConditions)
		{
			if (!c.Check (null))
				return;
		}

		if (OnWin != null)
			OnWin ();
    }

	private void DeinitConditions()
	{
		winConditions = null;
		loseConditions = null;
	}

    #endregion

	public void SwitchMechanics<T>() where T : GameMechanicsBase
    {
		if (activeMechanics != null)
			activeMechanics.OnFinish();

		activeMechanics = Array.FindLast<GameMechanicsBase> (mechanics, m => m is T);
		if (activeMechanics != null)
			activeMechanics.OnStart ();
    }

	public T GetMechanics<T>() where T : GameMechanicsBase
    {
		T mechanic = (T)(object)Array.FindLast<GameMechanicsBase> (mechanics, m => m is T);
		if (mechanics != null)
			return mechanic;

        return default(T);
    }
}
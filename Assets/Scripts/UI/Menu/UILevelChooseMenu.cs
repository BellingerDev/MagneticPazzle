using UnityEngine;


public class UILevelChooseMenu : UIMenuBase
{
    private GameMechanicsChooseCheckpoint mechanics;
    private int currentIndex;
    private int checkpointsCount;
    

    private void Start()
    {
        mechanics = GameManager.Instance.GetMechanics<GameMechanicsChooseCheckpoint>();
        currentIndex = 0;
//        checkpointsCount = mechanics.GetCheckpointsCount();
    }

    public void SwitchNext()
    {
        currentIndex++;
        if (currentIndex >= checkpointsCount)
            currentIndex = 0;

//        mechanics.SwitchCheckpoint(currentIndex);
    }

    public void SwitchPrev()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = checkpointsCount - 1;

//        mechanics.SwitchCheckpoint(currentIndex);
    }

    public void Play()
    {
//        mechanics.SwitchState(GameMechanicsChooseCheckpoint.CheckpointState.InGame);
        GameManager.Instance.SwitchMechanics<GameMechanicsCollectItems>();
    }
}


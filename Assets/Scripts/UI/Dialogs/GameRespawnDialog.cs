public class GameRespawnDialog : UIDialogBase
{
    public void OnRespawnClicked()
    {
        if (GameManager.OnRespawn != null)
            GameManager.OnRespawn();

        Hide();
    }
}


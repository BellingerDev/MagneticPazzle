using Player;
using UnityEngine;


public class UIHUDController : MonoBehaviour
{
    public void OnMoveLeftStart()
    {
        PlayerController.Actions.Add(PlayerActions.MoveLeft);
    }

    public void OnMoveLeftStop()
    {
        PlayerController.Actions.Remove(PlayerActions.MoveLeft);
    }

    public void OnMoveRightStart()
    {
        PlayerController.Actions.Add(PlayerActions.MoveRight);
    }

    public void OnMoveRightStop()
    {
        PlayerController.Actions.Remove(PlayerActions.MoveRight);
    }

    public void OnMagneticStart()
    {
        PlayerController.Actions.Add(PlayerActions.Magnetic);
    }

    public void OnMagneticStop()
    {
        PlayerController.Actions.Remove(PlayerActions.Magnetic);
    }

    public void OnExplode()
    {
        PlayerController.Actions.Add(PlayerActions.Explode);
    }

    public void OnJump()
    {
        PlayerController.Actions.Add(PlayerActions.Jump);
    }

    public void OnSettingsClicked()
    {
        UIController.Instance.ShowDialog<GameQualitySettingsDialog>();
    }
}
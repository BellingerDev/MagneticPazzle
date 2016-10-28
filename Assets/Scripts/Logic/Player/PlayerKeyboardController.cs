using Player;
using UnityEngine;


public class PlayerKeyboardController : MonoBehaviour
{
    public KeyCode leftButton;
    public KeyCode rightButton;

    public KeyCode magneticButton;
    public KeyCode explodeButton;
    public KeyCode jumpButton;
    public KeyCode shiftButton;


    void Update()
    {
        if (PlayerController.Actions == null)
            return;

		if (Input.GetKeyDown(leftButton))
			if (!PlayerController.Actions.Contains (PlayerActions.MoveLeft))
	            PlayerController.Actions.Add(PlayerActions.MoveLeft);

		if (Input.GetKeyDown(rightButton))
			if (!PlayerController.Actions.Contains (PlayerActions.MoveRight))
	            PlayerController.Actions.Add(PlayerActions.MoveRight);

		if (Input.GetKeyDown(magneticButton))
			if (!PlayerController.Actions.Contains (PlayerActions.Magnetic))
	            PlayerController.Actions.Add(PlayerActions.Magnetic);

		if (Input.GetKeyDown(explodeButton))
			if (!PlayerController.Actions.Contains (PlayerActions.Explode))
	            PlayerController.Actions.Add(PlayerActions.Explode);

		if (Input.GetKeyDown(jumpButton))
			if (!PlayerController.Actions.Contains (PlayerActions.Jump))
	            PlayerController.Actions.Add(PlayerActions.Jump);

        if (Input.GetKeyDown(shiftButton))
            if (!PlayerController.Actions.Contains(PlayerActions.Shift))
                PlayerController.Actions.Add(PlayerActions.Shift);

        if (Input.GetKeyUp(leftButton))
			if (PlayerController.Actions.Contains (PlayerActions.MoveLeft))
	            PlayerController.Actions.Remove(PlayerActions.MoveLeft);

		if (Input.GetKeyUp(rightButton))
			if (PlayerController.Actions.Contains (PlayerActions.MoveRight))
		            PlayerController.Actions.Remove(PlayerActions.MoveRight);

        if (Input.GetKeyUp(magneticButton))
			if (PlayerController.Actions.Contains (PlayerActions.Magnetic))
	            PlayerController.Actions.Remove(PlayerActions.Magnetic);

    }
}
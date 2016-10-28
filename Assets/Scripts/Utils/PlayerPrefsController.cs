using UnityEngine;


public class PlayerPrefsController : MonoBehaviour 
{
	[SerializeField]
	private bool isReset;


	private void OnApplicationQuit()
	{
		if (isReset)
		{
			PlayerPrefs.DeleteAll ();
			PlayerPrefs.Save ();
		}
	}
}

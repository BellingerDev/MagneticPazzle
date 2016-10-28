using UnityEngine;


public class UIMainMenu : UIMenuBase
{
	public void OnNewGameClicked()
	{
        UIController.Instance.ShowMenu<UILevelChooseMenu>();
	}

	public void OnLoadGameClicked()
	{

	}

	public void OnMultiplayerClicked()
	{

	}

	public void OnSettingsClicked()
	{

	}

	public void OnQuitClicked()
	{

	}
}


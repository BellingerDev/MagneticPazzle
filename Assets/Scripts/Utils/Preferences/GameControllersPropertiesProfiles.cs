using UnityEngine;


public class GameControllerScorePropertiesProfile : PreferencesProfileBase
{
	public override void Init ()
	{
		profilePrefix += "Game/Controllers/Score";
	}
}

public class GameControllerLevelsPropertiesProfile : PreferencesProfileBase
{
	public override void Init ()
	{
		profilePrefix += "Game/Controllers/Levels";
	}
}


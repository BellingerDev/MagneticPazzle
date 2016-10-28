using System;
using System.Linq;


public static class PreferencesManager
{
    private static PreferencesProfileBase[] profiles;

    static PreferencesManager()
    {
        Init();
    }

    private static void Init()
    {
        profiles = new PreferencesProfileBase[]
        {
            new MagneticPropertiesProfile(),
            new MovePropertiesProfile(),
            new ExplodePropertiesProfile(),
            new JumpPropertiesProfile(),
            new EnergyPropertiesProfile(),
            new ShiftPropertiesProfile(),

			new GameControllerScorePropertiesProfile(),
			new GameControllerLevelsPropertiesProfile(),

			new InGameCheckpointsProgressPropertiesProfile()
        };
    }

    public static Type GetProfile<Type>()
    {
        PreferencesProfileBase profile = profiles.Single(p => p.GetType() == typeof(Type));
        return (Type)Convert.ChangeType(profile, typeof(Type));
    }

	public static PreferencesProfileBase GetProfile(string name)
	{
		return profiles.Single (p => p.GetType ().Name == name);
	}
}

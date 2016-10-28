using System;

public class MagneticPropertiesProfile : PreferencesProfileBase
{
    public override void Init()
    {
        profilePrefix += "Player/MagneticProperties/";
    }
}

public class MovePropertiesProfile : PreferencesProfileBase
{
    public override void Init()
    {
        profilePrefix += "Player/MoveProperties";
    }
}

public class ExplodePropertiesProfile : PreferencesProfileBase
{
    public override void Init()
    {
        profilePrefix += "Player/ExplodeProperties";
    }
}

public class JumpPropertiesProfile : PreferencesProfileBase
{
    public override void Init()
    {
        profilePrefix += "Player/JumpProperties";
    }
}

public class EnergyPropertiesProfile : PreferencesProfileBase
{
    public override void Init()
    {
        profilePrefix += "Player/EnergyProperties";
    }
}

public class ShiftPropertiesProfile : PreferencesProfileBase
{
    public override void Init()
    {
        profilePrefix += "Player/ShiftProperties";
    }
}
using UnityEngine;


public class GameScoreController : GameControllerBase
{
    private const string SCORE_ID = "game_score";

    private int points;


    public override void Init()
    {
		points = PreferencesManager.GetProfile<GameControllerScorePropertiesProfile>().Load<int>(SCORE_ID);
    }

    public override void Deinit()
	{
		PreferencesManager.GetProfile<GameControllerScorePropertiesProfile>().Save<int>(SCORE_ID, points);
    }

    public void AppendPoints(int count)
    {
        points += count;
    }

    public void ReducePoints(int count)
    {
        points -= count;
    }
    public int GetCount()
    {
        return points;
    }
}
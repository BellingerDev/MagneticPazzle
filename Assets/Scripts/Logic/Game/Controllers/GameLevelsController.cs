using System;
using UnityEngine;


public class GameLevelsController : GameControllerBase
{
    private const string SAVE_LEVELS_ID = "levelsProgressData";
    private const string FALLBACK_SCENE_NAME = "Main Level";

    [Serializable]
    private class LevelProgressData
    {
        public string sceneId;
        public bool finished;
        public MatchProgressData[] matches;

        public LevelProgressData(string sceneID)
        {
            matches = new MatchProgressData[0];
        }
    }

    [Serializable]
    public class MatchProgressData
    {
        public int elements;
        public int deaths;
        public int secrets;
    }

    [SerializeField]
    private string[] levels;

    private LevelProgressData[] levelsProgressData;


    public override void Init()
    {
        Load();
    }

    public override void Deinit()
    {
        Save();
    }

    public void FinalizeLevel(string sceneId)
    {
        LevelProgressData level = Array.FindLast<LevelProgressData>(levelsProgressData, l => l.sceneId == sceneId);
        if (level != null)
            level.finished = true;
    }

    public void FinalizeMatch(string sceneId, MatchProgressData matchData)
    {
        LevelProgressData level = Array.FindLast<LevelProgressData>(levelsProgressData, l => l.sceneId == sceneId);
        if (level == null)
        {
            Array.Resize<LevelProgressData>(ref levelsProgressData, levelsProgressData.Length + 1);
            level = new LevelProgressData(sceneId);
        }

        Array.Resize<MatchProgressData>(ref level.matches, level.matches.Length + 1);
        level.matches[level.matches.Length - 1] = matchData;
    }

    private void Load()
    {
		string savedJson = PreferencesManager.GetProfile<GameControllerLevelsPropertiesProfile> ().Load<string> (SAVE_LEVELS_ID);

        if (String.IsNullOrEmpty(savedJson))
            InitWithoutSave();
        else
            levelsProgressData = JsonUtility.FromJson<LevelProgressData[]>(savedJson);
    }

    private void Save()
    {
        string jsonToSave = JsonUtility.ToJson(levelsProgressData);
		PreferencesManager.GetProfile<GameControllerLevelsPropertiesProfile> ().Save<string> (SAVE_LEVELS_ID, jsonToSave);
    }

    private void InitWithoutSave()
    {
        levelsProgressData = new LevelProgressData[0];
    }

    public bool IsLevelFinished(string sceneId)
    {
        LevelProgressData level = Array.FindLast<LevelProgressData>(levelsProgressData, l => l.sceneId == sceneId);
        if (level != null)
            return level.finished;

        return false;
    }

    public string GetActiveLevelSceneId()
    {
        foreach (var l in levelsProgressData)
            if (!l.finished)
                return l.sceneId;

        return FALLBACK_SCENE_NAME;
    }
}
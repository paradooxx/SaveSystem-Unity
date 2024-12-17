[System.Serializable]
public class GameSaveData
{
    public int Data;
    public CustomData CustomData;

    public GameSaveData(GameDataManager gameDataManager)
    {
        Data = gameDataManager.Data;
        CustomData = gameDataManager.CustomData;
    }
}

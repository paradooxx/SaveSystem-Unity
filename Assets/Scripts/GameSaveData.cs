[System.Serializable]
public class GameSaveData
{
    public int Data;

    public GameSaveData(GameDataManager gameDataManager)
    {
        Data = gameDataManager.Data;
    }
}

using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    [SerializeField] private int data;
    [SerializeField] private CustomData customData;

    public int Data { get => data; set { data = value; SaveGameData(); }}
    public CustomData CustomData { get => customData; set { customData = value; SaveGameData(); } }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
            SaveGameData();
            LoadGameData();
            // SaveSystem.DeleteSaveData();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void LoadGameData()
    {
        GameSaveData gameSaveData = SaveSystem.LoadData();
        if(gameSaveData == null) return;

        Data = gameSaveData.Data;
        CustomData = gameSaveData.CustomData;
    }

    public void SaveGameData()
    {
        SaveSystem.SaveData(this);
    }
}

[System.Serializable]
public class CustomData
{
    public int customInt;
    public float customFloat;
    public string customString;
}
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    [SerializeField] private int data;

    public int Data { get => data; set { data = value; SaveGameData(); }}

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
            LoadGameData();
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
    }

    public void SaveGameData()
    {
        SaveSystem.SaveData(this);
    }
}

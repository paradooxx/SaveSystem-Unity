using TMPro;
using UnityEngine;

public class ShowData : MonoBehaviour
{
    [SerializeField] private TMP_Text dataText;

    private void Start()
    {
        dataText.text = "Data: " + GameDataManager.Instance.CustomData.customInt;
    }

    public void IncreaseData()
    {
        GameDataManager.Instance.CustomData.customInt ++;
        dataText.text = "Data: " + GameDataManager.Instance.CustomData.customInt;
        GameDataManager.Instance.SaveGameData();
    }

    public void DecreaseData()
    {
        GameDataManager.Instance.CustomData.customInt --;
        dataText.text = "Data: " + GameDataManager.Instance.CustomData.customInt;
        GameDataManager.Instance.SaveGameData();
    }
}

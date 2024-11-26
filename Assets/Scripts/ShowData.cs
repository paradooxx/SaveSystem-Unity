using TMPro;
using UnityEngine;

public class ShowData : MonoBehaviour
{
    [SerializeField] private TMP_Text dataText;

    private void Start()
    {
        dataText.text = "Data: " + GameDataManager.Instance.Data;
    }

    public void IncreaseData()
    {
        GameDataManager.Instance.Data ++;
        dataText.text = "Data: " + GameDataManager.Instance.Data;
    }

    public void DecreaseData()
    {
        GameDataManager.Instance.Data --;
        dataText.text = "Data: " + GameDataManager.Instance.Data;
    }
}

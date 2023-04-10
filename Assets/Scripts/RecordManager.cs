using TMPro;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    public TMP_Text BestScore;
    public TMP_Text LastScore;

    void Update()
    {
        BestScore.text = $"Лучший счёт: {PlayerPrefs.GetInt("BestCoins")}";
        LastScore.text = $"Предыдущий счёт: {PlayerPrefs.GetInt("lastCoins")}";
    }
}

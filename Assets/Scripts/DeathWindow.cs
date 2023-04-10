using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathWindow : MonoBehaviour
{
    public GameObject deathPanel;
    public TMP_Text LastScore;

    void Update() {
        LastScore.text = $"Ñ÷¸ò: {PlayerPrefs.GetInt("lastCoins")}";
    }

    public void DwOpen() {
        deathPanel.SetActive(true);
    }
}

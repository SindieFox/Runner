using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject recordsPanel;
    
    public void PlayGame()
    {
        PlayerPrefs.DeleteKey("lastCoins");
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RecordsPanelOpen()
    {
        recordsPanel.SetActive(true);
    }

    public void ExitRecordsPanel()
    {
        recordsPanel.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject deathPanel;
    public PlayerController Player;
    public float levelRestartDelay = 2f;

    private void Start()
    {
        Player = GetComponent<PlayerController>();       
        
    }
    public void EndGame()
    {
        //Debug.Log(deathPanel);
        //deathWindow.DwOpen();
        //Debug.Log(GameObject.Find("DeathPanel"));
        deathPanel.SetActive(true);
        //try {
        //    deathPanel.SetActive(true);
        //}
        //catch {
        //    Debug.Log("blyat");
        //}
        //GameObject.Find("DeathPanel").SetActive(true);

        Player.DeathAnim();
        Player.enabled = false;

        Invoke("RestartLevel", levelRestartDelay);
        Debug.Log("over game");

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using TMPro;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    private int coins = 0;
    public TMP_Text cointText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            coins++;
            PlayerPrefs.SetInt("lastCoins", coins);
            if (coins > PlayerPrefs.GetInt("BestCoins")) {
                PlayerPrefs.SetInt("BestCoins", coins);
            }
            Debug.Log(PlayerPrefs.GetInt("BestCoins"));
            cointText.text = coins.ToString();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "BoosterDoubleJump")
        {
            PlayerPrefs.SetInt("dj", 1);
            Destroy(collision.gameObject);
        }
    }
}

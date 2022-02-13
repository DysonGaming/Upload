using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public Text highScore;
    public TextMeshProUGUI bank;

    // Ecomony & Character specs

    public int bankPoints;

    // Start is called before the first frame update
    public void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        bankPoints = PlayerPrefs.GetInt("bank", 0);
        bank.text = PlayerPrefs.GetInt("bank", 0).ToString();
    }

    public void handleScore(int score) 
    {
        // Set new bank value filevar
        PlayerPrefs.SetInt("bank", score + bankPoints);
        // Set bank value gamevar
        bankPoints = PlayerPrefs.GetInt("bank", 0);

        // Set text value
        bank.text = "Bank: " + bankPoints.ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0)) 
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
        }
    }
}
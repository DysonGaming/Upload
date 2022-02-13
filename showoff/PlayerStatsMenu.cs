using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsMenu : MonoBehaviour
{
    public TextMeshProUGUI PlayerNameTxt;
    public TMP_InputField inputName;

    public TextMeshProUGUI highScoreStats;
    public TextMeshProUGUI bankStats;

    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        PlayerNameTxt.text = PlayerPrefs.GetString("name", playerName);


        highScoreStats.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        bankStats.text = PlayerPrefs.GetInt("bank", 0).ToString();
    }

    public void ChangeName() 
    {
        playerName = inputName.text;
        PlayerPrefs.SetString("name", playerName);
        PlayerNameTxt.text = PlayerPrefs.GetString("name");
    }

    public void resetPlayerPrefs() 
    {
        PlayerPrefs.SetString("name", "No Name");
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("bank", 0);
        PlayerPrefs.Save();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;
    private string keyToSave = "keyHighscore";
    public TextMeshProUGUI uiTextHighscore;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiTextHighscore.text = PlayerPrefs.GetString(keyToSave, "---");
    }

    public void SavePlayerWin(Player p)
    {
        PlayerPrefs.SetString(keyToSave, p.playerName);
        UpdateText();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeNameBase : MonoBehaviour
{

    [Header("References")]

    public TextMeshProUGUI uiTextname;
    public TMP_InputField uiInputName;
    public TextMeshProUGUI uiTextInGameName;
    public Player player;

    private string _playerName;

   
    public void UseDefaultName()
    {
        if (uiInputName.text == "")
        {
            _playerName = uiTextname.text;
            player.SetName(_playerName);
        }
    }

    public void ChangeName()
    {
        if (uiInputName.text == "")
        {
            return;
        }

        _playerName = uiInputName.text;
        uiTextname.text = _playerName;
        uiTextInGameName.text = _playerName;
        player.SetName(_playerName);
    }

    public void KeyToChangeName()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (uiInputName.text == "")
            {
                return;
            }
            ChangeName();

        }
    }
    private void Update()
    {
        KeyToChangeName();
    }
}
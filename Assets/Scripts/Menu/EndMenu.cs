using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public Player player1;
    public Player player2;

    public TextMeshProUGUI uiWinner;
    public TextMeshProUGUI playerName1;
    public TextMeshProUGUI playerName2;

    public void CheckWinner()
    {
    if(player1.currentPoints >= player1.pointsToWin)
        {
            uiWinner.text = playerName1.text;
        }

        if (player2.currentPoints >= player2.pointsToWin)
        {
            uiWinner.text = playerName2.text;
        }

    }
}

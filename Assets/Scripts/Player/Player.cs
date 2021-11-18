using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Player : MonoBehaviour
{
    public float speed = 15f;
    private int _speedMultiply_p = 1000;
    private Vector3 _startPosition;
    public Rigidbody2D playerBody;
    public Image uiPlayer;
    public string playerName;


    [Header("Key Congif")]
    public KeyCode keyCodeMoveUp = KeyCode.W;
    public KeyCode keyCodeMoveDown = KeyCode.S;

    [Header("Player Points")]
    public int currentPoints;
    public int pointsToWin = 3;
    public TextMeshProUGUI uiPoints;

    [Header("Menus")]
    public GameObject endMenu;
    public GameObject mainMenu;

    private void Awake()
    {
        mainMenu.SetActive(true);
        _startPosition = transform.position;
        ResetPoints();
    }

    void Update()
    {
        PlayerMovement();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void PlayerMovement()
    {
        if (Input.GetKey(keyCodeMoveUp))
        {
            playerBody.MovePosition(transform.position + (transform.up * speed * _speedMultiply_p * Time.deltaTime));
        }
        else if (Input.GetKey(keyCodeMoveDown))
        {
            playerBody.MovePosition(transform.position + (transform.up * -speed * _speedMultiply_p * Time.deltaTime));
        }
    }
    private void ResetPoints()
    {
        currentPoints = 0;
        UpdateUi();
    }

    public void UpdatePoint()
    {
        currentPoints++;
        UpdateUi();
        StateMachine.Instance.FinishGame();
        
    }

    public void UpdateUi()
    {
        uiPoints.text = currentPoints.ToString();
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        ResetPoints();

    }

    public void FinishMatch()
    {
        if(currentPoints >= pointsToWin)
        {
            endMenu.SetActive(true);
            HighscoreManager.Instance.SavePlayerWin(this);

        }
    }
    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }
}

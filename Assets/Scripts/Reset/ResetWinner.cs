using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetWinner : MonoBehaviour
{
    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}

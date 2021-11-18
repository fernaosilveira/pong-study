using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public Player player;
    public string tagToCheck = "Ball";

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == tagToCheck)
        {
            CountPoint();
        }
    }

    private void CountPoint()
    {
        player.UpdatePoint();
        StateMachine.Instance.ResetPosition();

    }
}

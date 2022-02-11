using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingArch : MonoBehaviour
{

    // When the player walks through the gate
    private void OnTriggerEnter(Collider other)
    {
        // If the game hasn't started yet
        if(!GameManager.Instance.started)
        {
            GameManager.Instance.StartGame();
        }
    }
}

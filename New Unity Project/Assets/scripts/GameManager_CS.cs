using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_CS : MonoBehaviour
{
    private bool gameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats_CS.lives <= 0)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");
    }
}

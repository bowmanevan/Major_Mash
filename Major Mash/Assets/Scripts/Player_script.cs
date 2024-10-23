using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : MonoBehaviour
{
public int playerValue = 100; // Initial value (health)

    public void ReduceValue(int amount)
    {
        playerValue -= amount;
        Debug.Log("Player value: " + playerValue);
        
        // Check if playerValue reaches 0
        if (playerValue <= 0)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        // Move the player object (you can adjust the position as needed)
        transform.position += new Vector3(1f, 0f, 0f); // Moves down the z-axis
        Debug.Log("Player has been moved due to health reaching zero.");
    }
}

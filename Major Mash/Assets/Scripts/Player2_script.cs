using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player2_script : MonoBehaviour
{
public int player2Health= 100; // health of player

    public void ReduceValue(int amount)
    {
        player2Health -= amount;
       
        
        
        if (player2Health <= 0)
        {
            endPlayer();
        }
    }

    private void endPlayer()
    {
        SceneManager.LoadScene(2);
        
        
    }
}

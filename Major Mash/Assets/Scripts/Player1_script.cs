using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player1_script : MonoBehaviour
{
public int player1Health = 100; // health of player

    public void ReduceValue(int amount)
    {
        player1Health -= amount;
       
        
        
        if (player1Health <= 0)
        {
            endPlayer();
        }
    }

    private void endPlayer()
    {
        SceneManager.LoadScene(3);
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Button : MonoBehaviour
{
    public int clickableValue = 50; //how much damage a card does
    
    private void OnMouseDown()
    {
        Turn_script manager = FindObjectOfType<Turn_script>();
        MoveObject();
        ReducePlayerValue(manager.turn);
        
        manager.whoseTurn();
        
        Debug.Log("next turn");
    }

    private void MoveObject()
    {
        // Move the card to show it has been played
        transform.position += new Vector3(-1f, 0f, 0f);
    }

    private void ReducePlayerValue(bool cardturn)
    {
        // Find the player object and call its method to reduce health
        Player1_script player1 = FindObjectOfType<Player1_script>();
        Player2_script player2 = FindObjectOfType<Player2_script>();


        if (player1 != null && player2 != null) //not sure what the point of this if statment is
        {
            if(cardturn)
            {
            Debug.Log("player 2 health reduced");
            player2.ReduceValue(clickableValue);
            }

            else 
            {
            Debug.Log("player 1 health reduced");
            player1.ReduceValue(clickableValue);
            }
            
        }
    }

}

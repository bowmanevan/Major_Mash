using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Button : MonoBehaviour
{
    public int clickableValue = 25; // How much damage a card does
    
    private void OnMouseDown()
    {
        Turn_script manager = FindObjectOfType<Turn_script>();
        PlayCard(manager);
        ReducePlayerValue(manager.turn);
        manager.whoseTurn();
        
        Debug.Log("Next turn");
    }

    private void PlayCard(Turn_script manager)
    {
        // This method is called when the card is played. 
        // It handles the removal of the card.
        Destroy(gameObject);  // Delete the card from the scene
    }

    public void EnterObject() // When the card enters the player's hand (can be called when shuffled into hand)
    {
        transform.position += new Vector3(0f, -1f, 0f); 
    }

    private void ReducePlayerValue(bool cardturn)
    {
        // Find the player object and call its method to reduce health
        Player1_script player1 = FindObjectOfType<Player1_script>();
        Player2_script player2 = FindObjectOfType<Player2_script>();

        if (player1 != null && player2 != null)
        {
            if (cardturn)
            {
                Debug.Log("Player 1 picked the evil card");
                player1.ReduceValue(clickableValue);
            }
            else 
            {
                Debug.Log("Player 2 picked the evil card");
                player2.ReduceValue(clickableValue);
            }
        }
    }
}

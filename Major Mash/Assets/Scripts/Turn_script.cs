using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_script : MonoBehaviour

{
    public GameObject Player1Camera; 
    public GameObject Player2Camera;
    public bool turn; 
    public int random;

    private void Start() // Start with Player 1's camera active
    {

        random = Random.Range(0, 2);

        if (random == 0)
        {
        turn = true;
        Player1Camera.SetActive(true);
        Player2Camera.SetActive(false);
        }

        else 
        {
        turn = false;
        Player1Camera.SetActive(false);
        Player2Camera.SetActive(true);

        }
    }
    public void whoseTurn()
    {
        turn = !turn; //toggle the turn bool, switching camera view

        if (turn) //if turn is true, set player 1 camera to active
        {
            Player1Camera.SetActive(true);
            Player2Camera.SetActive(false);
        }

        else //if turn is false, set player 2 camera to active
        {
            Player1Camera.SetActive(false);
            Player2Camera.SetActive(true);
        }
        
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Button : MonoBehaviour
{
    public int clickableValue = 50;

    private void OnMouseDown()
    {
        MoveObject();
        ReducePlayerValue();
    }

    private void MoveObject()
    {
        // Move the object -1 units along the x-axis
        transform.position += new Vector3(-1f, 0f, 0f);
    }

    private void ReducePlayerValue()
    {
        // Find the player object and call its method to reduce value
        Player_script player = FindObjectOfType<Player_script>();
        if (player != null)
        {
            player.ReduceValue(clickableValue);
        }
    }

}

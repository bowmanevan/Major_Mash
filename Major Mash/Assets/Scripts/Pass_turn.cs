using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass_turn : MonoBehaviour
{
    
    
    private void OnMouseDown()
    {
        Turn_script manager = FindObjectOfType<Turn_script>();
        
        manager.whoseTurn();
        
        Debug.Log("turn passed");
    }

    

    

}

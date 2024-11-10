using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleQueueScript : MonoBehaviour
{
    // An array or list to hold the 6 GameObjects
    public GameObject[] Cards;  // This will be assigned in the Inspector or dynamically

    // The Queue that will store the shuffled GameObjects
    private Queue<GameObject> shuffledCards = new Queue<GameObject>(); //no memory leak, unity has a thing called garbage collecter which returns memory when program ends 

    void Start()
    {
        // Step 1: Shuffle the game objects list
        Shuffle(Cards);

        // Step 2: Add the shuffled GameObjects to the queue
        foreach (var obj in Cards)
        {
            shuffledCards.Enqueue(obj);
        }

        // Debugging: Print out the contents of the queue to check
        PrintQueue();

        GameObject firstCard = shuffledCards.Dequeue();
        Debug.Log("First card removed from the queue: " + firstCard.name);
        EnterCard(firstCard);
    }

    private void EnterCard(GameObject card)
    {
        
        Card_Button cardController = card.GetComponent<Card_Button>(); //creates a variable to call the card button enterObject function

        cardController.EnterObject();
        
        
    }

    // Step 3: Shuffle function (using Fisher-Yates algorithm)
    void Shuffle(GameObject[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    // Debugging: Print the shuffled queue's elements
    void PrintQueue()
    {
        Debug.Log("Shuffled Queue:");

        foreach (var obj in shuffledCards)
        {
            Debug.Log(obj.name);
        }
    }
}



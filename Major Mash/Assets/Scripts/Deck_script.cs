using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleQueueScript : MonoBehaviour
{
    // An array or list to hold the 5 GameObjects
    public GameObject[] Cards;  // This will be assigned in the Inspector or dynamically

    // The Queue that will store the shuffled GameObjects
    private Queue<GameObject> shuffledCards = new Queue<GameObject>();

    // Define the positions where the cards should be placed (updated with 5 positions)
    private Vector3[] positions = new Vector3[]
    {
        new Vector3(1.2f, 1.352f, 0f),
        new Vector3(0.6f, 1.352f, 0f),
        new Vector3(0f, 1.352f, 0f),
        new Vector3(-0.6f, 1.352f, 0f),
        new Vector3(-1.2f, 1.352f, 0f)
    };

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

        // Step 3: Place each card at a random position
        PlaceCardsAtRandomPositions();
    }

    private void PlaceCardsAtRandomPositions()
    {
        // Step 4: Ensure that there are exactly 5 positions and 5 cards
        if (Cards.Length == 5 && positions.Length == 5)
        {
            // Shuffle the positions
            ShufflePositions();

            // Place each card at the shuffled position
            for (int i = 0; i < Cards.Length; i++)
            {
                GameObject card = shuffledCards.Dequeue();
                card.transform.position = positions[i];  // Set the position of each card
                Debug.Log(card.name + " placed at " + positions[i]);
            }
        }
        else
        {
            Debug.LogError("There should be exactly 5 cards and 5 positions!");
        }
    }

    private void ShufflePositions()
    {
        // Shuffle the positions using the Fisher-Yates algorithm
        for (int i = positions.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Vector3 temp = positions[i];
            positions[i] = positions[j];
            positions[j] = temp;
        }
    }

    private void EnterCard(GameObject card)
    {
        Card_Button cardController = card.GetComponent<Card_Button>(); // Call the card button's EnterObject function
        cardController.EnterObject();
    }

    // Step 5: Shuffle function (using Fisher-Yates algorithm)
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


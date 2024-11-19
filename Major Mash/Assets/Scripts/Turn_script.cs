/*using System.Collections;
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
    */

using UnityEngine;

public class Turn_script : MonoBehaviour
{
    public Camera Player1Camera; // Camera for Player 1
    public Camera Player2Camera; // Camera for Player 2
    public float transitionSpeed = 2.0f; // Speed of the camera transition

    private Transform currentTarget; // Current camera target (using the camera's transform)
    private bool isTransitioning = false; // Is the camera transitioning?

    private Camera mainCamera; // Reference to the main camera
    public bool turn = true;

    void Start()
    {
        // Cache the main camera reference
        mainCamera = Camera.main;

        // Start focused on Player 1's camera
        currentTarget = Player1Camera.transform;
        mainCamera.transform.position = Player1Camera.transform.position;
        mainCamera.transform.rotation = Player1Camera.transform.rotation;

        // Disable Player 2's camera
        Player2Camera.enabled = false;
    }

    void Update()
    {
        if (isTransitioning)
        {
            // Smoothly move and rotate the main camera to the target
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, currentTarget.position, Time.deltaTime * transitionSpeed);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, currentTarget.rotation, Time.deltaTime * transitionSpeed);

            // Check if the main camera is close enough to the target
            if (Vector3.Distance(mainCamera.transform.position, currentTarget.position) < 0.01f &&
                Quaternion.Angle(mainCamera.transform.rotation, currentTarget.rotation) < 0.1f)
            {
                isTransitioning = false; // Stop transitioning
            }
        }
    }

    public void SwitchToPlayer1()
    {
        Player2Camera.enabled = false; // Disable Player 2's camera
        Player1Camera.enabled = true; // Enable Player 1's camera
        currentTarget = Player1Camera.transform;
        isTransitioning = true;
    }

    public void SwitchToPlayer2()
    {
        Player1Camera.enabled = false; // Disable Player 1's camera
        Player2Camera.enabled = true; // Enable Player 2's camera
        currentTarget = Player2Camera.transform;
        isTransitioning = true;
    }

    public void whoseTurn()
    {
        turn = !turn; //toggle the turn bool, switching camera view

        if (turn) //if turn is true, set player 1 camera to active
        {
            /*
            Player1Camera.SetActive(true);
            Player2Camera.SetActive(false);
            */
            Player1Camera.enabled = true;
            Player2Camera.enabled = false;
        }

        else //if turn is false, set player 2 camera to active
        {
            /*
            Player1Camera.SetActive(false);
            Player2Camera.SetActive(true);
            */
            Player1Camera.enabled = false;
            Player2Camera.enabled = true;
        }
        
        
    }

    
}

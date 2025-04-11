using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    // Variable for speed
    public float speed = 0;

    // Variable for the win counter
    public GameObject winTextObject;

    // Variable for the score counter
    public TextMeshProUGUI scoreText;

    // Rigidbody for player
    private Rigidbody rb;

    // Movement along x & y axis
    private float movementX;
    private float movementY;

    // Score counter
    private int count;

    // Start is called once before the first frame update
    void Start()
    {
        // Get and store player's rigidbody
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetScoreText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue){
        // Turn the movement value into a 2D vector
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the x & y components
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Create 3D movement using the information from the 2D movement vector
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the rigidbody to move the player
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter (Collider other){
        if(other.gameObject.CompareTag("Pickup")){
            // Set the object to invisible
            other.gameObject.SetActive(false);

            // Increment score
            count++;

            SetScoreText();
        }
        
    }

    void SetScoreText(){
        scoreText.text = "Score: " + count.ToString();
        if(count >= 12){
            // Show win screen
            winTextObject.SetActive(true);

            // Get rid of enemy
            if(gameObject != null){
                Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            }
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Enemy")){
            // Destroy the current object
            if(gameObject != null){
                Destroy(gameObject); 
            }
            
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
   }

   

    
}

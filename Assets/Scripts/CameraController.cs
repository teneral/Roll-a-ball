using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Stores a gameobject from the unity project.
    public GameObject player;

    // Creates a 3D vector to store the distance between the camera & player.
    private Vector3 offset;

    // Start is called before the first frame update.
    void Start()
    {
        // Calculate the initial offset between the camera & player
        if(player != null){
            offset = transform.position - player.transform.position;
        }
        
    }

    // Update is called once per frame after previous update functions are completed
    void LateUpdate()
    {
        // Maintain the same offset between camera & player throughout the game
        if(player != null){
            transform.position = player.transform.position + offset;
        }
    }
}

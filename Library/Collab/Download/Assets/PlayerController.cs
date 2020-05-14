using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSmoothing = 15f; // A smoothing value for turning the player.
    public float speedDampTime = 0.1f; // The damping for the speed parameter
    
    void Awake () {// Variables
    
        
    }
    void Update()
    {
         // Cache the inputs.
         float h = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
         float v = Input.GetAxis("Vertical");
 
         Rotating(h, v);
    }
    
 
     void Rotating (float horizontal, float vertical)
     {
         // Create a new vector of the horizontal and vertical inputs.
         Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
         
         targetDirection = Camera.main.transform.TransformDirection(targetDirection);
         targetDirection.y = 0.0f;
         
         transform.Rotate(targetDirection);

         transform.Translate(0, 0, vertical * Time.deltaTime * 3.0f);
     }
 
 }
    
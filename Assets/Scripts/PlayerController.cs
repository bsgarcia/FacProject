using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    
    public bool keyboardActivation = false;
    public bool bluetoothController = true;

    bool detectionDone = false;
    
    Dictionary<string, KeyCode> keyCodes = new Dictionary<string, KeyCode>();
    
    
    // each frame update
    void Update()
    {   
        // if input detection is not finished
        if (bluetoothController && !detectionDone) 
        {
            GetKey();
        }
        
        // if all keys are saved
        else if (bluetoothController && detectionDone)
        {
            if (Input.GetKey(keyCodes["up"]))
            {
                moveForward(speed);

            }

            else if (Input.GetKey(keyCodes["down"]))
            {

                moveBack(speed);

            }
        }
        
        if (keyboardActivation) {
            
             if (Input.GetKey("z"))
            {
                moveForward(speed);

            }

            else if (Input.GetKey("s"))
            {
                moveBack(speed);

            }
      
        }
    }
    
    private void GetKey() {
    
        // Little workaround to get inputs working with bluetooth controller
        // on android.
        // First check if all keys are not already registered
       
            // Iter on all keycodes
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {   
                // If the current key is pressed
                if (Input.GetKey(vKey))
                {   
                    // If first key to register, save it as "up"
                    if (vKey.ToString().Contains("Joystick") && keyCodes.Keys.Count == 0)
                    {
                        keyCodes.Add("up", vKey);
                        moveForward(speed);
                    }
                    
                    // If second key to register save it as down
                    else if (vKey.ToString().Contains("Joystick") && keyCodes.Keys.Count == 1
                    && vKey != keyCodes["up"])
                    {
                        keyCodes.Add("down", vKey);
                        moveBack(speed);
                        
                        // all keys are saved!
                        detectionDone = true;
                    }
                }
            }
    }
    
    private void moveForward(float speed) {
    
        // get camera orientation
        Vector3 direction = Camera.main.transform.forward;
        
        // fixed y
        direction.y = 0.0f;
        
        // move
        transform.position += direction * speed * Time.deltaTime;
    }

    private void moveBack(float speed) {
    
        // get camera orientation
        Vector3 direction = Camera.main.transform.forward;
        
        // fixed y
        direction.y = 0.0f;
        
        // inverse direction
        direction.x = -direction.x;
        direction.z = -direction.z;
        
        transform.position += direction * speed * Time.deltaTime;
    }

    private void moveRight(float speed) {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void moveLeft(float speed) {
        transform.position-= transform.right * speed * Time.deltaTime;
    }
  
}   
    
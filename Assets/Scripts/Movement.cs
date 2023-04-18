using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class Movement : MonoBehaviour
{
    Rigidbody2D playerrb;
    float movementSpeed = 5f;
    void OnEnable() {
        EnhancedTouchSupport.Enable();  
    }
    void Start()
    {
        playerrb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        TouchInput();   
    }

    public void Move(InputAction.CallbackContext context){
        playerrb.velocity = new Vector2(context.ReadValue<Vector2>().x * movementSpeed, 0);
    }

    public void TouchInput(){
        //Get all finger touches
        var fingers = UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers;
        //If there is no touch set veolocity to 0
        if(fingers.Count == 0){
            playerrb.velocity = new Vector2(0, 0);
            return;
        }
        //Get last touch
        var lastTouch = fingers[fingers.Count-1].lastTouch;
        //Get touch position
        Vector2 position = lastTouch.screenPosition;
        //Make the position correct - left side of screen will have negative x
        position -= new Vector2(Screen.width/2,0);
        if (position.x > 0){
            //If on the right side of screen, move toward positive x
            playerrb.velocity = new Vector2(movementSpeed, 0);
        }else{
            //Else move toward negative x
            playerrb.velocity = new Vector2(-movementSpeed, 0);
        }
    }
}

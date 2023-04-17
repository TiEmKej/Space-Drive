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
        Debug.Log(context.ReadValue<Vector2>().x);
        playerrb.velocity = new Vector2(context.ReadValue<Vector2>().x * movementSpeed, 0);
    }

    public void TouchInput(){
        var fingers = UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers;
        var lastTouch = fingers[fingers.Count-1].lastTouch;
        if(!lastTouch.isInProgress){
            playerrb.velocity = new Vector2(0, 0);
            return;
        }
        Vector2 position = lastTouch.screenPosition;
        position -= new Vector2(Screen.width/2,0);
        if (position.x > 0){
            //If on the right side of screen, move toward positive x
            playerrb.velocity = new Vector2(1f * movementSpeed, 0);
        }else{
            //Else move toward negative x
            playerrb.velocity = new Vector2(-1f * movementSpeed, 0);
        }
    }

    // public void MoveTouch(InputAction.CallbackContext context)
    // {
    //     Vector2 inputValue = context.ReadValue<Vector2>();
    //     if (context.phase == InputActionPhase.Performed){
    //         //If touch position is 0 (or not present), stop the player
    //         playerrb.velocity = new Vector2(0, 0);
    //         return;
    //     }
    //     //Check touch position
    //     inputValue -= new Vector2(Screen.width/2,0);
    //     if (inputValue.x > 0){
    //         //If on the right side of screen, move toward positive x
    //         playerrb.velocity = new Vector2(1f * movementSpeed, 0);
    //     }else{
    //         //Else move toward negative x
    //         playerrb.velocity = new Vector2(-1f * movementSpeed, 0);
    //     }
    // }
    
}

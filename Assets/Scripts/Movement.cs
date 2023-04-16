using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class Movement : MonoBehaviour
{
    Rigidbody2D playerrb;
    float movementSpeed = 5f;
    void OnEnable() {
        TouchSimulation.Enable();    
    }
    void Start()
    {
        playerrb = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context){
        Debug.Log(context.ReadValue<Vector2>().x);
        playerrb.velocity = new Vector2(context.ReadValue<Vector2>().x * movementSpeed, 0);
    }

    public void MoveTouch(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>().x);
        Vector2 inputValue = context.ReadValue<Vector2>();
        if(inputValue.x == 0)
        {
            playerrb.velocity = new Vector2(0, 0);
        }
        else if(inputValue.x < Screen.width/2)
        {
            playerrb.velocity = new Vector2(-1 * movementSpeed, 0);
        }
        else
        {
            playerrb.velocity = new Vector2(1 * movementSpeed, 0);
        }
    }
    
}

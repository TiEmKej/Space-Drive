using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context)
    { 
        Vector2 inputValue = (context.ReadValue<Vector2>());
        rb2d.velocity = new Vector2(inputValue.x * moveSpeed, 0);
    }

    public void MoveTouch(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();
        if(inputValue.x == 0)
        {
            rb2d.velocity = new Vector2(0, 0);
        }
        else if(inputValue.x < Screen.width/2)
        {
            rb2d.velocity = new Vector2(-1 * moveSpeed, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(1 * moveSpeed, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotion : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction jumpAction;

    public InputAction rollAction;

    private InputAction[] _actions;    
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        moveAction.performed += OnMove;
        jumpAction.performed += OnJump;
        rollAction.performed += OnRoll;
    }

    void OnMove(InputAction.CallbackContext context) {
        float magnitude = context.ReadValue<float>();
        if (magnitude < 0) {
            Debug.Log("Move left!");
        }
        else if (magnitude > 0) {
            Debug.Log("Move right!");
        }
    }

    void OnJump(InputAction.CallbackContext context) {
        Debug.Log("Jump!");
    }   

    void OnRoll(InputAction.CallbackContext context) {
        Debug.Log("Roll!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable() 
    {
        this._actions = new InputAction[] {this.moveAction, this.jumpAction, this.rollAction};
        foreach (InputAction action in this._actions) {
            action.Enable();
        }
    }

    void OnDisable()
    {
        foreach (InputAction action in this._actions) {
            action.Disable();
        }
    }
}

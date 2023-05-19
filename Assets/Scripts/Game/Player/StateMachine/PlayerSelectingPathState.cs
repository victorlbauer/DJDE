using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerSelectingPathState : PlayerBaseState
{
    public PlayerSelectingPathState(PlayerStateMachine sm) : base(sm) {}

    public override void Enter()
    {
        stateMachine.Input.OnInteract.performed += Select;
        stateMachine.Input.OnCancel.performed += Cancel;

        stateMachine.IsActing = true;
    }

    public override void Exit()
    {
        stateMachine.Input.OnCancel.performed -= Cancel;
        stateMachine.Input.OnInteract.performed -= Select;
    }

    public override void Update()
    {

    }

    private void Cancel(InputAction.CallbackContext context)
    {
        stateMachine.Choice = 9;
        stateMachine.IsActing = false;
    }
    
    private void Select(InputAction.CallbackContext context)
    {   
        stateMachine.Choice = 7;
        stateMachine.IsActing = false;
    }
}

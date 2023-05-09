using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerStartingState : PlayerBaseState
{
    public PlayerStartingState(PlayerStateMachine sm) : base(sm) {}

    public override void Enter()
    {
        stateMachine.Input.OnInteract.performed += HitDice;
    }

    public override void Exit()
    {
        stateMachine.Input.OnInteract.performed -= HitDice;
    }

    public override void Update()
    {
        // Play animation, etc
    }

    private void HitDice(InputAction.CallbackContext context)
    {
        stateMachine.SwitchState(stateMachine.Moving());
    }

    // private void OpenItemMenu(InputAction.CallbackContext context)
    // {
    //     stateMachine.SwitchState(stateMachine.)
    // }
}

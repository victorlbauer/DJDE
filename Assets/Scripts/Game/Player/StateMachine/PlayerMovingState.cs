using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMovingState : PlayerBaseState
{
    public PlayerMovingState(PlayerStateMachine sm) : base(sm) { }

    public override void Enter()
    {
        // int nSteps = EventManager.OnRollDice.Invoke();
        // Debug.Log("Dice roll: " + nSteps);

        // EventManager.OnMovePlayer.Invoke(nSteps);

        stateMachine.Input.OnInteract.performed += MoveExample;
    }

    public override void Exit()
    {
        stateMachine.Input.OnInteract.performed -= MoveExample;
    }

    public override void Update()
    {
        // play animation, step
        // if(isActing)
        //     return;

        // stateMachine.SwitchState(stateMachine.Playing());
    }

    public void MoveExample(InputAction.CallbackContext context)
    {
        int nSteps = EventManager.OnRollDice.Invoke();
        Debug.Log("Dice roll: " + nSteps);

        EventManager.OnMovePlayer.Invoke(stateMachine.PlayerInstance, nSteps);
    }
}

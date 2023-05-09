using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Core;

enum PlayerStates { IDLE, STARTING, MOVING, VIEWING_MAP, SELECTING_ITEM, SELECTING_OPTION, SELECTING_PATH }

public class PlayerStateMachine : NetworkBehaviour
{
    // Player
    private Player playerInstace;
    private PlayerInput input;

    // State variables
    private Dictionary<PlayerStates, PlayerBaseState> states = new Dictionary<PlayerStates, PlayerBaseState>();
    private PlayerBaseState currentState;

    // Getters and setters
    public PlayerInput Input => this.input;

    public Player PlayerInstance
    {
        get { return this.playerInstace; }
        set { this.playerInstace = value; }
    }

    public PlayerBaseState CurrentState 
    { 
        get { return this.currentState; } 
        set { this.currentState = value; }
    }

    // Public helper access functions
    public PlayerBaseState Idle()            => this.states[PlayerStates.IDLE];
    public PlayerBaseState Starting()        => this.states[PlayerStates.STARTING];
    public PlayerBaseState Moving()          => this.states[PlayerStates.MOVING];
    public PlayerBaseState ViewingMap()      => this.states[PlayerStates.VIEWING_MAP];
    public PlayerBaseState SelectingItem()   => this.states[PlayerStates.SELECTING_ITEM];
    public PlayerBaseState SelectingOption() => this.states[PlayerStates.SELECTING_OPTION];
    public PlayerBaseState SelectingPath()   => this.states[PlayerStates.SELECTING_PATH];
    
    public void SetState(PlayerBaseState state) => this.currentState = state;

    public void SwitchState(PlayerBaseState state)
    {
        this.currentState.Exit();
        this.currentState = state;
        this.currentState.Enter();
    }

    void Awake()
    {
        // Get the player's components
        this.input = gameObject.GetComponent<PlayerInput>();
        
        // Cache the states
        this.states[PlayerStates.IDLE]             = new PlayerIdleState(this);
        this.states[PlayerStates.STARTING]         = new PlayerStartingState(this);
        this.states[PlayerStates.MOVING]           = new PlayerMovingState(this);
        this.states[PlayerStates.VIEWING_MAP]      = new PlayerViewingMapState(this);
        this.states[PlayerStates.SELECTING_ITEM]   = new PlayerSelectingItemState(this);
        this.states[PlayerStates.SELECTING_OPTION] = new PlayerSelectingOptionState(this);
        this.states[PlayerStates.SELECTING_PATH]   = new PlayerSelectingPathState(this);

        // Set the initial state
        this.currentState = Idle();
    }

    // TODO: REMOVER
    void Start() => SwitchState(Moving());

    void Update()
    {
        if(!IsOwner)
            return;

        CurrentState.Update();
    }
}

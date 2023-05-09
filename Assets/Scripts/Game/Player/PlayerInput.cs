using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions input = null;

    // Public accessors to the player's actions
    public InputAction OnInteract => this.input.Player.Interact;

    void Awake() => this.input = new PlayerInputActions();
    private void OnEnable() => this.input.Enable();
    private void OnDisable() => this.input.Disable();
}

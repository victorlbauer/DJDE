using UnityEngine;
using System;
using Core;

public class EventManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameManager GM => gameManager;

    public static Func<int> OnRollDice;
    public static Action<Player, int> OnMovePlayer;

    void Awake()
    {
        this.gameManager = GetComponent<GameManager>();
    }

    void OnEnable()
    {
        OnRollDice += this.GM.GameActions.RollDice;
        OnMovePlayer += this.GM.GameActions.MovePlayer;
    }

    void OnDisable()
    {
        OnMovePlayer += this.GM.GameActions.MovePlayer;
        OnRollDice -= this.GM.GameActions.RollDice;
    }
}

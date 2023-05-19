using UnityEngine;
using System;
using Core;

public class EventManager : MonoBehaviour
{
    // Game related events
    private GameManager gm;

    public static Func<int> OnRollDice;
    public static Action<Player, int> OnMovePlayer;

    public static Action<Player, Tile> OnItemCollected;
    public static Action<Player, Tile> OnCreditsAdded;
    public static Action<Player, Tile> OnCreditsSubtracted;

    void Awake()
    {
        this.gm = GetComponent<GameManager>();
    }

    void OnEnable()
    {
        OnRollDice += this.gm.GameActions.RollDice;
        OnMovePlayer += this.gm.GameActions.MovePlayer;
        OnItemCollected += this.gm.GameActions.CollectItem;
        OnCreditsAdded += this.gm.GameActions.AddCredits;
        OnCreditsSubtracted += this.gm.GameActions.SubtractCredits;
    }

    void OnDisable()
    {
        OnRollDice -= this.gm.GameActions.RollDice;
        OnMovePlayer -= this.gm.GameActions.MovePlayer;
        OnItemCollected -= this.gm.GameActions.CollectItem;
        OnCreditsAdded -= this.gm.GameActions.AddCredits;
        OnCreditsSubtracted -= this.gm.GameActions.SubtractCredits;
    }
}

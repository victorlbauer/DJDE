using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using System.Linq;
using Core;

public class GameManager : NetworkBehaviour
{
    // Player
    private List<Player> players = new List<Player>();

    // Stage
    private Stage stage;
    
    // Gameplay
    private GameActions gameActions;

    // Getters and setters
    public List<Player> Players => this.players;
    public Stage Stage => this.stage;
    public GameActions GameActions => this.gameActions;

    void Awake()
    {
        // Player
        this.players.Add(new Player(Instantiate(Resources.Load(s_GameAssets.characters[s_MatchSettings.character]) as GameObject)));

        // Stage
        this.stage = new Stage(Instantiate(Resources.Load(s_GameAssets.stages[s_MatchSettings.stage]) as GameObject));

        // Actions
        this.gameActions = new GameActions(this);
    }
}

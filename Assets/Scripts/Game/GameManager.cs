using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using Core;

public class GameManager : MonoBehaviour
{
    // Server
    private ServerManager serverManager;

    // Player
    private List<Player> players;

    // Stage
    private Stage stage;
    
    // Gameplay
    private GameActions gameActions;

    // Getters and setters
    public ServerManager ServerManager => this.serverManager;
    public List<Player> Players => this.players;
    public Stage Stage => this.stage;
    public GameActions GameActions => this.gameActions;

    void Awake() => players = new List<Player>();

    void OnEnable()
    {
        // TODO: Refatorar
        // Player
        this.players.Add(new Player(Instantiate(Resources.Load(s_GameAssets.characters[s_MatchSettings.character]) as GameObject)));

        // Stage
        this.stage = new Stage(Instantiate(Resources.Load(s_GameAssets.stages[s_MatchSettings.stage]) as GameObject));

        // Actions
        this.gameActions = new GameActions(this);
    }
}

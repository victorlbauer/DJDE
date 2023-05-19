using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Core;
using System.Linq;

public class ServerManager : NetworkBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    private List<Player> players;

    [ServerRpc]
    public void SpawnPlayerServerRpc()
    {
        SpawnPlayerClientRpc();
    }

    [ClientRpc]
    public void SpawnPlayerClientRpc()
    {
        Debug.Log("Foobar");
        this.players.Add(new Player(Instantiate(Resources.Load(s_GameAssets.characters[s_MatchSettings.character]) as GameObject)));
        this.players.First().Instance.GetComponent<NetworkObject>().Spawn();
    }
}


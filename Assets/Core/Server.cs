using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Core;

public class ServerManager
{
    private GameManager gm;
    private NetworkObject server;

    public ServerManager(GameManager gm)
    {
        this.gm = gm;
    }

    [ServerRpc]
    public void SpawnPlayerServerRpc(ref GameObject player)
    {
        player.GetComponent<NetworkObject>().Spawn();
    }
}


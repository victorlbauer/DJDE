using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System;

public class GameActions
{
    private GameManager gm;

    public GameActions(GameManager gm)
    {
        this.gm = gm;
    }

    ~GameActions()
    {

    }

    public int RollDice() => new System.Random().Next(1, 7);

    public void MovePlayer(Player player, int nSteps) => gm.StartCoroutine(MoveCoroutine(player, nSteps));
    
    // TODO: Refatorar?
    IEnumerator MoveCoroutine(Player player, int nSteps)
    {
        // Get the stage reference
        Stage stage = gm.Stage;

        while(nSteps > 0)
        {
            int currentTileIdx = player.CurrentTileIdx;
            int nextTileIdx = stage.TilesList[currentTileIdx].NextTileIdx;

            Vector3 origin = player.Position;
            Vector3 destination = stage.TilesList[nextTileIdx].Position;

            // Lerp between the tiles, using the player's speed as the scaling factor
            float timeElapsed = 0.0f;
            while(timeElapsed < 1.0f)
            {
                player.Position = Vector3.Lerp(origin, destination, timeElapsed);
                timeElapsed += Time.deltaTime * 2.0f;
                yield return null;
            }

            // Set the player's position to the destination in order to avoid overshooting
            player.Position = destination;

            // Update the player's current tile index
            player.CurrentTileIdx = nextTileIdx;
            nSteps--;
        }
    }
}

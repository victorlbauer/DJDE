using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System;
using System.Threading.Tasks;
using System.Linq;

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
   
    public async void MovePlayer(Player player, int nSteps)
    {
        // Get the stage reference
        Stage stage = gm.Stage;

        // Current tile
        Tile currentTile = stage.TilesList[player.CurrentTileIdx];

        // First neighbouring tile
        Tile neighbourTile = stage.TilesList[currentTile.FirstNeighbourIdx];

        while(nSteps > 0)
        {
            Vector3 origin = currentTile.Position;
            Vector3 destination = neighbourTile.Position;

            // Lerp between the tiles, using the player's speed as the scaling factor
            float timeElapsed = 0.0f;
            while(timeElapsed < 1.0f)
            {
                player.Position = Vector3.Lerp(origin, destination, timeElapsed);
                timeElapsed += Time.deltaTime * player.Speed;
                await Task.Yield();
            }

            // Set the player's position to the destination, so we don't overshoot his position
            player.Position = destination;

            // We have arrived at the next tile. Update info for the next iteration
            currentTile = neighbourTile;
            player.CurrentTileIdx = currentTile.Idx;

            // Check if the tile is a stop point before that
            if(currentTile.IsStopPoint)
            {
                int selectedTileIdx = await SelectingPath(player);
                neighbourTile = stage.TilesList[selectedTileIdx];
                continue;
            }

            // Get the first neighbour for the next iteration
            neighbourTile = stage.TilesList[currentTile.FirstNeighbourIdx];

            // Steps are only valid for steppable tiles
            nSteps--;

        }
        
        // If current tile has events to be triggered
        if(currentTile.TileEvents.Any())
        {
            // Trigger all events, passing the player as reference
            foreach(var tileEvent in currentTile.TileEvents)
                tileEvent?.Invoke(player, currentTile);
        }
    }

    // TODO: refatorar para ser mais agnostico
    private async Task<int> SelectingPath(Player player)
    {
        player.StateMachine.SwitchState(player.StateMachine.SelectingPath());

        int idx = 0;
        bool selecting = true;
        while(selecting)
        {
            if(!player.StateMachine.IsActing)
            {
                idx = player.StateMachine.Choice;    
                selecting = false;
            }

            await Task.Yield();
        }

        player.StateMachine.SwitchState(player.StateMachine.Moving());

        return idx;
    }

    public void CollectItem(Player player, Tile tile)
    {
        // Check if someone grabbed the item already
        if(tile.Collectable == null)
            return;

        // Grab the item reference
        GameObject collectable = tile.Collectable;

        // Different types of items
        switch (collectable.GetComponent<ItemType>().Type)
        {
            case CollectableType.MEDAL:
                player.Medals++;
                break;
            default:
                Debug.Log("Player cannot collect this type of item!");
                break;
        }

        // Trigger UI event
        
        // Destroy item
        UnityEngine.Object.Destroy(collectable);
    }

    // public void CollectItem(Player p, Tile t)
    // {
    //     if(t.medal == null)
    //         return;

    //     GameObject item = t.medal;
    //     UnityEngine.Object.Destroy(item);
    // }

    public void AddCredits(Player player, Tile tile) => player.Credits += tile.PositiveCredits;

    public void SubtractCredits(Player player, Tile tile)
    {
        player.Credits += tile.NegativeCredits;
        
        if(player.Credits < 0)
            player.Credits = 0;
    }
}

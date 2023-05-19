using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Core
{
    public class Tile
    {
        private GameObject instance;

        // Getter and setters
        public GameObject Instance => this.instance;
        public Vector3 Position => this.instance.transform.position;

        // Board related variables
        public int Idx => this.instance.GetComponent<TileInfo>().Idx;
        public bool IsStopPoint => this.instance.GetComponent<TileInfo>().IsStopPoint;

        public List<int> NeighboursIdx => this.instance.GetComponent<TileInfo>().NeighboursIdx;
        public int FirstNeighbourIdx => NeighboursIdx.First();

        // Events
        public List<Action<Player, Tile>> TileEvents => this.instance.GetComponent<TileInfo>().tileEvents;

        // Credits, bonuses
        public int PositiveCredits => this.instance.GetComponent<TileInfo>().positiveCredits;
        public int NegativeCredits => this.instance.GetComponent<TileInfo>().negativeCredits;

        // Collectables
        public GameObject Collectable => this.instance.GetComponent<TileSpawner>().Item;

        public Tile(GameObject tile)
        {
            this.instance = tile;
        }

        ~Tile()
        {

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Stage
    {
        private GameObject instance;
        private List<Tile> tilesList;

        public GameObject Instance => this.instance;
        public List<Tile> TilesList => this.tilesList;

        public Stage(GameObject stage)
        {
            this.instance = stage;
            this.tilesList = GetTilesList();
        }

        ~Stage() {}

        private List<Tile> GetTilesList()
        {
            List<Tile> tilesList = new List<Tile>();

            foreach(Transform child in instance.transform)
            {
                if(child.CompareTag("Tile"))
                {
                    Tile tile = new Tile(child.gameObject);
                    tilesList.Add(tile);
                }
            }

            return tilesList;
        }
    }
}
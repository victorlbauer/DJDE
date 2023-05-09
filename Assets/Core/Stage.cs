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

        // public List<int> GetNextIdxList()
        // {
        //     List<int> idxList = new List<int>();

        //     foreach(Transform child in instance.transform)
        //     {
        //         if(child.CompareTag("Tile"))
        //             idxList.Add(child.gameObject.GetComponent<TileInfo>().nextTileIdx);
        //     }

        //     return idxList;
        // }

        // public List<Vector3> GetStartPositions()
        // {
        //     List<Vector3> startPosList = new List<Vector3>();

        //     foreach(Transform child in instance.transform)
        //     {
        //         if(child.CompareTag("StartPosition"))
        //             startPosList.Add(child.gameObject.transform.position);
        //     }

        //     return startPosList;
        // }
    }
}
using UnityEngine;

namespace Core
{
    public class Tile
    {
        private GameObject instance;
        private int nextTileIdx;

        public GameObject Instance => this.instance;
        public Vector3 Position => this.instance.transform.position;
        public int NextTileIdx => this.instance.GetComponent<TileInfo>().nextTileIdx;
 
        public Tile(GameObject tile)
        {
            this.instance = tile;
        }

        ~Tile()
        {

        }
    }
}
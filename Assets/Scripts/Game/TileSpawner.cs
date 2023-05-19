using UnityEngine;
using Core;

public class TileSpawner : MonoBehaviour
{
    public GameObject Item;

    void Awake()
    {
        if(Item != null)
            Item = Instantiate(Item, transform.position + new Vector3(0.0f, 1.5f, 0.0f), Quaternion.identity);
    }
}

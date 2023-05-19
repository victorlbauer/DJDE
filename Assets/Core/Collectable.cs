using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core
{
    public enum CollectableType { NULL, MEDAL }

    public class Collectable
    {
        private GameObject instance;
        private CollectableType type;

        public GameObject Instance => this.instance;
        public CollectableType Type => this.type;

        public Collectable(GameObject collectable)
        {
            this.instance = collectable;
            this.type = collectable.GetComponent<ItemType>().Type;
        }

        ~Collectable()
        {
            UnityEngine.Object.Destroy(this.instance);
        }
    }   
}

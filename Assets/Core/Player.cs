using UnityEngine;

namespace Core
{
    public class Player
    {
        private GameObject instance;
        private PlayerStateMachine stateMachine;
        private int currentTileIdx;

        // Getter and setters
        public GameObject Instance => this.instance;
        public PlayerStateMachine StateMachine => this.stateMachine;

        public int CurrentTileIdx
        {
            get { return this.currentTileIdx; }
            set { this.currentTileIdx = value; }
        }

        public Vector3 Position
        {
            get { return this.instance.transform.position; }
            set { this.instance.transform.position = value; }
        }

        public string Name => this.instance.GetComponent<PlayerInfo>().Name;
        public float Speed => this.instance.GetComponent<PlayerInfo>().Speed;

        public int Medals
        {
            get { return this.instance.GetComponent<PlayerInfo>().Medals; }
            set { this.instance.GetComponent<PlayerInfo>().Medals = value; }
        }
    
        public int Credits
        {
            get { return this.instance.GetComponent<PlayerInfo>().Credits; }
            set { this.instance.GetComponent<PlayerInfo>().Credits = value; }
        }

        public Player(GameObject player)
        {
            this.instance = player;

            this.stateMachine = this.instance.GetComponent<PlayerStateMachine>();
            this.stateMachine.PlayerInstance = this;

            this.currentTileIdx = 0;
        }

        ~Player()
        {

        }
    }
}

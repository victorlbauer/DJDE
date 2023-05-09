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

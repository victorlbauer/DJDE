using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Core;
using System;


public class TileInfo : MonoBehaviour
{
    public int Idx = 0;
    public bool IsStopPoint = false;
    public List<int> NeighboursIdx = new List<int>();

    // Connection between the Unity Events and the Event Manager
    public List<Action<Player, Tile>> tileEvents = new List<Action<Player, Tile>>();

    // Add functionality to your events via Unity Events
    [SerializeField] private UnityEvent addEvents;

    public void CollectItemEvent() => tileEvents.Add(EventManager.OnItemCollected);
    public void AddCreditsEvent() => tileEvents.Add(EventManager.OnCreditsAdded);
    public void SubtractCreditsEvent() => tileEvents.Add(EventManager.OnCreditsSubtracted);

    public int positiveCredits = 0;
    public int negativeCredits = 0;

    void Start()
    {
        addEvents?.Invoke();
    }
}

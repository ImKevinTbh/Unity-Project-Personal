using Assets;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickupHandler : MonoBehaviour
{
    public static PickupHandler instance = null;
    public Events Events = new Events();

    public List<GameObject> pickups = new List<GameObject>();
    public List<Vector3> spawnPoints = new List<Vector3>();
    public GameObject pickupPrefab;



    private void Awake()
    {
        instance = this;
        foreach (Vector3 spawnpoint in spawnPoints)
        {
            GameObject pickup = GameObject.Instantiate(pickupPrefab);
            pickup.AddComponent<PickupObject>();
            Events.Pickup += PickupCollected;
        }
    }

    public void PickupCollected(object sender, PickupEventArgs e)
    {

        Debug.Log("PICKED UP");

    }


}

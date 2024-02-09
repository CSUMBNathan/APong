using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTriggerScript : MonoBehaviour
{

    public int points;

    public int slotNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name} entered slot {name}");
        Debug.Log($"Entered slot {slotNumber} and scored {points} points");
    }
}

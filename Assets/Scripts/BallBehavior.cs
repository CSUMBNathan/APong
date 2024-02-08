using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 100f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    }

    void Start()
    {
        ResetPosition();
        AddStartForce();
    }

    public void ResetPosition()
    {
        rb.position = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    public void AddStartForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float z = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        
        rb.AddForce(new Vector3(x, 0, z) * speed);
    }
   
    void Update()
    {
        
    }
}

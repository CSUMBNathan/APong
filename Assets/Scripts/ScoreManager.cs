using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int leftScore = 0;
    private int rightScore = 0;

    void Start()
    {
        GameObject.FindGameObjectWithTag("LeftWall").GetComponent<BoxCollider>().isTrigger = true;
        GameObject.FindGameObjectWithTag("RightWall").GetComponent<BoxCollider>().isTrigger = true;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("Ball"))
        {
            if (other.transform.position.x < 0) // Left wall
            {
                rightScore++; 
            }
            else // Right wall
            {
                leftScore++; 
            }

            Debug.Log("Left Player Score: " + leftScore);
            Debug.Log("Right Player Score: " + rightScore);
        }
        
    }
}

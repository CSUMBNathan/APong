using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Collider spawnCollider = spawnTransform.GetComponent<Collider>(); 
            
            Bounds bounds = spawnCollider.bounds;
            
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);
            
            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);
            
            Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

        }
    }
}

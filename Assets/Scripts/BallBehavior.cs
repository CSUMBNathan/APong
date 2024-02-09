
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 500f;
    private float originalSpeed = 500f;
    
    private int leftScore = 0;
    private int rightScore = 0;

    private bool gameEnded = false;

    public float x;
    public float z;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if (gameEnded && Input.GetKeyDown(KeyCode.Space))
        {
            Start();
        }
    }

    void Start()
    {
        x = Random.value < 0.5f ? -1.0f : 1.0f;
        z = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        ResetPosition();
        AddStartForce();
    }

    public void ResetPosition()
    {
        speed = originalSpeed;
        rb.position = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    public void AddStartForce()
    {
        rb.AddForce(new Vector3(x, 0, z) * speed);
    }

    public void LaunchBallRight()
    {
        
        z = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        rb.AddForce(new Vector3(-1, 0, z) * speed);
    }

    public void LaunchBallLeft()
    {
        z = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        rb.AddForce(new Vector3(1, 0, z) * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector3 collisionDirection = -(collision.contacts[0].point - transform.position).normalized;

            speed += 50f;

            Vector3 newVelocity = collisionDirection * speed;

            rb.velocity = Vector3.zero;

            rb.AddForce(newVelocity);
        }
    }
       // if (collision.gameObject.CompareTag("Paddle"))
            /*
            float paddleSizeZ = collision.gameObject.transform.localScale.z; 
            float hitPosition = (transform.position.z - collision.transform.position.z) / (paddleSizeZ / 2f); 

            float maxReflectionAngle = 50f;
            float reflectionAngle = hitPosition * maxReflectionAngle;

            Debug.Log("Hit position: " + hitPosition);
            Debug.Log("Angle: " + reflectionAngle);

            // Reflect the velocity of the ball based on the reflection angle
            Vector3 newDirection = Quaternion.AngleAxis(reflectionAngle, Vector3.forward) * Vector3.right;
            Vector3 newVelocity = newDirection.normalized * speed;
            Debug.Log(newVelocity);
            
            rb.velocity = Vector3.zero;
            rb.AddForce(newVelocity, ForceMode.VelocityChange);
            */


            /*
             *  Vector3 newDirection = Quaternion.AngleAxis(reflectionAngle, Vector3.forward) * Vector3.right;
            Vector3 newVelocity = newDirection.normalized * speed;
            // Reflect the velocity of the ball based on the reflection angle
            rb.velocity = Vector3.zero;
            rb.velocity = newVelocity;
            //rb.AddForce(new Vector3(1, 0, 0) * speed);
             */
        
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightWall"))
        {
            leftScore++;

            Debug.Log("Left Player Scored!");
            Debug.Log("Left Player Score: " + leftScore);
            Debug.Log("Right Player Score: " + rightScore);

            if (leftScore >= 7)
            {
                EndGame("Left Player");
            }
            else
            {
                ResetPosition();
                LaunchBallRight();
            }
        }

        if (other.gameObject.CompareTag("LeftWall"))
        {
            rightScore++;

            Debug.Log("Right Player Scored!");
            Debug.Log("Left Player Score: " + leftScore);
            Debug.Log("Right Player Score: " + rightScore);

            if (rightScore >= 7)
            {
                EndGame("Right Player");
            }
            else
            {
                ResetPosition();
                LaunchBallLeft();
            }
        }
    }
    
    public void EndGame(string winner)
    {
        ResetPosition();
        Debug.Log("Game Over! " + winner + " Wins!");
        Debug.Log("Press Space to Play Again!");
        leftScore = 0;
        rightScore = 0;
        gameEnded = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlller : MonoBehaviour
{

    public float speed;
    private Vector3 direction;
    private Rigidbody rb;
    public float minDirection = 0.5f;

    private bool Stopped = true;

    public GameObject SparkVFX;
    
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();

        
    }

    
    void Update()
    {
        //transform.position += direction * speed * Time.deltaTime;   


    }

    private void FixedUpdate()
    {
        if (Stopped)
        { 
            return;
        }
        this.rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        bool hit = false;
        if (other.CompareTag("Wall"))

        {
            direction.z = -direction.z;
            hit = true;
        }

        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized; //  new direction = rowna sie pozycji pi³ki minus pozycja "other", normalized bo zosta ³o uzye=te speed

            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            direction = newDirection;

            hit = true;
        }

        if (hit)
        {
            GameObject sparks = Instantiate(this.SparkVFX, transform.position, transform.rotation);
            Destroy(sparks, 4f);
        }
    }

    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1, 1));
        float signZ = Mathf.Sign(Random.Range(-1, 1));

        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);
    }

    public void Stop()
    {
        this.Stopped = true;
        
    }
    public void Go()
    {
        ChooseDirection();
        this.Stopped = false;
    }
}

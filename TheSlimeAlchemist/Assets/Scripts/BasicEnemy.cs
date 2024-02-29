using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public HealthBarScript healthBarScript;
    Rigidbody2D rb;
    BoxCollider2D bc;
    public GameObject explosion;

    public GameObject pointA;
    public GameObject pointB;
    private Transform currentPoint;
    public float speed;
    //private Animator anim;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        currentPoint = pointA.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointA.transform)
        {
            rb.velocity = new Vector2(-speed, 0);
        } else
        {
            rb.velocity = new Vector2(speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 2f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 2f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 2f);
        Gizmos.DrawWireSphere(pointB.transform.position, 2f);
        Gizmos.DrawLine(pointB.transform.position, pointA.transform.position);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "collided");

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            healthBarScript.TakeDamage(10);
          
        }
        
    }
   

}

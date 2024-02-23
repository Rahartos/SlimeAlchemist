using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public HealthBarScript healthBarScript;
    Rigidbody2D rb;
    public GameObject explosion;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "collided");

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            healthBarScript.TakeDamage(20);
          
        }
        
    }
   

}

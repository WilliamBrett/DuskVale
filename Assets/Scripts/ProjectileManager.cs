using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private SpriteRenderer thisSR;
    private Transform thisTF;
    public SpriteRenderer PlayerRef;
    public float bulletSpeed;
    public bool direction;
    public Vector3 thisVel;
    public bool testbool;
    public float testrot;
    public bool isHostile;
    
    // Start is called before the first frame update
    void Start()
    {
        thisSR = GetComponent<SpriteRenderer>();
        thisTF = GetComponent<Transform>();
        if (thisTF.rotation.x == -1)
        {
            thisSR.flipX = true;
            thisVel = new Vector3(-bulletSpeed, 0, 0);
        }
        else
        {
            thisVel = new Vector3(bulletSpeed, 0, 0);
        }
        //determineBulletVelocity();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Time.timeScale == 0) { return; }
        thisTF.position += thisVel;
    }


    /*private void determineBulletVelocity()
    {
        thisVel = transform.rotation * new Vector3(bulletSpeed, 0, 0) ;
        
        if (direction)
        {
            
        }
        else
        {
            thisVel = new Vector3(-bulletSpeed, 0, 0);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHostile)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<HealthManager>().TakeDamage(1);
            }
            if (collision.tag != "Hostile" && collision.tag != "Intangible" && collision.tag != "Trigger")
            {
                Destroy(gameObject);
            }
        }
        else
        {
         if (collision.tag == "Hostile")
            {
                collision.GetComponent<HealthManager>().TakeDamage(1);
            }
            
            if (collision.tag != "Player" && collision.tag != "Intangible" && collision.tag != "Trigger")
            {
                Destroy(gameObject);
            }
        }
    }
}

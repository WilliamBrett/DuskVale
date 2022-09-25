using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private SpriteRenderer thisSR;
    private Transform thisTF;
    public SpriteRenderer PlayerRef;
    public float bulletSpeed;
    public bool direction;
    public Vector3 thisVel;
    public bool testbool;
    public float testrot;
    
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
    void Update()
    {
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
        if (collision.tag == "Hostile")
        {
            collision.GetComponent<HealthManager>().TakeDamage(1);
        }
        
        if (collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}

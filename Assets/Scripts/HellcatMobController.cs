using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellcatMobController : MonoBehaviour
{
    private SpriteRenderer thisSR;
    private Transform thisTF;
    private Vector3 thisVel;
    private HealthManager thisHealth;
    private Rigidbody2D thisRB2D;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        thisSR = GetComponent<SpriteRenderer>();
        thisTF = GetComponent<Transform>();
        thisHealth = GetComponent<HealthManager>();
        thisRB2D = GetComponent<Rigidbody2D>();
        if (thisTF.rotation.x == -1)
        {
            thisSR.flipX = true;
            thisVel = new Vector3(-speed, 0, 0);
        }
        else
        {
            thisVel = new Vector3(speed, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!thisHealth.dying)
        { 
            thisRB2D.velocity = new Vector2(speed, thisRB2D.velocity.y);
        }
        else
        {
            GetComponentInParent<HellcatController>().SpawnDelay = 1000000;
        }
        
    }


}

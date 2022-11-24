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
    private float curFade;
    public int mobTime;
    public HellcatController controllerRef;
    public int curHazardPot;

    // Start is called before the first frame update
    void Start()
    {
        thisSR = GetComponent<SpriteRenderer>();
        thisTF = GetComponent<Transform>();
        thisHealth = GetComponent<HealthManager>();
        thisRB2D = GetComponent<Rigidbody2D>();
        /*if (thisTF.rotation.x == -1)
        {
            thisSR.flipX = true;
            //thisVel = new Vector3(-speed, 0, 0);
        }*/
        /*else
        {
            thisVel = new Vector3(speed, 0, 0);
        }*/
        thisSR.color = new Color(1f, 1f, 1f, 0f);
        mobTime = 350;
        curFade = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!thisHealth.dying)
        { 
            if (mobTime > 250)
            {
                curFade += 0.01f;
                thisSR.color = new Color(1f, 1f, 1f, curFade);
            }
            else if (mobTime < 100)
            {
                if (mobTime < 0)
                {
                    Destroy(gameObject);
                }
                curFade -= 0.01f;
                thisSR.color = new Color(1f, 1f, 1f, curFade);
            }
            if (thisSR.flipX)
            {
                thisTF.position = new Vector3((thisTF.position.x + 0.07f) , thisTF.position.y, 0);
            }
            else
            {
                thisTF.position = new Vector3((thisTF.position.x - 0.07f), thisTF.position.y, 0);
            }
            mobTime--;
            //thisRB2D.velocity = new Vector2(speed, thisRB2D.velocity.y);
        }
        else if (controllerRef)
        {
            controllerRef.dead = true;
            controllerRef = null;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthManager>().TakeDamage(curHazardPot);
        }
    }

}

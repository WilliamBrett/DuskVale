using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public bool Awake;
    public bool Risen;
    public int MoveSpeed;
    private int RiseDelay;
    private Animator thisAnim;
    private BoxCollider2D thisBox;
    private CapsuleCollider2D thisCapsule;
    public GameObject PlayerRef;
    private Transform thisTF;
    private SpriteRenderer thisSprite;
    private Rigidbody2D thisRB2D;
    private HealthManager thisHealth;
    public int HazardPot;
    public int curHazardPot;

    
    // Start is called before the first frame update
    void Start()
    {
        thisAnim = this.GetComponent<Animator>();
        thisBox = this.GetComponent<BoxCollider2D>();
        thisCapsule = this.GetComponent<CapsuleCollider2D>();
        thisTF = this.GetComponent<Transform>();
        thisSprite = this.GetComponent<SpriteRenderer>();
        thisRB2D = this.GetComponent<Rigidbody2D>();
        thisHealth = this.GetComponent<HealthManager>();
        Awake = false;
        Risen = false;
        thisHealth.iframe = 999;
        curHazardPot = 0;
        RiseDelay = -1;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!thisHealth.dying) {
            if (RiseDelay > -1)
            {
                RiseDelay--;
                if (RiseDelay == 0)
                {
                    Risen = true;
                    thisAnim.SetBool("Risen", true);
                    curHazardPot = HazardPot;
                    thisHealth.iframe = 1;
                }
            }
            if (Risen)
            {
                if (PlayerRef != null)
                {
                    if (PlayerRef.GetComponent<Transform>().position.x - this.transform.position.x > 0) {
                        thisSprite.flipX = true;
                        thisRB2D.velocity = new Vector2(MoveSpeed, thisRB2D.velocity.y);
                    }
                    else
                    {
                        thisSprite.flipX = false;
                        thisRB2D.velocity = new Vector2(-MoveSpeed, thisRB2D.velocity.y);

                    }

                }
                else
                {
                    thisHealth.iframe = 0;
                    thisHealth.TakeDamage(999);
                }
            }
            else
            {
                thisHealth.iframe = 999;
            }
        }
        else
        {
            curHazardPot = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthManager>().TakeDamage(curHazardPot);
        }
    }

    public void WakeUp()
    {
        Awake = true;
        thisAnim.SetBool("Awake", true);
        RiseDelay = 25;
        GameObject[] PlayerSearch = GameObject.FindGameObjectsWithTag("Player");
        if (PlayerSearch.Length != 0)
        {
            PlayerRef = PlayerSearch[0];
        }
    }
}

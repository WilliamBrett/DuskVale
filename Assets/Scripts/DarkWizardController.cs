using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWizardController : MonoBehaviour
{
    public bool Awake;//unused
    public bool Risen;//unused
    public int MoveSpeed;//unused
    private int RiseDelay;//unused
    private Animator thisAnim;//unused
    private BoxCollider2D thisBox;//unused
    private CapsuleCollider2D thisCapsule;//unused
    public GameObject PlayerRef;
    private Transform PCTF;
    private Transform thisTF;//unused
    private SpriteRenderer thisSprite;//unused
    private Rigidbody2D thisRB2D;//unused
    private HealthManager thisHealth;//unused
    public int HazardPot;//unused
    public int curHazardPot;//unused
    public int attackCooldown;
    public GameObject Fireball;
    public bool LeftRight; //Left is false, Right is True
    public Transform LeftFirePoint;
    public Transform RightFirePoint;


    // Start is called before the first frame update
    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        thisAnim = GetComponent<Animator>();
        attackCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PCTF && attackCooldown == 0)
        {
            if (PlayerRef.GetComponent<Transform>().position.x - this.transform.position.x > 0)
            {
                thisSprite.flipX = true; //fireball speed = x
            }
            else
            {
                thisSprite.flipX = false; //fireball speed = -x

            }

        }
        else
        {
            GameObject[] PCs = GameObject.FindGameObjectsWithTag("Player");
            if (PCs.Length != 0)
            {
                PlayerRef = PCs[0];
                PCTF = PlayerRef.GetComponent<Transform>();
            }
        }
        if (attackCooldown >= 1)
        {
            attackCooldown--;
            if (attackCooldown == 195)
            {
                thisAnim.SetInteger("AttackPhase", 2);
            }
            else if (attackCooldown == 190)
            {
                thisAnim.SetInteger("AttackPhase", 3);
            }
            else if (attackCooldown == 185)
            {
                thisAnim.SetInteger("AttackPhase", 4);
            }
            if (attackCooldown == 180)
            {
                thisAnim.SetInteger("AttackPhase", 5);
            }
            if (attackCooldown == 175)
            {
                thisAnim.SetInteger("AttackPhase", 6);
            }
            if (attackCooldown == 170)
            {
                thisAnim.SetInteger("AttackPhase", 7);
            }
            if (attackCooldown == 165)
            {
                thisAnim.SetInteger("AttackPhase", 8);
                if (LeftRight)
                {
                    Instantiate(Fireball, RightFirePoint.position, RightFirePoint.rotation);
                }
                else
                {
                    Instantiate(Fireball, LeftFirePoint.position, LeftFirePoint.rotation);
                }
            }
            else if (attackCooldown == 160)
            {
                thisAnim.SetInteger("AttackPhase", 0);
            }
        }
    }

    public void FireRight()
    {
        if (attackCooldown == 0)
        {
            LeftRight = true;
            attackCooldown = 200;
            thisAnim.SetInteger("AttackPhase", 1);
        }
    }

    public void FireLeft()
    {
        if (attackCooldown == 0)
        {
            LeftRight = false;
            attackCooldown = 200;
            thisAnim.SetInteger("AttackPhase", 1);
        }
    }
}

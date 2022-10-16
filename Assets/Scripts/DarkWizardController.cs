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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PCTF)
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
    }

    public void Fire()
    {
        //Instantiate(Bullet, FirePointLeft.position, FirePointLeft.rotation);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool Alter;

    public GameObject[] Metadata;
    public Rigidbody2D thisRB2D;
    private Animator thisAnim;
    public SpriteRenderer thisSR;
    public Transform thistf;
    public Transform BottomPoint;
    public Transform FirePointRight;
    public Transform FirePointLeft;
    public Transform FirePointBottomRight;
    public Transform FirePointBottomLeft;
    public Transform GripL;
    public Transform GripR;
    public LayerMask Ground;
    public float moveSpeed;
    public float jumpForce;
    public string SpawnID;

    public bool DJReady;
    public bool DashReady;
    private int AnimLock;
    private bool onGround;
    public bool Crouching;
    public int afterShotDelay;

    public bool testbool;

    public GameObject Bullet;

    public bool DJUnlocked;
    public bool DashUnlocked;
    public bool WJUnlocked;
    public int MaxHP;

    public string DebugCommand;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        thisRB2D = this.GetComponent<Rigidbody2D>();
        thisSR = this.GetComponent<SpriteRenderer>();
        thisAnim = this.GetComponent<Animator>();
        thistf = this.GetComponent<Transform>();
        AnimLock = 0;
        ZoneIn();
    }

    private void OnLevelWasLoaded(int level)
    {
        ZoneIn();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Time.timeScale == 0) { return; }
        if (!(Crouching || afterShotDelay != 0 || AnimLock != 0)) {
            HorizontalMove(Input.GetAxis("Horizontal"));
        }
        else if (AnimLock > 0)
        {
            AnimLock--;
        }
        onGround = Physics2D.OverlapCircle(BottomPoint.position, 0.3f, Ground);
        if (onGround)
        {
            DJReady = true;
            DashReady = true;
        }
        else
        {
            if ((Input.GetButtonDown("Dash") || DebugCommand == "Dash") && DashUnlocked)
            {
                Dash();
            }
        }
        if (Input.GetButtonDown("Jump") || DebugCommand == "Jump")
        {
            Jump(Input.GetAxis("Vertical"));
        }
        else if (Input.GetButtonUp("Jump") && thisRB2D.velocity.y > 0)
        {
            thisRB2D.velocity = new Vector2(thisRB2D.velocity.y, (thisRB2D.velocity.y / 2));
        }

        if ((Input.GetButtonDown("Fire1") || DebugCommand == "Fire") && afterShotDelay == 0 && (thisRB2D.velocity.x == 0 || Crouching))
        {
            if (!Alter)
            {
                FireBullet();
            }
            else
            {

            }
        }
        else if (afterShotDelay > 0)
        {
            afterShotDelay--;
        }
        VerticalMove(Input.GetAxis("Vertical"));
         if (thisRB2D.velocity.x > 0.1)
        {
            thisSR.flipX = false;
        }
        else if (thisRB2D.velocity.x < -0.1)
        {
            thisSR.flipX = true;
        }
        thisAnim.SetFloat("moveSpeedY", thisRB2D.velocity.y);
        thisAnim.SetBool("onGround", onGround);
        thisAnim.SetFloat("moveSpeedX", Math.Abs(thisRB2D.velocity.x));
        thisAnim.SetFloat("afterShotDelay", afterShotDelay);
        thisAnim.SetBool("Crouching", Crouching);
    }

    public void ZoneIn()
    {
        Metadata = GameObject.FindGameObjectsWithTag("Metadata");
        if (Metadata.Length != 0)
        {
            thistf.position = Metadata[0].GetComponent<MetadataRecord>().GetSpawn(SpawnID);
        }
        else //error handling for cells without a metadata
        {
            thistf.position = new Vector3(0, 0, 0);
        }
        afterShotDelay = 0;
    }

    public void HorizontalMove(float HAxis)
    {
            thisRB2D.velocity = new Vector2(moveSpeed * HAxis, thisRB2D.velocity.y);
        if (DebugCommand != null)
        {
            if (DebugCommand == "MoveLeft")
            {
                thisRB2D.velocity = new Vector2(moveSpeed * -1, thisRB2D.velocity.y);
            }
            else if (DebugCommand == "MoveRight")
            {
                thisRB2D.velocity = new Vector2(moveSpeed * 1, thisRB2D.velocity.y);
            }
            
        }
    }

    public void Jump(float VAxis)
    {
        if (VAxis >= 0 && afterShotDelay == 0)
        {
            Crouching = false;
            if (onGround)
            {
                thisRB2D.velocity = new Vector2(thisRB2D.velocity.x, jumpForce);
            }
            else if (WJUnlocked && Physics2D.OverlapCircle(GripR.position, 0.2f, Ground))
            {
                thisRB2D.velocity = new Vector2(-moveSpeed * 2, jumpForce);
                DJReady = true;
                AnimLock = 15;
            }
            else if (WJUnlocked && Physics2D.OverlapCircle(GripL.position, 0.2f, Ground))
            {
                thisRB2D.velocity = new Vector2(moveSpeed * 2, jumpForce);
                AnimLock = 15;
                DJReady = true;
            }
            else if (DJReady && DJUnlocked && AnimLock == 0)
            {
                thisRB2D.velocity = new Vector2(thisRB2D.velocity.x, jumpForce);
                DJReady = false;
            }
        }
    }

    public void Dash()
    {
        if (thisSR.flipX == true)
        {
            thisRB2D.velocity = new Vector2(moveSpeed * -5, 0);
        }
        else
        {
            thisRB2D.velocity = new Vector2(moveSpeed * 5, 0);
        }
        AnimLock = 30;
    }

    public void FireBullet()
    {
        if (thisSR.flipX)
        {
            if (!Crouching){
                Instantiate(Bullet, FirePointLeft.position, FirePointLeft.rotation);
            }
            else
            {
                Instantiate(Bullet, FirePointBottomLeft.position, FirePointBottomLeft.rotation);
            }

        }
        else
        {
            if (!Crouching)
            {
                Instantiate(Bullet, FirePointRight.position, FirePointRight.rotation);
            }
            else
            {
                Instantiate(Bullet, FirePointBottomRight.position, FirePointBottomRight.rotation);
            }

        }
        afterShotDelay = 10;
    }

    public void AlterAttack()
    {

    }

    public void VerticalMove(float VAxis)
    {
        if (VAxis >= 0 || DebugCommand == "Crouch")
        {
            Crouching = false;
        }
        else if (onGround)
        {
            thisRB2D.velocity = new Vector2(0, 0);
            Crouching = true;
        }
    }
}

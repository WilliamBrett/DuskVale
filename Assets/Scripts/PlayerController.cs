using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] Metadata;
    private Rigidbody2D thisRB2D;
    private Animator thisAnim;
    private SpriteRenderer thisSR;
    public Transform thistf;
    public Transform BottomPoint;
    public LayerMask Ground;
    public float moveSpeed;
    public float jumpForce;
    public string SpawnID;

    public bool DJReady;
    private bool onGround;
    private bool jumping;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        thisRB2D = this.GetComponent<Rigidbody2D>();
        thisSR = this.GetComponent<SpriteRenderer>();
        thisAnim = this.GetComponent<Animator>();
        thistf = this.GetComponent<Transform>();
    }


    // Start is called before the first frame update
    void Start()
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
    }

    // Update is called once per frame
    void Update()
    {
        thisRB2D.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), thisRB2D.velocity.y);
        onGround = Physics2D.OverlapCircle(BottomPoint.position, 0.2f, Ground);
        if (Input.GetButtonDown("Jump"))
        {

            if (onGround)
            {
                thisRB2D.velocity = new Vector2(thisRB2D.velocity.x, jumpForce);
                DJReady = true;

            }
            else if (DJReady)
            {
                thisRB2D.velocity = new Vector2(thisRB2D.velocity.x, jumpForce);
                DJReady = false;
            }
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (thisRB2D.velocity.y > 0)
            {
                thisRB2D.velocity = new Vector2(thisRB2D.velocity.y, (thisRB2D.velocity.y/ 2));
            }
        }

        if (thisRB2D.velocity.x > 0)
        {
            thisSR.flipX = false;
        }
        else if (thisRB2D.velocity.x < 0)
        {
            thisSR.flipX = true;
        }

        thisAnim.SetFloat("moveSpeedY", thisRB2D.velocity.y);
        thisAnim.SetBool("onGround", onGround);
        thisAnim.SetFloat("moveSpeedX", Math.Abs(thisRB2D.velocity.x));

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelController : MonoBehaviour
{
    private Rigidbody2D thisRB2D;
    private Animator thisAnim;
    private Transform thisTF;
    private int pendulum;
    private int TriggerDelay;
    private Vector2 momentum;
    public float momentumConstant = 1f;
    private float preferedY;
    private float preferedY2;
    private int Attacking;
    public int AttackDelay;

    //thisRB2D.velocity = new Vector2(MoveSpeed, thisRB2D.velocity.y);
    // Start is called before the first frame update
    void Start()
    {
        thisRB2D = this.GetComponent<Rigidbody2D>();
        thisAnim = this.GetComponent<Animator>();
        thisTF = this.GetComponent<Transform>();
        preferedY = this.GetComponent<Transform>().position.y;
        preferedY2 = preferedY - 10f;
        TriggerDelay = 0;
        Attacking = 0;
    }

    // Update is called once per frame
    void Update() //CHANGE Rigidbody's GRAVITY SCALE
    {
        if (TriggerDelay > 0)
        {
            TriggerDelay--;
            if (TriggerDelay == 0)
            {
                Attacking = 1;
                AttackDelay = 100;
                thisAnim.SetInteger("Attacking", 1);
            }
        }
        else if (Attacking != 0)
        {
            if (Attacking == 1)
            {
                AttackDelay--;
                thisTF.position = new Vector3(thisTF.position.x, (thisTF.position.y - ((thisTF.position.y - preferedY2) / 50)), 0);
                if (AttackDelay == 0)
                {
                    AttackDelay = 100;
                    Attacking = 2;
                }
            }
            else
            {
                AttackDelay--;
                thisTF.position = new Vector3(thisTF.position.x, (thisTF.position.y - ((thisTF.position.y - preferedY) / 50)), 0);
                if (AttackDelay == 0)
                {
                    thisAnim.SetInteger("Attacking", 0);
                    Attacking = 0;
                }
            }

        }


        //thisRB2D.velocity = new Vector2(thisRB2D.velocity.x, thisRB2D.velocity.y);
        //thisRB2D.velocity = new Vector2(0, 0);
        //thisAnim.SetInteger("Animation", 1);

    } 

    public void Trigger()
    {
            TriggerDelay = 100;
    }
}

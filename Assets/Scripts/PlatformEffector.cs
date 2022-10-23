using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEffector : MonoBehaviour
{
    private PlatformEffector2D thisEffect;
    private CompositeCollider2D thisCollider;
    private GameObject[] PlayerReg;
    private CapsuleCollider2D PlayerRef;
    private PlayerController PCRef;
    //private int playerLayer

    // Start is called before the first frame update
    void Start()
    {
        thisEffect = GetComponent<PlatformEffector2D>();
        //thisCol = this.GetComponent>
        PlayerReg = GameObject.FindGameObjectsWithTag("Player");
        if (PlayerReg.Length != 0)
        {
            PlayerRef = PlayerReg[0].GetComponent<CapsuleCollider2D>();
        }
        thisCollider = this.GetComponent<CompositeCollider2D>();
        PCRef = PlayerRef.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") < 0 || PCRef.DebugCommand == "Crouch")
        {
            thisEffect.colliderMask &= ~(1 << 9);
        }
        else
        {
            thisEffect.colliderMask |= (1 << 9);

        }
    }
}


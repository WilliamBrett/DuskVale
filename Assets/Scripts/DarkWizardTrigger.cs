using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWizardTrigger: MonoBehaviour
{
    public bool LeftRight; //Left is false, Right is True
    public bool testbool;
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fire(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        testbool = true;
        Fire(collision);
    }

    private void Fire(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (LeftRight)
            {
                GetComponentInParent<DarkWizardController>().FireRight();
            }
            else
            {
                GetComponentInParent<DarkWizardController>().FireLeft();
            }  
        }
    }
}

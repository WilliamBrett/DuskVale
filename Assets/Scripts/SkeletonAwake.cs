using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAwake : MonoBehaviour
{
    public bool testbool;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponentInParent<SkeletonController>().WakeUp();
            this.gameObject.SetActive(false);
        }   
    }
}

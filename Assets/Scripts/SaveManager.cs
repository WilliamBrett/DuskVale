using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private GameObject PlayerRef;
    private BoxCollider2D thisZone;

    public void Start()
    {
        thisZone = this.GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        //check collission, check press up
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerRef = collision.gameObject;
        }
    }
}
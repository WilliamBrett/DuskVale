using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelHitbox : MonoBehaviour
{
    private int curHazardPot;
    // Start is called before the first frame update
    void Start()
    {
        curHazardPot = GetComponentInParent<AngelController>().curHazardPot; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthManager>().TakeDamage(curHazardPot);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterStrike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hostile")
            {
                collision.GetComponent<HealthManager>().TakeDamage(1);
            }
    }
}

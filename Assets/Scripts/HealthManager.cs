using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currenthealth, maxhealth;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int i)
    {
        currenthealth -= i;
        //knockback?
        if (currenthealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
        //UI health mod if player health. 
    }
}

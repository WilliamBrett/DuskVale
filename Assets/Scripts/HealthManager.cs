using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currenthealth, maxhealth, deathTime;
    private int deathDelay;
    private Animator thisAnim;
    public bool dying;
    public int iframe;

    // Start is called before the first frame update
    void Start()
    {
        thisAnim = this.GetComponent<Animator>();
        currenthealth = maxhealth;
        dying = false;
        iframe = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (iframe > 0)
        {
            iframe--;
        }
        if (deathDelay > 0)
        {
            deathDelay--;
            if (deathDelay == 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void TakeDamage(int i)
    {
        if (iframe == 0)
        {
            currenthealth -= i;
            iframe = (i * 100);
            //knockback?
            if (currenthealth <= 0)
            {
                if (this.tag == "Player")
                {
                    this.gameObject.SetActive(false);
                }
                else if (this.tag == "Hostile")
                {
                    this.deathDelay = deathTime;
                    thisAnim.SetBool("Dying", true);
                }
            }
        }
        //UI health mod if player health. 
    }
}

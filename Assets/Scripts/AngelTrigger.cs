using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelTrigger : MonoBehaviour
{
    private int AttackDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackDelay--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (AttackDelay < 0)
        {
            AttackDelay = 500;
            this.GetComponentInParent<AngelController>().Trigger();
        }
    }
}

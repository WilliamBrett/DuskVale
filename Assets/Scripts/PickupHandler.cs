using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    public int pickupId;
    private GameObject PlayerRef;
    private PlayerRecord PCRecordRef;
    //pickupId 1 = red potion / restore health
    //pickupId 2 = /double jump unlock
    //pickupId 3 = /wall jump unlock
    //pickupId 4 = /dash unlock

    // Start is called before the first frame update
    void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
        PCRecordRef = PlayerRef.GetComponentInChildren<PlayerRecord>();
        switch (pickupId)
        {
            /*case 1://restore health
                return;*/
            case 2://double jump unlock
                if (PCRecordRef.DJUnlocked)
                {
                    Destroy(gameObject);
                }
                return;
            case 3://wall jump unlock
                if (PCRecordRef.WJUnlocked)
                {
                    Destroy(gameObject);
                }
                return;
            case 4://dash unlock
                if (PCRecordRef.DashUnlocked)
                {
                    Destroy(gameObject);
                }
                return;
            default:
                return;


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    //PlayerRef.GetComponentInChildren<PlayerRecord>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //PlayerRef = collision;
            switch (pickupId)
            {
                case 1:
                    PlayerRef.GetComponent<HealthManager>().RestoreHealth(3);
                    Destroy(gameObject);
                    return;
                case 2: //double jump unlock
                    PlayerRef.GetComponent<PlayerController>().DJUnlocked = true;
                    PCRecordRef.DJUnlocked = true;
                    Destroy(gameObject);
                    return;
                case 3: //wall jump unlock
                    PlayerRef.GetComponent<PlayerController>().DJUnlocked = true;
                    PCRecordRef.DJUnlocked = true;
                    Destroy(gameObject);
                    return;
                case 4: //dash unlock
                    PlayerRef.GetComponent<PlayerController>().DJUnlocked = true;
                    PCRecordRef.DJUnlocked = true;
                    Destroy(gameObject);
                    return;
                default:
                    Destroy(gameObject);
                    return;
            }
        }

        
    }
    

}

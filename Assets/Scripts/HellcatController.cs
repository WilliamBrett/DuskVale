using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellcatController : MonoBehaviour
{
    public bool triggerRight;
    public GameObject Mob;
    public Transform LeftSpawn;
    public Transform RightSpawn;
    public int SpawnDelay;


    
    // Start is called before the first frame update
    void Start()
    {
        SpawnDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnDelay--;
        if (SpawnDelay > 10000)//change to give a few seconds for hellcat to die
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<HellcatController>().Trigger(triggerRight);
    }

    public void Trigger(bool isRight)
    {
        if (isRight)
        {
            Instantiate(Mob, RightSpawn.position, RightSpawn.rotation);
        }
        else
        {
            Instantiate(Mob, LeftSpawn.position, LeftSpawn.rotation);
        }
    }

}

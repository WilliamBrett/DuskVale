using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellcatController : MonoBehaviour
{
    public bool triggerRight;
    public HellcatController Twin;
    public GameObject Mob;
    public Transform Spawn;
    public int SpawnDelay;
    public GameObject MobRef;
    public bool dead;


    
    // Start is called before the first frame update
    void Start()
    {
        SpawnDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Destroy(gameObject);
        }
        SpawnDelay--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerRight && (SpawnDelay <= 0))
        {
            MobRef = Instantiate(Mob, Spawn.position, Spawn.rotation);
            MobRef.GetComponent<SpriteRenderer>().flipX = true;
            MobRef.GetComponent<HellcatMobController>().controllerRef = this;
            SpawnDelay = 500;
            Twin.SpawnDelay = 500;
        }
        else if (SpawnDelay <= 0)
        {
            MobRef = Instantiate(Mob, Spawn.position, Spawn.rotation);
            MobRef.GetComponent<SpriteRenderer>().flipX = false;
            MobRef.GetComponent<HellcatMobController>().controllerRef = this;
            SpawnDelay = 500;
            Twin.SpawnDelay = 500;
        }
    }

}

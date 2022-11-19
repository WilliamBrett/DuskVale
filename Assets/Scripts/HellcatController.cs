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
        if (triggerRight && (SpawnDelay <= 0))
        {
            Instantiate(Mob, Spawn.position, Spawn.rotation);
            SpawnDelay = 500;
            Twin.SpawnDelay = 500;
        }
    }

}

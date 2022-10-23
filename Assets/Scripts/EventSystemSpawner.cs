using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemSpawner : MonoBehaviour
{
    public GameObject EventSystemRef;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] EVs = GameObject.FindGameObjectsWithTag("EventSystem");
        if (EVs.Length == 0)
        {
            Instantiate(EventSystemRef, new Vector3(0, 0, 0), new Quaternion()); //test
        }
    }
}

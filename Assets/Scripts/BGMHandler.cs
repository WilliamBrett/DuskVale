using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMHandler : MonoBehaviour
{
    private AudioSource thisAS;
    //AUDIO SOURCE AS VARIABLE, VAR.Play() to PLAY
    // Start is called before the first frame update
    void Start()
    {
        thisAS = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerMaxHealth"))
        {
            this.GetComponent<Image>().color = Color.gray;
            this.GetComponent<Button>().enabled = false;
        }  
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
 
    public GameObject StartMenu;
    public GameObject StartText;
    public int TextDelay;
    // Start is called before the first frame update
    void Start()
    {
        TextDelay = 100;
        StartMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TextDelay--;
        if (TextDelay <= 0)
        {
            StartText.SetActive(!StartText.activeInHierarchy);
            TextDelay = 100;
        }
        if (Input.GetButtonDown("Dash") | Input.GetButtonDown("Jump"))
        {
            SetStartMenu();
        }
    }

    public void SetStartMenu()
    {
        StartMenu.SetActive(true);
        gameObject.SetActive(false);
    }

}

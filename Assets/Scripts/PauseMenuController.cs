using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject PlayerRef;
    //private GameObject EventSystemRef;
    public bool isPaused;
    public GameObject PauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerRef)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }
        else
            {
            GameObject[] PCs = GameObject.FindGameObjectsWithTag("Player");
            if (PCs.Length != 0)
            {
                PlayerRef = PCs[0];
                //EventSystemRef = GameObject.FindGameObjectWithTag("EventSystem");
            }
        } 
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            isPaused = true;
        }
    }

    public void OptionsButton()
    {
        //not implimented
    }

    public void TitleButton()
    { 
        //destroy all persistent objects
        Destroy(PlayerRef);
        //Destroy(EventSystemRef);
        SceneManager.LoadScene("TitleMenu");
        Destroy(gameObject);
    }

    public void ExitButton() => Application.Quit();
}

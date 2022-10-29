using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject PlayerRef;
    //private GameObject EventSystemRef;
    public bool isPaused;
    public GameObject PauseMenu;
    public GameObject ResumeButtonRef, OptionsButtonRef, TitleButtonRef, QuitButtonRef, HowToPlayButtonRef;
    public GameObject HTPScreen;
    public bool HowToPlayIntro;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;
        Time.timeScale = 0f;
        //PauseMenu.SetActive(false);
        HowToPlayOpen();
        HowToPlayIntro = true;
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
        if (HTPScreen.activeInHierarchy)
        {
            HowToPlayClose();
        }
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

    public void HowToPlayOpen()
    {
        DisableButton(ResumeButtonRef);
        DisableButton(OptionsButtonRef);
        DisableButton(TitleButtonRef);
        DisableButton(QuitButtonRef);
        DisableButton(HowToPlayButtonRef);
        HTPScreen.SetActive(true);
    }

    public void HowToPlayClose()
    {
        EnableButton(ResumeButtonRef);
        EnableButton(OptionsButtonRef);
        EnableButton(TitleButtonRef);
        EnableButton(QuitButtonRef);
        EnableButton(HowToPlayButtonRef);
        HTPScreen.SetActive(false);
        if (HowToPlayIntro)
        {
            HowToPlayIntro = false;
            TogglePause();
        }
    }

    public void DisableButton(GameObject toDisable)
    {
        toDisable.GetComponent<Image>().color = Color.gray;
        toDisable.GetComponent<Button>().enabled = false;
    }

    public void EnableButton(GameObject toEnable)
    {
        toEnable.GetComponent<Image>().color = Color.white;
        toEnable.GetComponent<Button>().enabled = true;
    }
}

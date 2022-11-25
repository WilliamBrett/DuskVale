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
    public GameObject OptionsScreen;
    public GameObject GameOverScreen;
    public GameObject SavePrompt;
    public GameObject DJInfo;
    public GameObject WJInfo;
    public GameObject DashInfo;
    public bool HowToPlayIntro;
    
    // Start is called before the first frame update
    void Start()
    {
        //isPaused = true;
        //Time.timeScale = 0f;
        //PauseMenu.SetActive(false);
        //HowToPlayOpen();
        //HowToPlayIntro = true;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerRef)
        {
            if (!PlayerRef.activeSelf)
            {
                GameOverScreen.SetActive(true);
                PlayerRef = null;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (SavePrompt.activeSelf)
                {
                    SavePromptOpenClose();
                }
                else
                {
                    TogglePause();
                }

            }
        }
        else {
            GameObject[] PCs = GameObject.FindGameObjectsWithTag("Player");
            if (PCs.Length != 0)
            {
                PlayerRef = PCs[0];
                //EventSystemRef = GameObject.FindGameObjectWithTag("EventSystem");
            }
        } 
    }

    private void OnLevelWasLoaded(int level)
    {
        if (GameObject.FindGameObjectWithTag("SavePoint"))
        {
            GameObject.FindGameObjectWithTag("SavePoint").GetComponent<SaveManager>().PauseRef = this;
        }
        GameObject[] Pickups = GameObject.FindGameObjectsWithTag("Pickup");
        if (Pickups.Length != 0)
        {
            for (int count = 0; count < Pickups.Length; count++){
                Pickups[count].GetComponent<PickupHandler>().PauseRef = this;
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
            DisableButton(OptionsButtonRef);
            PauseMenu.SetActive(true);
            isPaused = true;
        }
    }

    public void OptionsButton()
    {
        //not implimented
    }

    public void OptionsOpen()
    {
        DisableButton(ResumeButtonRef);
        DisableButton(OptionsButtonRef);
        DisableButton(TitleButtonRef);
        DisableButton(QuitButtonRef);
        DisableButton(HowToPlayButtonRef);
        OptionsScreen.SetActive(true);
    }

    public void OptionsClose()
    {
        EnableButton(ResumeButtonRef);
        EnableButton(OptionsButtonRef);
        EnableButton(TitleButtonRef);
        EnableButton(QuitButtonRef);
        EnableButton(HowToPlayButtonRef);
        OptionsScreen.SetActive(false);
    }

    public void TitleButton()
    { 
        //destroy all persistent objects
        Destroy(PlayerRef);
        //Destroy(EventSystemRef);
        Time.timeScale = 1f;
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

    public void SavePromptOpenClose()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            SavePrompt.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            SavePrompt.SetActive(true);
        }
    }

    public void forwardSaveRequest()
    {
        GameObject.FindGameObjectWithTag("SavePoint").GetComponent<SaveManager>().SaveGame();
        SavePromptOpenClose();
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

    public void UnlockedOpenClose(int UnlockId)
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            switch (UnlockId)
            {
                case 2:
                    DJInfo.SetActive(false);
                    return;
                case 3:
                    WJInfo.SetActive(false);
                    return;
                case 4:
                    DashInfo.SetActive(false);
                    return;
            }
            
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
            switch (UnlockId)
            {
                case 2:
                    DJInfo.SetActive(true);
                    return;
                case 3:
                    WJInfo.SetActive(true);
                    return;
                case 4:
                    DashInfo.SetActive(true);
                    return;
            }
        }
    }
}

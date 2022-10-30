using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public GameObject PlayerPresetRef;
    public GameObject CanvasPresetRef;
    public GameObject SpawnedPlayerRef;
    public GameObject SpawnedCanvasRef;
    private PlayerController ControllerRef;
    private int MaxHP;
    private bool DJUnlocked;
    private bool DashUnlocked;
    private bool WJUnlocked;
    public PlayerRecord RecordRef;

    
    // Start is called before the first frame update
    /*void Start()
    {
        LoadGame();
    }*/


    public void LoadGame()
    {
        PlayerPresetRef = Resources.Load("Player", typeof(GameObject)) as GameObject;
        SpawnPlayer();
        RecordRef = SpawnedPlayerRef.GetComponentInChildren<PlayerRecord>();
        ControllerRef = SpawnedPlayerRef.GetComponent<PlayerController>();
        SpawnedCanvasRef.GetComponent<PauseMenuController>().PauseMenu.SetActive(false);
        SpawnedCanvasRef.GetComponent<PauseMenuController>().isPaused = false;
        ControllerRef.SpawnID = "S";
        if (PlayerPrefs.HasKey("PlayerMaxHealth"))
        {
            MaxHP = PlayerPrefs.GetInt("PlayerMaxHealth");

        }
        else MaxHP = 5;
        if (PlayerPrefs.HasKey("PlayerDJUnlocked"))
        {
            DJUnlocked = TranslateBool(PlayerPrefs.GetInt("PlayerDJUnlocked"));
        }
        else
        {
            DJUnlocked = false;
        }
        if (PlayerPrefs.HasKey("PlayerDashUnlocked"))
        {
            DashUnlocked = TranslateBool(PlayerPrefs.GetInt("PlayerDashUnlocked"));
        }
        else
        {
            DashUnlocked = false;
        }
        if (PlayerPrefs.HasKey("PlayerWJUnlocked"))
        {
            WJUnlocked = TranslateBool(PlayerPrefs.GetInt("PlayerWJUnlocked"));
        }
        else
        {
            WJUnlocked = false;
        }
        RecordRef.SetupRecord(DJUnlocked, DashUnlocked, WJUnlocked, MaxHP);
        if (PlayerPrefs.HasKey("SceneName"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("SceneName"));
        }
        else
        {
            SceneManager.LoadScene("FortCell1");
        }
    }

    public void NewGame()
    {
        SpawnPlayer();
        if (SpawnedPlayerRef.Equals(null))
        {
            return;
        }
        RecordRef = SpawnedPlayerRef.GetComponentInChildren<PlayerRecord>();
        ControllerRef = SpawnedPlayerRef.GetComponent<PlayerController>();
        ControllerRef.SpawnID = "S";
        MaxHP = 5;
        DJUnlocked = TranslateBool(0);
        DashUnlocked = TranslateBool(0);
        WJUnlocked = TranslateBool(0);
        RecordRef.SetupRecord(DJUnlocked, DashUnlocked, WJUnlocked, MaxHP);
        Time.timeScale = 0f;
        SpawnedCanvasRef.GetComponent<PauseMenuController>().HowToPlayOpen();
        SpawnedCanvasRef.GetComponent<PauseMenuController>().isPaused = true;
        SpawnedCanvasRef.GetComponent<PauseMenuController>().HowToPlayIntro = true;
        SceneManager.LoadScene("FortCell2");
        
    }

    public bool TranslateBool(int inInt)
    {
        switch (inInt)
        {
            case 1:
                return true;
            case 0:
                return false;
            default:
                return false;
        }
    }

    private void SpawnPlayer()
    {
        SpawnedPlayerRef = Instantiate(PlayerPresetRef, new Vector3(0, 0, 0), new Quaternion());
        SpawnedCanvasRef = Instantiate(CanvasPresetRef, new Vector3(0, 0, 0), new Quaternion()); 
    }
}

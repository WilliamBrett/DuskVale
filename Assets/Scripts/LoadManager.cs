using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public GameObject PlayerPresetRef;
    public GameObject SpawnedPlayerRef;
    private PlayerController ControllerRef;
    private int MaxHP;
    private bool DJUnlocked;
    private bool DashUnlocked;
    private bool WJUnlocked;
    public PlayerRecord RecordRef;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }


    public void LoadGame()
    {
        SpawnPlayer();
        if (SpawnedPlayerRef.Equals(null))
        {
            return;
        }
        RecordRef = SpawnedPlayerRef.GetComponentInChildren<PlayerRecord>();
        ControllerRef = SpawnedPlayerRef.GetComponent<PlayerController>();
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
    }
}
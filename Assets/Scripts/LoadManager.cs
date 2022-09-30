using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public GameObject PlayerPresetRef;
    public GameObject SpawnedPlayerRef;
    public PlayerController ControllerRef;
    public HealthManager HealthRef;
    
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
        ControllerRef = SpawnedPlayerRef.GetComponent<PlayerController>();
        HealthRef = SpawnedPlayerRef.GetComponent<HealthManager>();
        ControllerRef.SpawnID = "S";
        if (PlayerPrefs.HasKey("PlayerMaxHealth"))
        {
            HealthRef.maxhealth = PlayerPrefs.GetInt("PlayerMaxHealth");
        }
        else HealthRef.maxhealth = 5;
        if (PlayerPrefs.HasKey("PlayerDJUnlocked"))
        {
            ControllerRef.DJUnlocked = TranslateBool(PlayerPrefs.GetInt("PlayerDJUnlocked"));
        }
        else
        {
            ControllerRef.DJUnlocked = false;
        }
        if (PlayerPrefs.HasKey("PlayerDashUnlocked"))
        {
            ControllerRef.DashUnlocked = TranslateBool(PlayerPrefs.GetInt("PlayerDashUnlocked"));
        }
        else
        {
            ControllerRef.DashUnlocked = false;
        }
        if (PlayerPrefs.HasKey("PlayerWJUnlocked"))
        {
            ControllerRef.WJUnlocked = TranslateBool(PlayerPrefs.GetInt("PlayerWJUnlocked"));
        }
        else
        {
            ControllerRef.WJUnlocked = false;
        }
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

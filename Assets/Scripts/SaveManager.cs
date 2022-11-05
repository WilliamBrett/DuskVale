using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    private GameObject PlayerRef;
    public GameObject SavePrompt;
    private BoxCollider2D thisZone;
    public string SpawnId;
    public int SaveDelay;
    public string thisSceneName;
    public PlayerRecord RecordRef;
    public bool testbool;
    public bool promptGray;

    public void Start()
    {
        thisZone = this.GetComponent<BoxCollider2D>();
        Scene cScene = SceneManager.GetActiveScene();
        thisSceneName = cScene.name;
        promptGray = false;
        SaveDelay = 0;
    }

    public void Update()
    {
        SaveDelay--;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (promptGray)
        {
            SavePrompt.GetComponent<SpriteRenderer>().color = Color.white;
            promptGray = false;
        }
        else
        {
            SavePrompt.GetComponent<SpriteRenderer>().color = Color.gray;
            promptGray = true;
        }
        if ((collision.gameObject.CompareTag("Player")) && (Input.GetAxis("Vertical") > 0))
        {
            /*if ((SaveDelay < 0) && (RecordRef != null))
            {
                SaveGame();
                SaveDelay = 1000;
                testbool = true;
            }*/
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseMenuController>().SavePromptOpenClose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerRef = collision.gameObject;
            RecordRef = PlayerRef.GetComponentInChildren<PlayerRecord>();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SavePrompt.GetComponent<SpriteRenderer>().color = Color.white;
        promptGray = false;
        SavePrompt.SetActive(false);
    }

    public void SaveGame()
    {
        PlayerPrefs.SetString("SceneName", thisSceneName);
        PlayerPrefs.SetInt("PlayerMaxHealth", RecordRef.MaxHP);
        PlayerPrefs.SetInt("PlayerDJUnlocked", TranslateBool(RecordRef.DJUnlocked));
        PlayerPrefs.SetInt("PlayerDashUnlocked", TranslateBool(RecordRef.DashUnlocked));
        PlayerPrefs.SetInt("PlayerWJUnlocked", TranslateBool(RecordRef.WJUnlocked));
        PlayerPrefs.Save();
    }

    public int TranslateBool(bool inBool)
    {
        switch (inBool)
        {
            case true:
                return 1;
            case false:
                return 0;
        }
    }

}
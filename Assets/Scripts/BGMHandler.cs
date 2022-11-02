using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMHandler : MonoBehaviour
{
    private bool BGMLoaded;
    private GameObject CurBGM;
    public GameObject TitleBGM;
    public GameObject FortBGM;
    public GameObject SwampBGM;
    public GameObject GraveBGM;
    public GameObject ChapelBGM;
    //private AudioSource thisAS;
    //AUDIO SOURCE AS VARIABLE, VAR.Play() to PLAY
    // Start is called before the first frame update

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DetermineBGM();
        //thisAS = this.GetComponent<AudioSource>();
    }

    private void OnLevelWasLoaded(int level)
    {
        DetermineBGM();
        //ZoneIn();
    }

    public void DetermineBGM()
    {
        BGMLoaded = false;
        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleMenu":
                CurBGM = TitleBGM;
                return;
            default:
                CurBGM = null;
                return;
        }
        //SceneManager.GetActiveScene().name;
        /*switch (SpawnID)
        {
            case "A":
                return SpawnA != null ? SpawnA : SpawnDefault;
            case "B":
                return SpawnB != null ? SpawnB : SpawnDefault;
            case "C":
                return SpawnC != null ? SpawnC : SpawnDefault;
            case "D":
                return SpawnD != null ? SpawnD : SpawnDefault;
            case "S":
                return LoadSavePointTF();
            case null://error handling
                return SpawnDefault;
            default://error handling
                return SpawnDefault;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (!BGMLoaded)
        {
            //fade
            //if fully faded, destroy
            //delay
            //start next song
        }
    }
}

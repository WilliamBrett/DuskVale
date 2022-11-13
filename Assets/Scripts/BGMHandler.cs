using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMHandler : MonoBehaviour
{
    private bool BGMLoaded;
    private AudioSource CurBGM;
    private GameObject CurBGMPlayer;
    public string curBGM;
    public GameObject TitleBGM;
    public GameObject FortBGM;
    public GameObject SwampBGM;
    public GameObject GraveBGM;
    public GameObject ChapelBGM;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        BGMLoaded = false;
    }

    private void OnLevelWasLoaded(int level)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleMenu":
                if ((curBGM) != "Title") BGMLoaded = false; 
                return;
            case "FortCell1":
                if ((curBGM) != "Fort") BGMLoaded = false;
                return;
            case "FortCell2":
                if ((curBGM) != "Fort") BGMLoaded = false;
                return;
            case "FortCell3":
                if ((curBGM) != "Fort") BGMLoaded = false;
                return;
            case "FortCell4":
                if ((curBGM) != "Fort") BGMLoaded = false;
                return;
            case "FortCell5":
                if ((curBGM) != "Fort") BGMLoaded = false;
                return;
            case "SwampCell1":
                if ((curBGM) != "Swamp") BGMLoaded = false;
                return;
            case "SwampCell2":
                if ((curBGM) != "Swamp") BGMLoaded = false;
                return;
            case "SwampCell3":
                if ((curBGM) != "Swamp") BGMLoaded = false;
                return;
            case "SwampCell4":
                if ((curBGM) != "Swamp") BGMLoaded = false;
                return;
            case "SwampCell5":
                if ((curBGM) != "Swamp") BGMLoaded = false;
                return;
            case "SwampCell6":
                if ((curBGM) != "Swamp") BGMLoaded = false;
                return;
            case "GraveCell1":
                if ((curBGM) != "Grave") BGMLoaded = false;
                return;
            case "GraveCell2":
                if ((curBGM) != "Grave") BGMLoaded = false;
                return;
            case "GraveCell3":
                if ((curBGM) != "Grave") BGMLoaded = false;
                return;
            case "GraveCell4":
                if ((curBGM) != "Grave") BGMLoaded = false;
                return;
            case "GraveCell5":
                if ((curBGM) != "Grave") BGMLoaded = false;
                return;
            default:
                BGMLoaded = false;
                return;
        }
       
    }

    public void ChooseBGM()
    {
        
        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleMenu":
                curBGM = "Title";
                StartBGM(TitleBGM);
                return;
            case "FortCell1":
                curBGM = "Fort";
                StartBGM(FortBGM);
                return;
            case "FortCell2":
                curBGM = "Fort";
                StartBGM(FortBGM);
                return;
            case "FortCell3":
                curBGM = "Fort";
                StartBGM(FortBGM);
                return;
            case "FortCell4":
                curBGM = "Fort";
                StartBGM(FortBGM);
                return;
            case "FortCell5":
                curBGM = "Fort";
                StartBGM(FortBGM);
                return;
            case "SwampCell1":
                curBGM = "Swamp";
                StartBGM(SwampBGM);
                return;
            case "SwampCell2":
                curBGM = "Swamp";
                StartBGM(SwampBGM);
                return;
            case "SwampCell3":
                curBGM = "Swamp";
                StartBGM(SwampBGM);
                return;
            case "SwampCell4":
                curBGM = "Swamp";
                StartBGM(SwampBGM);
                return;
            case "SwampCell5":
                curBGM = "Swamp";
                StartBGM(SwampBGM);
                return;
            case "SwampCell6":
                curBGM = "Swamp";
                StartBGM(SwampBGM);
                return;
            case "GraveCell1":
                curBGM = "Grave";
                StartBGM(GraveBGM);
                return;
            case "GraveCell2":
                curBGM = "Grave";
                StartBGM(GraveBGM);
                return;
            case "GraveCell3":
                curBGM = "Grave";
                StartBGM(GraveBGM);
                return;
            case "GraveCell4":
                curBGM = "Grave";
                StartBGM(GraveBGM);
                return;
            case "GraveCell5":
                curBGM = "Grave";
                StartBGM(GraveBGM);
                return;
            default:
                CurBGMPlayer = null;
                CurBGM = null;
                BGMLoaded = true;
                return;
        }
    }

    public void StartBGM(GameObject ChosenBGM)
    {
        CurBGMPlayer = Instantiate(ChosenBGM, new Vector3(0, 0, 0), new Quaternion());
        CurBGM = CurBGMPlayer.GetComponent<AudioSource>();
        CurBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!BGMLoaded)
        {
            if (CurBGMPlayer)
            {
                if (CurBGM.volume > 0) {
                    CurBGM.volume -= 0.02f;
                }
                else
                {
                    BGMLoaded = true;
                    Destroy(CurBGMPlayer);
                    ChooseBGM();
                    
                }
            }
            else
            {
                BGMLoaded = true;
                ChooseBGM();
                
            }
           
        }
    }
}

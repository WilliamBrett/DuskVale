using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMHandler : MonoBehaviour
{
    private bool BGMLoaded;
    private AudioSource CurBGM;
    private GameObject CurBGMPlayer;
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
        BGMLoaded = false;
    }

    public void ChooseBGM()
    {
        
        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleMenu":
                StartBGM(TitleBGM);
                return;
            default:
                CurBGMPlayer = null;
                CurBGM = null;
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

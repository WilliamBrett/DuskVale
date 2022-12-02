using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReferenceLedger : MonoBehaviour
{
    //Intro Menu
    public GameObject StartButton;
    public GameObject NewGameButton;
    public GameObject LoadGameButton;
    //TestCell
    public GameObject Skeleton1;
    public GameObject Skeleton2;
    public GameObject Alter;

    public void SpawnAlter()
    {
        Instantiate(Alter, new Vector3(0, 0, 0), new Quaternion());
    }
   
}

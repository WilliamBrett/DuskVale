using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetadataRecord : MonoBehaviour
{
    public float CameraXMax;
    public float CameraXMin;
    public float CameraYMax;
    public float CameraYMin;
    public GameObject FarScenery;
    public GameObject MidScenery;
    private Vector3 SpawnDefault;
    public Vector3 SpawnA;
    public Vector3 SpawnB;
    public Vector3 SpawnC;
    public Vector3 SpawnD;

    private void Start()
    {
        SpawnDefault.Set(0,0,0);   
    }
    public Vector3 GetSpawn(string SpawnID)
    {
        switch (SpawnID)
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
        }       
    }

    private Vector3 LoadSavePointTF()
    {
        GameObject[] SPs = GameObject.FindGameObjectsWithTag("SavePoint");
        if (SPs.Length != 0)
        {
            return SPs[0].GetComponent<Transform>().position;
        }
        else //error handling
        {
            return SpawnDefault;
        }
    }
}

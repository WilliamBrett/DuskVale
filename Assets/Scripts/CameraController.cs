using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject[] Metadata;
    private Transform CameraPos;
    public Transform PlayerPos;
    public Transform FarScenery;
    public Transform MidScenery;
    public float CameraXMax;
    public float CameraXMin;
    public float CameraYMax;
    public float CameraYMin;
    private float xCord;
    private float yCord;
    
    // Start is called before the first frame update
    void Start()
    {
        this.CameraPos = this.GetComponent<Transform>();
        //using the tag "metadata", the cell's camera settings are retrieved
        Metadata = GameObject.FindGameObjectsWithTag("Metadata");
        if (Metadata.Length != 0)
        {
            CameraXMax = Metadata[0].GetComponent<MetadataRecord>().CameraXMax;
            CameraXMin = Metadata[0].GetComponent<MetadataRecord>().CameraXMin;
            CameraYMax = Metadata[0].GetComponent<MetadataRecord>().CameraYMax;
            CameraYMin = Metadata[0].GetComponent<MetadataRecord>().CameraYMin;
        }
        //metadata camera setting error handling
        if (CameraXMax.Equals(null))
        {
            CameraXMax = 9999;
        }
        if (CameraXMax.Equals(null))
        {
            CameraXMin = -9999;
        }
        if (CameraXMax.Equals(null))
        {
            CameraYMax = 9999;
        }
        if (CameraXMax.Equals(null))
        {
            CameraYMin = 9999;
        }

    }

    // Update is called once per frame
    void Update()
    {
        xCord = PlayerPos.position.x;
        yCord = PlayerPos.position.y;

        if (xCord >= CameraXMax)
        {
            xCord = CameraXMax;
        }
        else if (xCord <= CameraXMin)
        {
            xCord = CameraXMin;
        }
        if (yCord >= CameraYMax)
        {
            yCord = CameraYMax;
        }
        else if (yCord <= CameraYMin)
        {
            yCord = CameraYMin;
        }

        Vector3 newCameraPos = new Vector3(xCord, yCord, CameraPos.position.z);
        Vector3 newFarSceneryPos = new Vector3(xCord, yCord, FarScenery.position.z);
        Vector3 changeCameraPos = new Vector3(newCameraPos.x - CameraPos.position.x, newCameraPos.y - CameraPos.position.y, newCameraPos.z - CameraPos.position.z);
        CameraPos.position = newCameraPos;
        MidScenery.position = new Vector3(MidScenery.position.x + (changeCameraPos.x / 2), MidScenery.position.y, MidScenery.position.z);
        FarScenery.position = newFarSceneryPos;
        
    }
}

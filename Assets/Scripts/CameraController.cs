using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform CameraPos;
    public Transform PlayerPos;
    public Transform FarScenery;
    
    // Start is called before the first frame update
    void Start()
    {
        this.CameraPos = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPos = new Vector3(PlayerPos.position.x, PlayerPos.position.y, CameraPos.position.z);
        Vector3 newFarSceneryPos = new Vector3(PlayerPos.position.x, FarScenery.position.y, FarScenery.position.z);
        Vector3 changeCameraPos = new Vector3(newCameraPos.x - CameraPos.position.x, newCameraPos.y - CameraPos.position.y, newCameraPos.z - CameraPos.position.z);
        CameraPos.position = newCameraPos;
        FarScenery.position = newFarSceneryPos;
    }
}

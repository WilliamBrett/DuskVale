using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CellPathway : MonoBehaviour
{
    private GameObject[] PlayerRef;
    public string ConnectedCell;
    public string ConnectedSpawn;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerRef = GameObject.FindGameObjectsWithTag("Player");
            if (PlayerRef.Length != 0)
            {
                PlayerRef[0].GetComponent<PlayerController>().SpawnID = ConnectedSpawn;
                //PlayerRef[0].GetComponent<PlayerController>();
                SceneManager.LoadScene(ConnectedCell);
            }
        }
        
    }
}

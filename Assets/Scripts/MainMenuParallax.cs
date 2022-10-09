using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuParallax : MonoBehaviour
{
    public Transform SiblingTF;
    private Transform ThisTF;
    private Rigidbody2D thisRB2D;

    private void Start()
    {
        thisRB2D = GetComponent<Rigidbody2D>();
        ThisTF = GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        thisRB2D.velocity = new Vector2(3, thisRB2D.velocity.y);
        if (this.transform.position.x > 28)
        {
            this.transform.position = new Vector3(SiblingTF.position.x - 28, ThisTF.position.y, 0);
        }
    }
}

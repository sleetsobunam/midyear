using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("down"))
        {
            this.transform.position += new Vector3(0,0,-0.05f);
        }

        if (Input.GetKey("up"))
        {
            this.transform.position += new Vector3(0,0,0.05f);
        }

        if (Input.GetKey("left"))
        {
            this.transform.position += new Vector3(-0.05f, 0, 0);
        }

        if (Input.GetKey("right"))
        {
            this.transform.position += new Vector3(0.05f,0,0);
        }
    }
}

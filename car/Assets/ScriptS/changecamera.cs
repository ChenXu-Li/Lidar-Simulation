using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changecamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera a;
    public Camera b;
    public Camera c;
    void Start()
    {
        a.enabled = true;
        b.enabled = false;
        c.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("camera");
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            a.enabled = true;
            b.enabled = false;
            c.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            a.enabled = false;
            b.enabled = true;
            c.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            a.enabled = false;
            b.enabled = false;
            c.enabled = true;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            a.transform.Rotate(-Vector3.up * Time.deltaTime * 30);
        }
        if (Input.GetKey(KeyCode.E))
        {
            a.transform.Rotate(Vector3.up * Time.deltaTime * 30);
        }
    }
}

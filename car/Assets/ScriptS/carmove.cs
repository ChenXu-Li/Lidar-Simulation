using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmove : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed = 5f;
    public float RotateSpeed = 10f;
    //bool can_rotate = false;
   // public Camera c;//为了保证俯视摄像头不旋转，转弯时摄像头反向旋转；
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))//只有前进或后退时才能转向
        {

            this.transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Rotate(-Vector3.up * Time.deltaTime * RotateSpeed);
               // c.transform.Rotate(-Vector3.forward* Time.deltaTime * RotateSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
                //c.transform.Rotate(Vector3.forward * Time.deltaTime * RotateSpeed);
            }

        }
        if (Input.GetKey(KeyCode.S))
        {

            this.transform.Translate(-Vector3.forward * Time.deltaTime * MoveSpeed);
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Rotate(-Vector3.up * Time.deltaTime * RotateSpeed);
               // c.transform.Rotate(-Vector3.forward * Time.deltaTime * RotateSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
               // c.transform.Rotate(Vector3.forward * Time.deltaTime * RotateSpeed);
            }

        }
        /*if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(-Vector3.up * Time.deltaTime * RotateSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
        }*/
    }
}

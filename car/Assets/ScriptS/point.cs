using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    public int existTime = 1;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void turn_disactive()
    {
        gameObject.SetActive(false);
        Debug.Log("disactive!!!!!!!!!");
    }
    private void OnEnable()
    {
        // Destroy(gameObject, 3.0f);
        Invoke("turn_disactive", existTime);
    }

}

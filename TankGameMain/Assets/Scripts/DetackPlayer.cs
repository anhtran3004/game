using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetackPlayer : MonoBehaviour
{
    public bool isDetect = false;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("tank1") || collision.CompareTag("tank2"))
        {
            isDetect = true;
            Debug.Log("Status" + isDetect);
        }
    }
    private void Update()
    {
        Detect();
    }
    public bool Detect()
    {

        return isDetect;
    }
}

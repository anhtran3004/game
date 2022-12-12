using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateController : MonoBehaviour
{
    /*public GameObject enemy;
    public GameObject player;*/
    public float speedRotate = 3600;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // enemy.transform.LookAt(player.transform.position);
        obj.transform.Rotate(0f, 0f, speedRotate * 0.05f * Time.deltaTime, Space.Self); ;
    }
}

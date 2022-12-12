using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    private bool getHeart = false;
    private bool isAppear = true;
    private float currentLoad = 5f;
    private float reloadTime = 5f;
    public GameObject heart;
    private void Start()
    {
        /*var positon = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-3.5f, 3.5f), 0);
        Instantiate(heart, positon, Quaternion.identity);*/
        //Instantiate(heart, new Vector3(-1f,1f,0), Quaternion.identity);
    }
    private void Update()
    {
        /*if(isAppear == false)
        {
            */
            if (getHeart == false)
            {
                currentLoad -= Time.deltaTime;
                //Debug.Log("time" + currentLoad);
                if (currentLoad <= 0)
                {
                    getHeart = true;
                }
            }
            if (getHeart)
            {
                currentLoad = reloadTime;
                getHeart = false;
                /*if (!heart)
                {*/
                    var positon = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-3.5f, 3.5f), 0);
                    //Instantiate(heart, positon, Quaternion.identity);
                    //isAppear = true;
               // }

            }
        //}
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("meo meo " + collision.name);
        if (!collision.CompareTag("bullet"))
        {
            Destroy(heart);
            isAppear = false;
        }
    }
}

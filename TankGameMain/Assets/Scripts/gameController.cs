using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject door;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player2.activeSelf == false && enemy3.activeSelf == false && enemy1.activeSelf == false && enemy2.activeSelf == false)
        {
            //Instantiate(door, new Vector2(-3f, -1.5f), Quaternion.identity);
            door.SetActive(true);
        }
        if(player1.activeSelf == false)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }
    }
}

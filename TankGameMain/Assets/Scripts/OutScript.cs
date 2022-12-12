using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutScript : MonoBehaviour
{
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ui.SetActive(true);
    }
    public void playAgain()
    {
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("TankGame");
    }
}

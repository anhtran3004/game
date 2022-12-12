using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject barrels;
    public GameObject bullet;
    public GameObject bulletExplode;
    private bool canShoot = false;
    private float currentLoad = 1;
    private float timeLoad = 1;
    DetackPlayer detackPlayer = new DetackPlayer();
    private bool touch = false;

    private void Update()
    {
        
        //Debug.Log("kkkk" + detackPlayer.Detect());
        if (touch == true)
        {
            if (canShoot == false)
            {
                currentLoad -= Time.deltaTime;
                if (currentLoad <= 0)
                {
                    canShoot = true;
                }
            }

            if (canShoot)
            {
                currentLoad = timeLoad;
                canShoot = false;
                Instantiate(bullet, barrels.transform.position, barrels.transform.rotation);
                var explode = Instantiate(bulletExplode, barrels.transform.position, barrels.transform.rotation);
                Destroy(explode, 0.2f);
            }
        }
        //enemyMove();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tank1") || collision.CompareTag("tank2"))
        {
            touch = true;
            //Debug.Log("Status" + isDetect);
        }
        
    }
    

}

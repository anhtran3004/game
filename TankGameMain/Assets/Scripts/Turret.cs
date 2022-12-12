using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> turretBarrels;
    public GameObject bulletPrefab;
    public float reloadDelay = 0.5f;
    /*AudioSource audioSource;
    public AudioClip expode;*/

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0.5f;
    public GameObject bulletExplode;
    public GameObject barrels;
    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
        //currentDelay = reloadDelay;
        /*audioSource = GetComponent<AudioSource>();
        audioSource.clip = expode;*/
    }

    // Update is called once per frame
    void Update()
    {
        //audioSource.Play();
        //var bulletExplodes = Instantiate(bulletExplode, barrels.transform.position, barrels.transform.rotation);
        currentDelay = reloadDelay;
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if(currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }
    public void Shoot()
    {
        //var bulletExplodes = Instantiate(bulletExplode, barrels.transform.position, barrels.transform.rotation);

        if (canShoot)
        {
            //var bulletExplodes = Instantiate(bulletExplode, barrels.transform.position, barrels.transform.rotation);
            //Destroy(bulletExplodes, 0.5f);
            //audioSource.Play();
            canShoot = false;
            currentDelay = reloadDelay;
            foreach(var barrel in turretBarrels)
            {
                /* GameObject bullet = Instantiate(bulletPrefab);
                 bullet.transform.position = barrel.position;
                 //bullet.transform.localPosition = barrel.rotation;
                 bullet.GetComponent<BulletController>().Initialize();*/
                Instantiate(bulletPrefab, barrel.position, barrel.rotation);
                //var bulletExplodes = Instantiate(bulletExplode, barrels.transform.position, barrels.transform.rotation);
                

            }
            foreach( var collider in tankColliders)
            {
                Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), collider);
            }
        }
    }
}

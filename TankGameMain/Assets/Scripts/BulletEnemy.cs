using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    public float bulletSpeed = 100f;
    private int damage = 10;
    public float maxDistance = 10;
    AudioSource audioSource;
    public AudioClip expode;
    private float conquaredDistance = 0;
    public GameObject bullet;
    public GameObject explodes;

    //public GameObject barrel;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = expode;
    }
    // Update is called once per frame
    void Update()
    {
        /*if(bullet.name == "bulletDark1")
        {
            damage = 15;
        }
        else
        {
            damage = 10;
        }*/

        conquaredDistance = Vector2.Distance(transform.position, transform.position);
        if (conquaredDistance >= maxDistance)
        {
            DisableObject();
        }
        //audioSource.Play();
    }
    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up * bulletSpeed * Time.fixedDeltaTime;
    }
    public void Initialize()
    {
        rb2d.velocity = (Vector2)transform.up * bulletSpeed * Time.fixedDeltaTime;
    }
    private void DisableObject()
    {
        Destroy(bullet);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("enemy"))
        {
            audioSource.Play();
            //Debug.Log("Collider " + collision.name);
            //var tank = GameObject.FindGameObjectsWithTag("tank1");
            // if (collision.name != "tanks_5_4")
            // {
            var explode = Instantiate(explodes, bullet.transform.position, bullet.transform.rotation);

            //}
            var damagable = collision.GetComponent<Damagable>();
            if (damagable != null)
            {
                damagable.Hit(damage);
            }

            DisableObject();
            Destroy(explode, 0.5f);
        }
    }
}

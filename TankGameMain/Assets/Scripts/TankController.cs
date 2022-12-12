using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    Rigidbody2D rb2d;
    
    public float moveSpeed = 100f;
    public float moveRotate = 100f;
    public GameObject obj;
    public GameObject bullet;
    public GameObject bulletChange;
    public GameObject barrel;
    public Turret[] turrets;
    public float reloadDelay = 1f;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0.1f;
    public GameObject bulletExplode;
    private AudioSource audioSource;
    private bool isChange = false;
    private float time;
    private float currentChange = 10f;
    private float timeChange = 10f;
    /*private AudioSource audioSource;
    public AudioClip soundMove;*/

    /*public Vector2 TankMover(Vector2 movement)
    {
        this.movement = movement;
        return movement;

    }*/
    private void Awake()
    {
        //audioSource = GetComponent<AudioSource>();
        //audioSource.Stop();
        /*audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundMove;*/
        rb2d = obj.GetComponent<Rigidbody2D>();
        if(turrets == null || turrets.Length == 0)
        {
            turrets = GetComponentsInChildren<Turret>();       }
        
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource = GetComponent<AudioSource>();
        //audioSource.clip = soundMove;
    }
    // Update is called once per frame
    void Update()
    {

        
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
        //if (Input.GetMouseButtonDown(0))
        if (gameObject.CompareTag("tank1"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                //audioSource.Play();
                /*foreach(var turret in turrets)
                {
                    turret.Shoot();
                }*/
                if (canShoot)
                {
                    canShoot = false;
                    currentDelay = reloadDelay;
                    //Initializate();
                    if (!isChange)
                    {
                        
                        Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
                    }
                    else
                    {
                        /*time -= 0.1f;
                        if (time <= 0)
                        {
                            isChange = false;
                        }*/
                        currentChange -= Time.deltaTime;
                        if (currentChange <= 0)
                        {
                            isChange = false;
                        }
                        Instantiate(bulletChange, barrel.transform.position, barrel.transform.rotation);
                    }
                    var bulletExplodes = Instantiate(bulletExplode, barrel.transform.position, barrel.transform.rotation);
                    Destroy(bulletExplodes, 0.3f);
                }

            }
        }
        if (gameObject.CompareTag("tank2"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                /*foreach(var turret in turrets)
                {
                    turret.Shoot();
                }*/
                if (canShoot)
                {
                    canShoot = false;
                    currentDelay = reloadDelay;
                    Initializate();

                    /*if (!isChange)
                    {
                        currentChange -= Time.deltaTime;
                        if(currentChange <= 0)
                        {
                            isChange = true;
                        }
                        Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
                    }
                    else
                    {
                        *//*time -= 0.1f;
                        if (time <= 0)
                        {
                            isChange = false;
                        }*//*
                
                        Instantiate(bulletChange, barrel.transform.position, barrel.transform.rotation);
                    }*/
                    var bulletExplodes = Instantiate(bulletExplode, barrel.transform.position, barrel.transform.rotation);
                    Destroy(bulletExplodes, 0.3f);
                }

            }
        }
        if (gameObject.CompareTag("tank1"))
        {
            /*Vector2 movement = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rb2d.velocity = -(Vector2)transform.up * movement.y * moveSpeed * Time.fixedDeltaTime;
            rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movement.x * moveRotate * Time.fixedDeltaTime));*/
            var transformUp = transform.up;

            transformUp.Normalize();
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = -1 * transformUp * moveSpeed * Time.fixedDeltaTime;
                //audioSource.Play();
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rb2d.velocity = transformUp * moveSpeed * Time.fixedDeltaTime;
                //audioSource.Play();
            }

            else
            {
                rb2d.velocity = Vector2.zero;
               // audioSource.Stop();
            }
                
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, moveRotate * Time.fixedDeltaTime));
                //audioSource.Play();
            }
               
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -moveRotate * Time.fixedDeltaTime));
                //audioSource.Play();
            }      
            else
            {
                rb2d.MoveRotation(transform.rotation);
                //audioSource.Stop();
            }
        }


    }
    private void Initializate()
    {
        if (!isChange)
        {
            Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        }
        else
        {
            time -= 0.1f;
            if (time <= 0)
            {
                isChange = false;
            }
            Instantiate(bulletChange, barrel.transform.position, barrel.transform.rotation);
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("changeBullet"))
        {
            isChange = true;
        }
        if(collision.CompareTag("scaleTank"))
        {
            obj.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
    }
    private void FixedUpdate()
    {
        
            if (gameObject.CompareTag("tank2"))
            {
                var transformUp = transform.up;
                
                transformUp.Normalize();
                if (Input.GetKey(KeyCode.W))
                    rb2d.velocity = -1 * transformUp * moveSpeed * Time.fixedDeltaTime;
                else if (Input.GetKey(KeyCode.S))
                    rb2d.velocity = transformUp * moveSpeed * Time.fixedDeltaTime;
                else
                    rb2d.velocity = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
                rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, moveRotate * Time.fixedDeltaTime));
            else if (Input.GetKey(KeyCode.D))
                rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -moveRotate * Time.fixedDeltaTime));
            else
                rb2d.MoveRotation(transform.rotation);
            // if (Input.GetKey(KeyCode.X)){
            //     //rb2d.velocity = -(Vector2)transform.up  * Input.GetAxisRaw("Horizontal") * moveSpeed * Time.fixedDeltaTime;
            //     rb2d.velocity = new Vector2(0.2f, 0f);
            // }
            // if (Input.GetKeyUp(KeyCode.X))
            // {
            //     //rb2d.velocity = (Vector2)transform.up * 0 * Time.fixedDeltaTime;
            //     rb2d.velocity = new Vector2(0f, 0f);
            // }
            // if (Input.GetKey(KeyCode.E))
            // {
            //     rb2d.velocity = (Vector2)transform.up * moveSpeed * Input.GetAxisRaw("Horizontal")* Time.fixedDeltaTime;
            // }
            // if (Input.GetKeyUp(KeyCode.E))
            // {
            //     rb2d.velocity = (Vector2)transform.up * 0 * Time.fixedDeltaTime;
            // }
            // if (Input.GetKey(KeyCode.Z))
            // {
            //     rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, moveRotate * Time.fixedDeltaTime));
            // }
            // if (Input.GetKeyUp(KeyCode.Z))
            // {
            //     rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, 0 * Time.fixedDeltaTime));
            // }
            // if (Input.GetKey(KeyCode.C))
            // {
            //     rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -moveRotate * Time.fixedDeltaTime));
            // }
            // if (Input.GetKeyUp(KeyCode.C))
            // {
            //     rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, 0 * Time.fixedDeltaTime));
            // }
        }
        
        
    }
}

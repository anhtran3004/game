using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public int MaxHeath = 100;
    [SerializeField]
    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHeath);
        }
    }
    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit, OnHeal;

   

    private void Start()
    {
        Health = MaxHeath;
    }
    public void Hit(int damagePoints)
    {
        Health -= damagePoints;
        if(Health <= 0)
        {
            OnDead?.Invoke();
        }
        else
        {
            OnHit?.Invoke();
        }
    }
    private void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHeath);
        OnHeal?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("heart"))
        {*/
            if(collision.CompareTag("heart"))
            Health += 20;
       /* }*/
    }
        
}

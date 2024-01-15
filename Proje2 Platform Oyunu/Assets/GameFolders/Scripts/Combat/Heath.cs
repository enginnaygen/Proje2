using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Heath : MonoBehaviour
{
    [SerializeField] int maxHealth=3;
    public int currentHealth;

    public bool IsDead => currentHealth < 1;
    public int CurrentHealth { get {  return currentHealth; } set { currentHealth = value; } }
    public event Action OnHealtChanged;

    private void Awake()
    {
        maxHealth = currentHealth;
    }

    public void TakeHit(Damage damage)
    {
        if (IsDead) return; // isdead ise d�nd�r, alta ge�me. isdead de�il ise devam et oluyor.
        {
            currentHealth -= damage.HitDamage;

        }
        
        /*if (IsDead)
        {
            currentHealth -= damage.HitDamage;
          
        }*/
        OnHealtChanged?.Invoke();//bo� de�ilse invoke olsun, �a�r�ls�n



    }
}

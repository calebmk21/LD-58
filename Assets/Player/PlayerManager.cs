using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Makes the PlayerManager global
    public static PlayerManager Instance;
    
    // Initial Values
    public PlayerAttackMode attackMode;
    public Spell spell;
    public Ultimate ultimate;
    public GameObject PlayerCharacter;
    public GameObject ProjectileSpawningRegion;
    void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        attackMode = PlayerAttackMode.Magic;
        spell = Spell.Fireball;
        ultimate = Ultimate.Inferno;
    }

    public void UpdateAttackState(PlayerAttackMode newMode)
    {
        attackMode = newMode;
    }

    public void SwapSpell(Spell newSpell)
    {
        spell = newSpell;
    }

    public void SwapUltimate(Ultimate newUltimate)
    {
        ultimate = newUltimate;
    }
    
    

    public enum PlayerAttackMode
    {
        Gun,
        Sword,
        Magic,
        Ultimate
    }

    public enum Spell
    {
        Fireball,
        MagicMissile,
        LightningBolt
    }

    public enum Ultimate
    {
        GunGunGunGun,
        UltimateAnimeSwordFlurryAttack,
        Inferno
    }
    
    
    [SerializeField] public GameObject fireballPrefab;
    public float fireballSpeed = 10f;
    // Spells
    public void Fireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform) as GameObject;
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.position = ProjectileSpawningRegion.transform.position;
        rb.linearVelocity = transform.forward * fireballSpeed;
        Debug.Log("Fireball");
    }
    public void MagicMissile()
    {
        
    }

    public void LightningBolt()
    {
        
    }
    
}

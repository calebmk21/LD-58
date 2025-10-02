using System;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    // basic movement floats
    public float moveSpeed = 10f, jumpHeight = 1f, lookSpeed = 7f, jumpPower = 10f, gravityForce = -10f;

    public float verticalVelocity;
    
    public float rotY;
    
    
    
    // attacks
    public float bulletDamage = 10f, swordDamage = 4f;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void Move(Vector2 movement)
    {
        Vector3 move = transform.forward * movement.y + transform.right * movement.x;
        move *= moveSpeed * Time.deltaTime;
        _controller.Move(move);
        verticalVelocity += gravityForce * Time.deltaTime;
        Vector3 jumpVec = new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
        _controller.Move(jumpVec);

        if (_controller.isGrounded)
        {
            verticalVelocity = 0f;
        }
    }

    public void Look(Vector2 looking)
    {
        rotY += looking.x * lookSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, rotY, 0);
    }

    public void Jump()
    {
        if (_controller.isGrounded)
        {
            verticalVelocity = jumpPower;
        }
        else
        {
            Debug.Log("Not grounded, cannot jump");
        }
    }

    
    // Attack
    public void Attack(PlayerManager.PlayerAttackMode attackMode)
    {
        switch (attackMode)
        {
            case PlayerManager.PlayerAttackMode.Gun:
                GunAttack();
                break;
            case PlayerManager.PlayerAttackMode.Sword:
                SwordAttack();
                break;
            case PlayerManager.PlayerAttackMode.Magic:
                MagicAttack(PlayerManager.Instance.spell);
                break;
            case PlayerManager.PlayerAttackMode.Ultimate:
                UltimateAttack(PlayerManager.Instance.ultimate);
                break;
        }
    }

    // Attack Methods
    public void GunAttack()
    {
        
    }

    public void SwordAttack()
    {
        
    }

    public void MagicAttack(PlayerManager.Spell spell)
    {
        switch (spell)
        {
            case PlayerManager.Spell.Fireball:
                PlayerManager.Instance.Fireball();
                break;
            case PlayerManager.Spell.MagicMissile:
                PlayerManager.Instance.MagicMissile();
                break;
            case PlayerManager.Spell.LightningBolt:
                PlayerManager.Instance.LightningBolt();
                break;
        }
    }
    
    public void UltimateAttack(PlayerManager.Ultimate ult)
    {
        
    }
    
    
}

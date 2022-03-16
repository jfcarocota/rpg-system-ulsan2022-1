using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character, IHostile
{
    [SerializeField]
    CharacterJob characterJob;
    [SerializeField]
    protected int damage;
    void Start()
    {
        Attack();
    }
    protected override void Movement()
    {
        base.Movement();
        transform.Translate(Axis.normalized.magnitude * Vector3.forward * moveSpeed * Time.deltaTime);
        FacingDirection();
        
    }
    protected void LateUpdate()
    {
        anim.SetFloat("Move", Mathf.Abs(Axis.magnitude));
    }

    public void Attack()
    {
        Mage mage = characterJob as Mage;
        mage.ShotFireBall();
    }

    public int GetDamage()
    {
        return damage;
    }
}

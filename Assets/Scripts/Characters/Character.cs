using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
public class Character : LivingObject
{
    [SerializeField]
    Lore lore;
    [SerializeField, Range(0.1f, 15f)]
    float moveSpeed = 5f;
    GameInputs gameInputs;
    Animator anim;

    void Awake()
    {
        gameInputs = new GameInputs();
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        gameInputs.Enable();
    }

    void OnDisable()
    {
        gameInputs.Disable();
    }

    protected void Update()
    {
        Movement();
    }
    protected virtual void Movement ()
    {
        transform.Translate(Axis.magnitude * Vector3.forward * moveSpeed * Time.deltaTime);
        FacingDirection();
        SendMovementState();
    }

    void FacingDirection()
    {
        if(IsMoving)
        {
            transform.rotation = RotationDirection;
        }
    }

    void SendMovementState() => anim.SetFloat("Move", Mathf.Abs(Axis.magnitude));

    Quaternion RotationDirection => Quaternion.LookRotation(Axis);

    bool IsMoving => Axis != Vector3.zero;

    Vector3 Axis => new Vector3(gameInputs.Gameplay.Horizontal.ReadValue<float>(), 0f, gameInputs.Gameplay.Vertical.ReadValue<float>());
}

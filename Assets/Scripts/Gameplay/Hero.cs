using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character, IHostile
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected JobsOptions jobsOptions;
    [SerializeField]
    CharacterJob currentJob;
    [SerializeField]
    float leaderMinDistance;

    bool IsFollowing = false;
    Vector3 lastPostion;

    void Start()
    {
        ChangeJob(jobsOptions);
        gameInputs.Gameplay.ChangeJob.performed += _=> ChangeJob(jobsOptions);
    }

    protected override void Movement()
    {
        lastPostion = transform.position;
        if(ImLeader)
        {
            IsFollowing = false;
            base.Movement();
            transform.Translate(Axis.normalized.magnitude * Vector3.forward * moveSpeed * Time.deltaTime);
            FacingDirection();
        }
        else
        {
            if(CanMoveToleader)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                transform.LookAt(Gamemanager.Instance.CurrentGameMode.GetPartyLeader);
            }
            IsFollowing = transform.position - lastPostion != Vector3.zero;
        }
    }

    protected void LateUpdate()
    {

    }

    public void Attack()
    {

    }

    public int GetDamage()
    {
        return damage;
    }

    void ChangeJob(JobsOptions job)
    {
        if(currentJob)
        {
            Destroy(currentJob);
        }
        switch(job)
        {
            case JobsOptions.MAGE:
            currentJob = gameObject.AddComponent<Mage>();
            break;
            case JobsOptions.ARCHER:
            currentJob = gameObject.AddComponent<Archer>();
            break;
            case JobsOptions.WARRIOR:
            currentJob = gameObject.AddComponent<Warrior>();
            break;
        }
    }

/// <summary>
/// Checks if you are the leader of the party.
/// </summary>
/// <returns>Returns a true/false depending of the comparing with leader transform.</returns>
    public bool ImLeader => Gamemanager.Instance.CurrentGameMode.CompareToLeader(transform);
    public bool CanMoveToleader => Vector3.Distance(transform.position, Gamemanager.Instance.CurrentGameMode.GetPartyLeader.position) > leaderMinDistance;

    protected float MovementValue => ImLeader ? Mathf.Abs(Axis.magnitude) : CanMoveToleader ? Mathf.Abs(Axis.magnitude) :  IsFollowing ? Mathf.Abs(Axis.magnitude) : 0f;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Job", menuName = "Jobs/Mage", order = 1)]
public class Mage : CharacterJob
{
    public void ShotFireBall()
    {
        Debug.Log("Fire");
    }
}

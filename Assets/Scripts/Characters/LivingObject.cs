using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingObject : MonoBehaviour
{
    [SerializeField]
    protected int health;

    public int GetHealth => health;
    public bool ImDead => health == 0;

    public void ReciveDamage(int damage) => health = health - damage > 0 ? health - damage : 0;
    
}

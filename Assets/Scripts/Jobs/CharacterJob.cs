using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Job", menuName = "Jobs/Mage", order = 1)]
public class CharacterJob : ScriptableObject
{
    [SerializeField]
    protected string jobName;
    [SerializeField, TextArea(2,4)]
    protected string jobDescription;
}

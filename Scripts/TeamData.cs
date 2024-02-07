using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TeamData",menuName ="Team")]
public class NewTeamData : ScriptableObject
{
    public string Name;
    public List<string>PlayerNames;
    [TextArea]public string Description;
    public int speed;
    public int strenght;
    public int stamina;
    public int skill;
}

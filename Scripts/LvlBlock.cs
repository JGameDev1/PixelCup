using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlBlock : MonoBehaviour
{
    public RunnerLvlManager rlm;

    private void Awake()
    {rlm=FindObjectOfType<RunnerLvlManager>();}
    private void OnTriggerEnter2D(Collider2D Player)
    {if(Player.tag=="Player"){rlm.removeLvlBlocks();}}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    ItemType It;
    Rigidbody2D BallRb;
    RunnerLvlManager RLM;

    private void Awake()
    {
    BallRb=GetComponent<Rigidbody2D>();
    RLM=GameObject.Find("RunnerLvlManager").GetComponent<RunnerLvlManager>();
    }

    private void OnCollisionStay2D(Collision2D collision)
{if(collision.gameObject.tag=="Player"){BallRb.angularDrag=-360;}}

private void OnCollisionEnter2D(Collision2D collision)
{if(collision.gameObject.tag=="Enemy"&&RLM.weaponed){collision.gameObject.SetActive(false);
 RLM.weaponed=false;}
}

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RunnerEnemyBehaviour : MonoBehaviour
{
    Rigidbody2D Rb;
    public float crono;
    public float onCrono;
    AudioSource audioSource;
    public bool enemyPlayer;

    private void Start()
    {
     crono=onCrono;
     audioSource=GetComponent<AudioSource>();
     Rb=GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!enemyPlayer)
        {
            crono -= Time.deltaTime;
            if (crono < -onCrono) { crono = onCrono; }
        }
    }

    void FixedUpdate()
    { if (!enemyPlayer)
        {
            if (crono > 0) 
            { Rb.MovePosition(this.transform.position + Vector3.right * 5 * Time.fixedDeltaTime); }
            else 
            { Rb.MovePosition(this.transform.position + Vector3.left * 5 * Time.fixedDeltaTime); }
        }
        else 
        { Rb.MovePosition(this.transform.position + Vector3.left * 5 * Time.fixedDeltaTime); }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ItemType{Point,SuperItem}
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CircleCollider2D))]
public class ItemBehaviour : MonoBehaviour
{
    PlayerController playerController;
    RunnerLvlManager runnerLvlManager;
    AudioSource audioSource;
    CircleCollider2D circleCollider2D;
    SpriteRenderer spriteRenderer;
    float counter;
    public ItemType iT;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            switch (iT)
            {   
                case ItemType.Point:
                    {
                        GameManager.sharedInstance.myScore+=1;
                        if(SceneManager.GetActiveScene().name!="Runner"){playerController.super=true;}
                        audioSource.PlayOneShot(audioSource.clip);
                        circleCollider2D.enabled = false;
                        spriteRenderer.enabled = false;
                        counter--;
                        break;
                    }
                case ItemType.SuperItem:{;break;}

            }

    }

    private void Awake()
    {
        switch (iT)
        {
            case ItemType.Point:
                {
                    counter = 4;
                    audioSource = GetComponent<AudioSource>();
                    circleCollider2D = GetComponent<CircleCollider2D>();
                    circleCollider2D.isTrigger = true;
                    spriteRenderer = GetComponent<SpriteRenderer>();
                    if(SceneManager.GetActiveScene().name=="Runner"){runnerLvlManager=GameObject.Find("RunnerLvlManager").GetComponent<RunnerLvlManager>();}else{playerController=GameObject.Find("TeamManager").GetComponent<PlayerController>();}
                    break;
                }
            case ItemType.SuperItem:{;break;}
        }
    }

    private void Update()
    {
        if (counter < 4) { counter -= Time.deltaTime; }
        if (counter <= 0) { this.gameObject.SetActive(false); }
    }

    private void OnDisable()
    {
        switch (iT)
        {
            case ItemType.Point:
                {
                    circleCollider2D.enabled = true;
                    spriteRenderer.enabled = true;
                    counter = 4;
                    break;
                }
            case ItemType.SuperItem:{;break;}
        }
    }
}

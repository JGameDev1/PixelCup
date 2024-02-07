using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public class RunnerLvlManager : MonoBehaviour
{
public List<GameObject>allLevelRunnerBlocks=new List<GameObject>{}; // lista de los niveles que se van a generar 
public List<GameObject>currentLevelBlocks=new List<GameObject>{}; // lista de los bloques que se ven en pantalla 
public List<GameObject>runners=new List<GameObject>{};
GameObject cam;
GameObject player;
public float speed;
public float jumpForce;
Vector3 blockSpawner;
[Tooltip("x=Neg & y=Pos")]public Vector2 limitPos;
public Transform animationZone;
public LayerMask ground;
public bool weaponed;


    void Start()
    {cam=GameObject.Find("CameraView");
     GameObject newPlayer=Instantiate(runners[Random.Range(0,runners.Count)],transform.position+new Vector3(0,6,0),transform.rotation);
     player=newPlayer;
     addInitialBlock();}

    void Update()
    {addNewBlock();limitPlayerY();
    cam.transform.position=new Vector3(player.transform.position.x,7.3f,-1);}


    private void FixedUpdate(){playerMovements();}

    public void addInitialBlock()
    {GameObject initialBlock = Instantiate(allLevelRunnerBlocks[0]);
    currentLevelBlocks.Add(initialBlock);}

    public void addNewBlock()
    {
        if (currentLevelBlocks.Count < 8)
        {   blockSpawner.x+=44;
            int randomIndex=Random.Range(0,allLevelRunnerBlocks.Count);
            GameObject block=Instantiate(allLevelRunnerBlocks[randomIndex],(this.transform.position+blockSpawner),transform.rotation);
            currentLevelBlocks.Add(block);
        }
        
    }
    public void removeLvlBlocks()
    {
        if (currentLevelBlocks.Count == 8)
        {   Destroy(currentLevelBlocks[0]);
            currentLevelBlocks.Remove(currentLevelBlocks[0]);
        }

    }

    public void playerMovements()
    {
    player.GetComponent<Rigidbody2D>().velocity=new Vector3(speed,player.GetComponent<Rigidbody2D>().velocity.y,0);
    if(Input.GetAxisRaw("Jump")==0.9&&Physics2D.Raycast(player.transform.position,Vector2.down,2.5f,ground))
    {player.GetComponent<Rigidbody2D>().AddForce(jumpForce*Vector3.up,ForceMode2D.Impulse);}
    }

    public void playerButtonJump()
    {if(Physics2D.Raycast(player.transform.position,Vector2.down,2.5f,ground))
    player.GetComponent<Rigidbody2D>().AddForce(jumpForce*Vector3.up,ForceMode2D.Impulse);}

    public void limitPlayerY()
    {if(player.transform.position.y>=limitPos.y){player.transform.position=new Vector3(player.transform.position.x,limitPos.y,0);}
    if(player.transform.position.y<=limitPos.x){player.transform.position=new Vector3(player.transform.position.x,limitPos.x,0);;}
    }

    public void finalSite(){if(player.transform.position.x>=animationZone.position.x)
    {/*activar animacion de patear al arco*/;}}



}


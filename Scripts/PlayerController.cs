using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gamemode {Match,Runner,Penalty}
public enum Director{Player,CPU}

public class PlayerController : MonoBehaviour
{
public gamemode mode;
public List<GameObject> PlayersInMemory;
public List<GameObject>teamListPlayer;
public List<Transform>positions;
public int playerIndex;
public float limitSpeed,sprintSpeed,distanceToTakeTheBall;
private float randomSpeedCrono;
private int randomSpeed0,randomSpeed1,randomSpeed2,randomSpeed3,randomSpeed4;
public Vector2 velocity;
public Vector2 distanceBetweenPlayerand0Target,distanceBetweenPlayerand1Target,distanceBetweenPlayerand2Target,distanceBetweenPlayerand3Target,distanceBetweenPlayerand4Target;
public bool super,isWithBall,isGol,kick,isAMess,isRunning;
Joystick joystick;
public NewTeamData teamData;
public GameObject target;


public void MovementForce()
{velocity=teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity;
float horizontal = Input.GetAxis("Horizontal")*Time.fixedDeltaTime;
float vertical = Input.GetAxis("Vertical")*Time.fixedDeltaTime;
teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontal,vertical)*teamData.speed);
if(velocity.x>=limitSpeed){teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity=new Vector2(teamData.speed*10,teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity.y);}
if(velocity.x<=-limitSpeed){teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity=new Vector2(-teamData.speed*10,teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity.y);}
if(velocity.y>=limitSpeed){ teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity=new Vector2(teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity.x,teamData.speed*10);}
if(velocity.y<=-limitSpeed){ teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity=new Vector2(teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity.x,-teamData.speed*10);}
}

public void JoystickMovement(){
velocity = teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity;
Vector2 JoystickInput=joystick.Vertical*Vector2.up+joystick.Horizontal*Vector2.right;
teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().AddForce(JoystickInput*teamData.speed);
if(velocity.x>=limitSpeed){teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity=new Vector2(teamData.speed,teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity.y);}
if(velocity.x<=-limitSpeed){teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity=new Vector2(-teamData.speed,teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity.y);}
if(velocity.y>=limitSpeed){teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity=new Vector2(teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity.x,teamData.speed);}
if(velocity.y<=-limitSpeed){teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity=new Vector2(teamListPlayer[playerIndex].GetComponent<Rigidbody2D>().velocity.x,-teamData.speed);}
}

void teamBehaviourWithBall()
{randomSpeedCrono-=Time.deltaTime;
if(randomSpeedCrono<0)
{randomSpeed0=Random.Range(2,teamData.speed);
randomSpeed1=Random.Range(2,teamData.speed);
randomSpeed2=Random.Range(2,teamData.speed);
randomSpeed3=Random.Range(2,teamData.speed);
randomSpeed4=Random.Range(2,teamData.speed);
randomSpeedCrono=4;}
if(playerIndex==0)
{teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[1].transform.position.x),0).normalized*randomSpeed1;
teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[2].transform.position.x),0).normalized*randomSpeed2;
teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[3].transform.position.x),0).normalized*randomSpeed3;
teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[4].transform.position.x),0).normalized*randomSpeed4;}
if(playerIndex==1)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[0].transform.position.x),0).normalized*randomSpeed0;
teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[2].transform.position.x),0).normalized*randomSpeed2;
teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[3].transform.position.x),0).normalized*randomSpeed3;
teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[4].transform.position.x),0).normalized*randomSpeed4;}
if(playerIndex==2)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[0].transform.position.x),0).normalized*randomSpeed0;
teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[1].transform.position.x),0).normalized*randomSpeed1;
teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[3].transform.position.x),0).normalized*randomSpeed3;
teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[4].transform.position.x),0).normalized*randomSpeed4;}
if(playerIndex==3)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[0].transform.position.x),0).normalized*randomSpeed0;
teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[1].transform.position.x),0).normalized*randomSpeed1;
teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[2].transform.position.x),0).normalized*randomSpeed2;
teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[4].transform.position.x),0).normalized*randomSpeed4;}
if(playerIndex==4)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[0].transform.position.x),0).normalized*randomSpeed0;
teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[1].transform.position.x),0).normalized*randomSpeed1;
teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[2].transform.position.x),0).normalized*randomSpeed2;
teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=new Vector2((teamListPlayer[playerIndex].transform.position.x-teamListPlayer[3].transform.position.x),0).normalized*randomSpeed3;}
}

void teamBehaviourWithoutBall()
{randomSpeedCrono-=Time.deltaTime;
if(randomSpeedCrono<0)
{randomSpeed0=Random.Range(2,teamData.speed);
randomSpeed1=Random.Range(2,teamData.speed);
randomSpeed2=Random.Range(2,teamData.speed);
randomSpeed3=Random.Range(2,teamData.speed);
randomSpeed4=Random.Range(2,teamData.speed);
randomSpeedCrono=4;}
if(playerIndex==0)
{if(target.transform.position.x-teamListPlayer[1].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[1].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[1].transform.position.x),0).normalized*randomSpeed1;}
else if(target.transform.position.x-teamListPlayer[1].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[1].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[1].transform.position).normalized*randomSpeed1;}
if(target.transform.position.x-teamListPlayer[2].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[2].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[2].transform.position.x),0).normalized*randomSpeed2;}
else if(target.transform.position.x-teamListPlayer[2].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[2].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[2].transform.position).normalized*randomSpeed2;}
if(target.transform.position.x-teamListPlayer[3].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[3].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[3].transform.position.x),0).normalized*randomSpeed3;}
else if(target.transform.position.x-teamListPlayer[3].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[3].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[3].transform.position).normalized*randomSpeed3;}
if(target.transform.position.x-teamListPlayer[4].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[4].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[4].transform.position.x),0).normalized*randomSpeed4;}
else if(target.transform.position.x-teamListPlayer[4].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[4].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[4].transform.position).normalized*randomSpeed4;}
}
 if(playerIndex==1)
{if(target.transform.position.x-teamListPlayer[0].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[0].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[0].transform.position.x),0).normalized*randomSpeed0;}
else if(target.transform.position.x-teamListPlayer[0].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[0].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[0].transform.position).normalized*randomSpeed0;}
if(target.transform.position.x-teamListPlayer[2].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[2].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[2].transform.position.x),0).normalized*randomSpeed2;}
else if(target.transform.position.x-teamListPlayer[2].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[2].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[2].transform.position).normalized*randomSpeed2;}
if(target.transform.position.x-teamListPlayer[3].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[3].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[3].transform.position.x),0).normalized*randomSpeed3;}
else if(target.transform.position.x-teamListPlayer[3].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[3].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[3].transform.position).normalized*randomSpeed3;}
if(target.transform.position.x-teamListPlayer[4].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[4].transform.position.y>1)
{teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[4].transform.position.x),0).normalized*randomSpeed4;}
else if(target.transform.position.x-teamListPlayer[4].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[4].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[4].transform.position).normalized*randomSpeed4;}
}
if(playerIndex==2)
{if(target.transform.position.x-teamListPlayer[1].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[1].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[1].transform.position.x),0).normalized*randomSpeed1;}
else if(target.transform.position.x-teamListPlayer[1].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[1].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[1].transform.position).normalized*randomSpeed1;}
if(target.transform.position.x-teamListPlayer[0].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[0].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[0].transform.position.x),0).normalized*randomSpeed0;}
else if(target.transform.position.x-teamListPlayer[0].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[0].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[0].transform.position).normalized*randomSpeed0;}
if(target.transform.position.x-teamListPlayer[3].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[3].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[3].transform.position.x),0).normalized*randomSpeed3;}
else if(target.transform.position.x-teamListPlayer[3].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[3].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[3].transform.position).normalized*randomSpeed3;}
if(target.transform.position.x-teamListPlayer[4].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[4].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[4].transform.position.x),0).normalized*randomSpeed4;}
else if(target.transform.position.x-teamListPlayer[4].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[4].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[4].transform.position).normalized*randomSpeed4;}
}
if(playerIndex==3)
{if(target.transform.position.x-teamListPlayer[1].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[1].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[1].transform.position.x),0).normalized*randomSpeed1;}
else if(target.transform.position.x-teamListPlayer[1].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[1].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[1].transform.position).normalized*randomSpeed1;}
if(target.transform.position.x-teamListPlayer[2].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[2].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[2].transform.position.x),0).normalized*randomSpeed2;}
else if(target.transform.position.x-teamListPlayer[2].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[2].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[2].transform.position).normalized*randomSpeed2;}
if(target.transform.position.x-teamListPlayer[0].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[0].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[0].transform.position.x),0).normalized*randomSpeed0;}
else if(target.transform.position.x-teamListPlayer[0].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[0].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[0].transform.position).normalized*randomSpeed0;}
if(target.transform.position.x-teamListPlayer[4].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[4].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[4].transform.position.x),0).normalized*randomSpeed4;}
else if(target.transform.position.x-teamListPlayer[4].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[4].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[4].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[4].transform.position).normalized*randomSpeed4;}
}
if(playerIndex==4)
{if(target.transform.position.x-teamListPlayer[1].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[1].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[1].transform.position.x),0).normalized*randomSpeed1;}
else if(target.transform.position.x-teamListPlayer[1].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[1].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[1].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[1].transform.position).normalized*randomSpeed1;}
if(target.transform.position.x-teamListPlayer[2].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[2].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[2].transform.position.x),0).normalized*randomSpeed2;}
else if(target.transform.position.x-teamListPlayer[2].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[2].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[2].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[2].transform.position).normalized*randomSpeed2;}
if(target.transform.position.x-teamListPlayer[3].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[3].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[3].transform.position.x),0).normalized*randomSpeed3;}
else if(target.transform.position.x-teamListPlayer[3].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[3].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[3].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[3].transform.position).normalized*randomSpeed3;}
if(target.transform.position.x-teamListPlayer[0].transform.position.x>distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[0].transform.position.y>distanceToTakeTheBall)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=new Vector2((target.transform.position.x-teamListPlayer[0].transform.position.x),0).normalized*randomSpeed0;}
else if(target.transform.position.x-teamListPlayer[0].transform.position.x<distanceToTakeTheBall&&target.transform.position.y-teamListPlayer[0].transform.position.y<distanceToTakeTheBall)
{teamListPlayer[0].GetComponent<Rigidbody2D>().velocity=(target.transform.position-teamListPlayer[0].transform.position).normalized*randomSpeed0;}
}
}

void logicOfDistanceBetweenPlayersAndTarget()
{distanceBetweenPlayerand0Target=target.transform.position-teamListPlayer[0].transform.position;
if(distanceBetweenPlayerand0Target.x<=0){distanceBetweenPlayerand0Target.x*=-1;}
if(distanceBetweenPlayerand0Target.y<=0){distanceBetweenPlayerand0Target.y*=-1;}
distanceBetweenPlayerand1Target=target.transform.position-teamListPlayer[1].transform.position;
if(distanceBetweenPlayerand1Target.x<=0){distanceBetweenPlayerand1Target.x*=-1;}
if(distanceBetweenPlayerand1Target.y<=0){distanceBetweenPlayerand1Target.y*=-1;}
distanceBetweenPlayerand2Target=target.transform.position-teamListPlayer[2].transform.position;
if(distanceBetweenPlayerand2Target.x<=0){distanceBetweenPlayerand2Target.x*=-1;}
if(distanceBetweenPlayerand2Target.y<=0){distanceBetweenPlayerand2Target.y*=-1;}
distanceBetweenPlayerand3Target=target.transform.position-teamListPlayer[3].transform.position;
if(distanceBetweenPlayerand3Target.x<=0){distanceBetweenPlayerand3Target.x*=-1;}
if(distanceBetweenPlayerand3Target.y<=0){distanceBetweenPlayerand3Target.y*=-1;}
distanceBetweenPlayerand4Target=target.transform.position-teamListPlayer[4].transform.position;
if(distanceBetweenPlayerand4Target.x<=0){distanceBetweenPlayerand4Target.x*=-1;}
if(distanceBetweenPlayerand4Target.y<=0){distanceBetweenPlayerand4Target.y*=-1;}}

void animatorMaster()
{teamListPlayer[0].GetComponent<Animator>().SetBool("isGol",isGol);teamListPlayer[0].GetComponent<Animator>().SetBool("isGol", isGol);
teamListPlayer[1].GetComponent<Animator>().SetBool("isGol",isGol);teamListPlayer[1].GetComponent<Animator>().SetBool("isGol", isGol);
teamListPlayer[2].GetComponent<Animator>().SetBool("isGol",isGol);teamListPlayer[2].GetComponent<Animator>().SetBool("isGol", isGol);
teamListPlayer[3].GetComponent<Animator>().SetBool("isGol",isGol);teamListPlayer[3].GetComponent<Animator>().SetBool("isGol", isGol);
teamListPlayer[4].GetComponent<Animator>().SetBool("isGol",isGol);teamListPlayer[4].GetComponent<Animator>().SetBool("isGol", isGol);
teamListPlayer[0].GetComponent<Animator>().SetBool("isAMess", isAMess);teamListPlayer[0].GetComponent<Animator>().SetBool("isAMess",isAMess);
teamListPlayer[1].GetComponent<Animator>().SetBool("isAMess", isAMess);teamListPlayer[1].GetComponent<Animator>().SetBool("isAMess",isAMess);
teamListPlayer[2].GetComponent<Animator>().SetBool("isAMess", isAMess);teamListPlayer[2].GetComponent<Animator>().SetBool("isAMess",isAMess);
teamListPlayer[3].GetComponent<Animator>().SetBool("isAMess", isAMess);teamListPlayer[3].GetComponent<Animator>().SetBool("isAMess",isAMess);
teamListPlayer[4].GetComponent<Animator>().SetBool("isAMess", isAMess);teamListPlayer[4].GetComponent<Animator>().SetBool("isAMess",isAMess);
}
public void changePlayerSelectedAddition()
{playerIndex++;
if(playerIndex>4){playerIndex=0;}
}

public void changePlayerSelectedSubstraction()
{playerIndex--;
if(playerIndex<0){playerIndex=4;}}

public void changePlayerSelectedAdditionNoButton()
{if(Input.GetKeyDown(KeyCode.Keypad6)){playerIndex++;}
if(playerIndex>4){playerIndex=0;}
}

public void changePlayerSelectedSubstractionNoButton()
{if(Input.GetKeyDown(KeyCode.Keypad4)){playerIndex--;}
if(playerIndex<0){playerIndex=4;}}

void createPlayers(){if(teamData.name.Equals("ArgentinaData"))
{GameObject Player0=Instantiate(PlayersInMemory[0],positions[0].position, positions[0].rotation);
 teamListPlayer.Add(Player0);
 GameObject Player1=Instantiate(PlayersInMemory[1],positions[1].position, positions[1].rotation);
 teamListPlayer.Add(Player1);
 GameObject Player2=Instantiate(PlayersInMemory[2],positions[2].position, positions[2].rotation);
 teamListPlayer.Add(Player2);
 GameObject Player3=Instantiate(PlayersInMemory[3],positions[3].position, positions[3].rotation);
 teamListPlayer.Add(Player3);
 GameObject Player4=Instantiate(PlayersInMemory[4],positions[4].position, positions[4].rotation);
 teamListPlayer.Add(Player4);}
 }

private void Awake()
{sprintSpeed=teamData.speed*1.5f;
joystick=GameObject.Find("Fixed Joystick").GetComponent<Joystick>();}
 private void Start()
{createPlayers();
target=teamListPlayer[0];}

private void Update()
{changePlayerSelectedSubstractionNoButton();
changePlayerSelectedAdditionNoButton();
logicOfDistanceBetweenPlayersAndTarget();
animatorMaster();
}


private void FixedUpdate()
{MovementForce();
JoystickMovement();
if(isWithBall){teamBehaviourWithBall();}else{teamBehaviourWithoutBall();}}
}

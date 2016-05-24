using UnityEngine;
using System.Collections;

// Manager class for Player Figure
public class PlayerManager : MonoBehaviour
{
	// public vars          
	public float Speed;                   //Current Speed 
    public float turnSpeed;               //Current Turn
    public float Position;                //Current Position
    public int Health;             //Current health 
	public Vector3 start;				  //Start Position
	public PlayerController pControle;	  //PlayerController

    //All variables for health
	public const int HEALTH_HIGH = 100;
	public const int HEALTH_LOW = 40;
	public const int HEALTH_START = HEALTH_HIGH;

	public int currentHealth
	{
		get {
			return Health; }
		set { Health = value; }

	}
    
	public float currentSpeed
    {
        get {
            return Speed; }
        set { Speed = value; }
            
        }

    public float currentPosition
    {
        get { return Position; }
        set { Position = value; }

    }

	private void Awake()
	{
		start = gameObject.transform.position;
		pControle = GameObject.Find ("Player").GetComponent<PlayerController>();	
		Health = HEALTH_START;
		Speed = 9;
		turnSpeed = 180f;
	}


    public PlayerManager()
    {
        


    }

    void Start()
    {
		
        
        
    }

    public bool isHurt()
    {
        if(currentHealth > HEALTH_LOW)
        {
			
            return false;
        }else{
            return true;
        }

    }

    public bool isDead(int health)
    {
        if (health <= 0)
        {
            return true;
        }
        return false;
    }


// respawn player
public void Respawn ()
	{

	pControle.SetPlayerToPosition(start);
	currentHealth = HEALTH_START;
	}


}

using UnityEngine;
using System.Collections;

// Manager class for Player Figure
public class PlayerManager : MonoBehaviour
{
	// public vars          
	public float Speed;                   //Current Speed 
    public float turnSpeed;               //Current Turn
    public float Position;                //Current Position
    public int currentHealth;             //Current health 
	public Vector3 start;				  //Start Position

    //All variables for health
	public const int HEALTH_HIGH = 100;
	public const int HEALTH_LOW = 30;
	public const int HEALTH_START = HEALTH_HIGH;

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

    public PlayerManager()
    {
        currentHealth = HEALTH_START;
        Speed = 9;
        turnSpeed = 180f;
		start = gameObject.transform.position;

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
	PlayerController.SetPlayerToPosition (start);
	currentHealth = HEALTH_START;
	}


}

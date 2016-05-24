using UnityEngine;
using System.Collections;

// Manager class for Player Figure
public class PlayerManager : MonoBehaviour
{
	// public vars          
	public float Speed = 9;              //Current Speed 
    public float turnSpeed;               //Current Turn
    public float Position;                //Current Position
    public int currentHealth;             //Current health 

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
        Speed = 10;
        turnSpeed = 180f;

    }

    void Start()
    {
        Debug.Log("Start Manager");
        
        
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


}



// modules

// delegates
//  public delegate void PlayerEvent (int val);
//public static event PlayerEvent OnPlayerHealthChanged;



// initialize


// respawn player
//public void Respawn ()
//{
//	m_playerInputManager.SetPlayerToPosition (startPosition);
//currentHealth = MAX_LIFE_POINTS;
//}


//}

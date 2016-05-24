using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private string m_MovementAxisName;          // The name of the input axis for moving forward and back.
    private string m_TurnAxisName;              // The name of the input axis for turning.
    private Rigidbody m_Rigidbody;              // Reference used to move the tank.
    private PlayerManager m_pManager;           // The Manager for the Tank
    public GameManager m_GameManager;           // The Game Manager
    private float m_MovementInputValue;         // The current value of the movement input.
    private float m_TurnInputValue;             // The current value of the turn input.
    private float m_currentSpeed;                 // The current Speed of the Player
   


    private void Awake()
    {
        Debug.Log("Awake");
        m_Rigidbody = GetComponent<Rigidbody>();
        m_pManager = new PlayerManager();
        m_GameManager = new GameManager();
                
    }


    private void OnEnable()
    {
        // When the tank is turned on, make sure it's not kinematic.
        m_Rigidbody.isKinematic = false;

        // Also reset the input values.
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    private void OnDisable()
    {
        // When the tank is turned off, set it to kinematic so it stops moving.
        m_Rigidbody.isKinematic = true;
    }

    // Initialisation of everything
    void Start () {
        Debug.Log("Start");
        
        m_MovementAxisName = "Vertical"; 
        m_TurnAxisName = "Horizontal";

    }
	
	// Update is called once per frame
	void Update () {
        // Store the value of both input axes.
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
    }

    private void FixedUpdate()
    {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();
    }


    private void Move()
    {
        float healthFactor = 1.0f;
        m_currentSpeed = m_pManager.currentSpeed;
        if (m_pManager.isHurt()) {
            healthFactor = .5f;
            Debug.Log("OMG i´m hurt!");
        }
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * m_MovementInputValue * m_currentSpeed * Time.deltaTime * healthFactor;

        // Apply this movement to the rigidbody's position.
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }


    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = m_TurnInputValue * m_pManager.turnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}

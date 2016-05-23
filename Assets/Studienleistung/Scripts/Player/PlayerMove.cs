using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{


    private string m_MovementAxisName = "Vertical";          // The name of the input axis for moving forward and back.
    private string m_TurnAxisName = "Horizontal";              // The name of the input axis for turning.
    private Rigidbody m_Rigidbody;              // The Rigidbody for player physics
    private PlayerManager m_PlayerManager;      // The PlayerManager
    private float m_MovementInputValue;         // The current value of the movement input.
    private float m_TurnInputValue;             // The current value of the turn input.


    public void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_PlayerManager = gameObject.GetComponent<PlayerManager>();
    }

    public void Update()
    {
        // Store the value of both input axes.
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
    }

    public void FixedUpdate()
    {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();
    }


    private void Move()
    {
        // Moves the player depending on life missing
        float healthFactor = 1.0f;

        if (m_PlayerManager.health <= PlayerManager.HEALTH_HIGH)
            healthFactor = .1f;
        else if (m_PlayerManager.health <= PlayerManager.HEALTH_LOW)
            healthFactor = .5f;


        float movementValue = Input.GetAxis(m_MovementAxisName);
        float movementSpeed = m_PlayerManager.GetMovementSpeed();
        Vector3 movementDirection = m_Rigidbody.transform.forward;


        Vector3 movement = m_Rigidbody.position + movementDirection * movementValue * Time.deltaTime * movementSpeed * healthFactor;
        m_Rigidbody.MovePosition(movement);
    }


    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = m_TurnInputValue * m_TurnInputValue * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

    public void SetPlayerToPosition(Vector3 newPosition)
    {
        Debug.Log("Set player to new position");
        gameObject.transform.position = newPosition;
    }
}
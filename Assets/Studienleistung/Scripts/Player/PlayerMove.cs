using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    private string m_MovementAxisName;          // The name of the input axis for moving forward and back.
    private string m_TurnAxisName;              // The name of the input axis for turning.
    private Rigidbody m_Rigidbody;              // Reference used to move the tank.


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Resources = gameObject.GetComponent<PlayerManager>();
    }


    private void OnEnable()
    {
        // When the tank is turned on, make sure it's not kinematic.
        m_Rigidbody.isKinematic = false;

    private void OnDisable()
    {
        // When the tank is turned off, set it to kinematic so it stops moving.
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        // The axes names are set.
        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";
    }


    private void Update()
    {
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
        // Moves the player depending on life missing
        float healthFactor = 1.0f;

        if (m_Resources.lifePoints <= PlayerManager.CRIT_LIFE_POINTS)
            healthFactor = .1f;
        else if (m_Resources.lifePoints <= PlayerManager.MEDIUM_LIFE_POINTS)
            healthFactor = .5f;


        float movementValue = Input.GetAxis(m_MovementAxisName);
        float movementSpeed = m_Resources.GetMovementSpeed();
        Vector3 movementDirection = m_Rigidbody.transform.forward;


        Vector3 movement = m_Rigidbody.position + movementDirection * movementValue * Time.deltaTime * movementSpeed * healthFactor;
        m_Rigidbody.MovePosition(movement);
    }


    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

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
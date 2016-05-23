using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    // public vars
    public float movementSpeed;
    public float turnSpeed;


    public const int HEALTH_HIGH = 100;
    public const int HEALTH_LOW = 20;

    private int m_LifePoints;
    public int health
    {
        get
        {
            return m_LifePoints;
        }
        set
        {
            m_LifePoints = value;
            OnPlayerHealthChanged(value);
        }
    }

    private Vector3 startPosition;

    // modules
    private PlayerMove m_playerMove;

    // delegates
    public delegate void PlayerEvent(int val);
    public static event PlayerEvent OnPlayerHealthChanged;



    // initialize
    void Start()
    {
        startPosition = gameObject.transform.position;
        m_playerMove = gameObject.AddComponent<PlayerMove>();
        health = HEALTH_HIGH;

    }

    // respawn player
    public void Respawn()
    {
        m_playerMove.SetPlayerToPosition(startPosition);
        health = HEALTH_HIGH;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public float GetTurnSpeed()
    {
        return turnSpeed;
    }

    
}

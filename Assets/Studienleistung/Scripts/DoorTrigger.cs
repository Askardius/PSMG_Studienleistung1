using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
	Door m_door;

	void Start ()
	{
		m_door = gameObject.transform.parent.GetComponentInChildren<Door> ();
	}

	// Use this for initialization
	void OnTriggerEnter (Collider other)
	{
		

		// if colliding object is player
		if (other.gameObject.GetComponent<PlayerManager> () != null && !m_door.isOpen) {
            Debug.Log("enter " + other);
            GameObject root = GameObject.Find ("root");

			root.GetComponent<GameManager> ().ShowDoorOpenButton (m_door);
			// play 'bing'
			root.GetComponent<AudioSource> ().Play ();
		}
	}

	void OnTriggerExit (Collider other)
	{
		Debug.Log ("leave " + other);
         GameObject.Find ("root").GetComponent<GameManager> ().HideDoorOpenButton ();
	}
}

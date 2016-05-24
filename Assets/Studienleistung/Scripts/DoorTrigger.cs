using UnityEngine;
using System.Collections;

	
public class DoorTrigger : MonoBehaviour{
	Door m_door;
	GameManager gManager;
	GameObject root;

	void Awake()
	{
		m_door = gameObject.transform.parent.GetComponentInChildren<Door> ();
		root = GameObject.Find ("root");
		gManager = root.GetComponent<GameManager> ();

	}
		
	
		
		
		


	// Use this for initialization
	void OnTriggerEnter (Collider other)
	{
		

		// if colliding object is player
		if (other.gameObject.GetComponent<PlayerManager> () != null && !m_door.isOpen) {
            
            

			gManager.ShowDoorOpenButton (m_door);
		}
	}

	void OnTriggerExit (Collider other)
	{
		
         GameObject.Find ("root").GetComponent<GameManager> ().HideDoorOpenButton ();
	}
}


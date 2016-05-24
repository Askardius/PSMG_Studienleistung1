using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private Door[] doors;
    
    // UI
    private bool isShowingOpenerButton = false;
    private Door selectedDoor;

    private GUIStyle styleLPs;
    private GUIStyle styleWon;

    private bool isGameWon = false;

    void Start()
    {
        
        
        doors = gameObject.GetComponentsInChildren<Door>();

        styleLPs = new GUIStyle();
		styleLPs.normal.textColor = Color.red;
		styleLPs.fontSize = 30;
        styleWon = new GUIStyle();
        styleWon.normal.textColor = Color.red;
        styleWon.fontSize = 40;
    }

    void FixedUpdate()
    {
        foreach (Door door in doors) {
            door.Refresh();
        }
    }

   



    public void OnGUI ()
	{
		PlayerManager player = GameObject.Find ("Player").GetComponent <PlayerManager> ();

		string text = "LP: " + player.currentHealth + "/" + PlayerManager.HEALTH_HIGH;
		GUI.Label (new Rect (30, 30, 100, 100), text, styleLPs);

		// occasionally show opener button
		if (isShowingOpenerButton) {
			if (GUI.Button (new Rect (Screen.width / 2 - 100 / 2, Screen.height / 2 + 100 / 2, 100, 100), "OPEN")) {
				selectedDoor.Open ();
			}
		}

		if (isGameWon) {
			GUI.Label (new Rect (Screen.width / 2 - 100 / 2, Screen.height / 2 + 100 / 2, 100, 100), "YOU WON!", styleWon);
		}

	}

	public void youWin ()
	{
		Debug.Log ("Won");
		isGameWon = true;

		StartCoroutine (Wait ());
	}

	IEnumerator Wait ()
	{
		yield return new WaitForSeconds (5);
		ResetGame ();
	}
		
	//
	//
	// UI
	public void ShowDoorOpenButton (Door connectedDoor)
	{
		isShowingOpenerButton = true;
		selectedDoor = connectedDoor;
	}

	public void HideDoorOpenButton ()
	{
		isShowingOpenerButton = false;
		selectedDoor = null;
	}

	public void ShowGameWon ()
	{
		Debug.Log ("Won");
	}

	public void ResetGame ()
	{
		Debug.Log ("Reset");
		isGameWon = false;
		GameObject.Find ("Player").GetComponent <PlayerManager> ().Respawn ();

		foreach (BombTrigger bomb in gameObject.GetComponentsInChildren<BombTrigger>()) {
			bomb.SetActive (true);
		}

		foreach (Door door in gameObject.GetComponentsInChildren<Door>()) {
			door.Close ();
		}
	}

}

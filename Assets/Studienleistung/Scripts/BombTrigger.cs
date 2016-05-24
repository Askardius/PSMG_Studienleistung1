using UnityEngine;
using System.Collections;

public class BombTrigger : MonoBehaviour
{
	public int bombDamage = 20;

	void OnTriggerEnter (Collider other)
	{
		PlayerManager Player = other.gameObject.GetComponent<PlayerManager> ();
		Debug.Log ("Player = " + Player );
		if (Player != null) {
			Player.currentHealth -= bombDamage;
			Debug.Log ("BOOOOOM");
			Debug.Log (Player.currentHealth);
			if (Player.isDead(Player.currentHealth)) {
				Player.Respawn();
			}
			SetActive (false);
		}
	}

	public void SetActive (bool isActive)
	{
		this.GetComponent<Renderer> ().enabled = isActive;
		this.GetComponent<Collider> ().enabled = isActive;
	}
}

using UnityEngine;
using System.Collections;

public class BombTrigger : MonoBehaviour
{
	

	void OnTriggerEnter (Collider other)
	{
		PlayerManager Player = GameObject.Find ("Player").GetComponent<PlayerManager>();
		GameManager Game = GameObject.Find ("root").GetComponent<GameManager>();

		int bombDamage = 20;
		if (Player != null) {
			Player.currentHealth -= bombDamage;
			if (Player.isDead(Player.currentHealth)) {
				Game.ResetGame();
			}
			if (Player.currentHealth <= 40) {
				Player.currentSpeed = 2;
				Debug.Log("Speed Down");
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

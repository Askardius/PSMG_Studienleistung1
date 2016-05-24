using UnityEngine;
using System.Collections;

public class VictoryTrigger : MonoBehaviour
{
	GameManager Game; 

	void OnTriggerEnter ()
	{
		Game = GameObject.Find ("root").GetComponent<GameManager>();
		Game.youWin();
	}
}

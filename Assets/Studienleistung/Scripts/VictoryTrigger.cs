using UnityEngine;
using System.Collections;

public class VictoryTrigger : MonoBehaviour
{
	public delegate void VictoryEvent ();
	public static event VictoryEvent OnGameWon;

    public GameManager GlobalManager = new GameManager();

	void OnTriggerEnter ()
	{
		OnGameWon ();
	}
}

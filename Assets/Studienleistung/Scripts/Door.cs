﻿using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	private static float doorSpeed = 1;

	private float yOpen = 1.5f, yClosed = 3.0f;

	private bool m_isOpen = false;
	public bool isOpen {
		get {
			return m_isOpen;
		}
		set {
			m_isOpen = value;
		}
	}

	public void Open ()
	{
		m_isOpen = true;
		GameObject.Find ("root").GetComponent<GameManager> ().HideDoorOpenButton ();
	}

	public void Close ()
	{
		m_isOpen = false;
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, yClosed, gameObject.transform.position.z);
	}

	public void Refresh ()
	{
		if (m_isOpen && gameObject.transform.position.y > yOpen) {
			gameObject.transform.Translate (0f, - doorSpeed * Time.deltaTime, 0f);
		}

}
}

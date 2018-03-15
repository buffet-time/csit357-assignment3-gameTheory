using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerTwoHp : MonoBehaviour 
{
	public Text health;
	public GameObject player;
	private PlayerTwoControl playerTwoControl;
	void Update () 
	{
		playerTwoControl = player.GetComponentInChildren<PlayerTwoControl>();
		health.text = "HP - " + playerTwoControl.health.ToString();
	}
}
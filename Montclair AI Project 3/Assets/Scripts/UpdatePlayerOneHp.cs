using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerOneHp : MonoBehaviour 
{
	public Text health;
	public GameObject player;
	private PlayerOneControl playerOneControl;
	void Update () 
	{
		playerOneControl = player.GetComponentInChildren<PlayerOneControl>();
		health.text = "HP - " + playerOneControl.health.ToString();
	}
}
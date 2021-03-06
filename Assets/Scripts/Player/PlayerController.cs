﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public uint controllerNo = 9;
	public Team playerTeam = Team.Hunters;
	public bool isPlaying  = false;
	public PlayerInputNames inputAxes;
	
	public float moveSpeed = 4;
	float walkInput;
	float strafeInput;
	Vector3 moveVector;
	Rigidbody thisRigidbody;
	
	
	// Use this for initialization
	void Start () {
		thisRigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isPlaying == true){
			// get the input
			walkInput = Input.GetAxis(inputAxes.yAxis);
			strafeInput = Input.GetAxis(inputAxes.xAxis);
			// set the input to the movement vector
			moveVector.x = strafeInput;
			moveVector.z = walkInput;
		}
	}
	
	void FixedUpdate () {
	
		// normalise the movement vector, so you dont run faster diagonally
		// makes it have a length of 1
		moveVector.Normalize();
		
		// now make it move at the required speed per second
		moveVector = (moveVector * moveSpeed * Time.deltaTime);
		
		// move the rigidbody by the movement Vector
		thisRigidbody.MovePosition(thisRigidbody.position + moveVector);
	}
	
	
	// used to set the input axes when spawning the players
	public void SetInputAxes(PlayerInputNames newAxes){
		inputAxes = newAxes;
		isPlaying = true;
	}
	
	public void SetTeam(Team t){
		// set our player carry variables
		player_carry plc = GetComponent<player_carry>();
		
		
		playerTeam = t;
		if(t == Team.Vampires){
			GetComponent<FogZone>().team = FogTeam.Vampires;
			plc.is_hunter = false;
			plc.is_vampire = true;
		}
		else if(t == Team.Hunters){
			GetComponent<FogZone>().team = FogTeam.Hunters;
			plc.is_hunter = true;
			plc.is_vampire = false;
		}
		
	}
	
	public void GetCamera() {
		GameObject camObj = PlayerCtrlSetup.singleton.localPlayerCtrlData[controllerNo].cameraObject;
		camObj.GetComponent<PlayerCamera>().SetTarget(this.transform);
	}
}

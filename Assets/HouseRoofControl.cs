﻿using UnityEngine;
using System.Collections;

public class HouseRoofControl : MonoBehaviour {
	
	public Material invisibleRoofMat = null;
	public Material roofMat = null;
	
	public MeshRenderer vampRoofRenderer = null;
	public MeshRenderer huntRoofRenderer = null;
	
	public uint numOfVampire = 0;
	public uint numOfHunter = 0;
	
	// Use this for initialization
	void Start () {
		vampRoofRenderer.sharedMaterial = roofMat;
		huntRoofRenderer.sharedMaterial = roofMat;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider col) {
	
		if(col.tag == "Player"){
			// get player script
			//print ("entered house");
			PlayerController plScript = col.GetComponent<PlayerController>();
			
			if(plScript.playerTeam == Team.Vampires){
				// check for vampire
				VampireEntered();
			}
			else if(plScript.playerTeam == Team.Hunters){
				// check for hunter
				HunterEntered();
			}
			
			
			
		}
	}
	
	void OnTriggerExit (Collider col){
		if(col.tag == "Player"){
		
			// get player script
			//print ("left house");
			PlayerController plScript = col.GetComponent<PlayerController>();
			
			if(plScript.playerTeam == Team.Vampires){
				// check for vampire
				VampireLeft();
			}
			else if(plScript.playerTeam == Team.Hunters){
				// check for hunter
				HunterLeft();
			}
		}
	}
	
	void ToggleVampireRoof () {
		if(numOfVampire == 0){
			vampRoofRenderer.sharedMaterial = roofMat;
		}
		else{
			vampRoofRenderer.sharedMaterial = invisibleRoofMat;
		}	
	}
	
	void ToggleHunterRoof(){
		if(numOfHunter == 0){
			huntRoofRenderer.sharedMaterial = roofMat;
		}
		else{
			huntRoofRenderer.sharedMaterial = invisibleRoofMat;
		}
	}
	
	void VampireEntered () {
		numOfVampire ++;
		ToggleVampireRoof();
	}
	
	void VampireLeft () {
		numOfVampire --;
		ToggleVampireRoof();
	}
	
	void HunterEntered () {
		numOfHunter ++;
		ToggleHunterRoof();
	}
	
	void HunterLeft () {
		numOfHunter --;
		ToggleHunterRoof();
	}
}

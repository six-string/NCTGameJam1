﻿using UnityEngine;
using System.Collections;

public class item_pickup : MonoBehaviour {

	public bool isHeld = false;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}


	// Trigger for knight piece item pickup
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player" && isHeld == false) {  
			print ("Item picked up");
			player_carry plScript = other.GetComponent<player_carry>();
			if(plScript.is_carrying == false){
				isHeld = true;
				plScript.PickupItem(this);
				this.transform.position = plScript.pieceHolder.position;
				this.transform.parent = plScript.pieceHolder;
			}
		}
	}

	public void DropPiece(){
		isHeld = false;
		this.transform.parent = null;
	}

	public void CapturePiece () {
		Destroy (this);
	}
}


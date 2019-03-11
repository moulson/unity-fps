using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour {
	public GameObject xhair; 
	private GameObject xhairInstance;
	public Transform target;
	private bool needsInstantiating = true;
	private bool UIBeingShown = false;

	//Check every frame for something
	void Update(){
		if(UIBeingShown){
			CheckForActivation();
		}
	}

	void ActivateUI(){
		if(needsInstantiating){	
			xhairInstance = Instantiate(xhair);
			needsInstantiating = false;
		}
		xhairInstance.SetActive(true);
	}
	//If the player is close to and looking at the button then show a prompt to activate the button
	void OnTriggerEnter(Collider collider){
		//If the player is in touching range
		if(collider.gameObject.tag == "Activator"){
			ActivateUI();
			UIBeingShown = true;
		}
	}

	void OnTriggerExit(Collider collider){
		if(collider.gameObject.tag == "Activator"){
			xhairInstance.SetActive(false);
			UIBeingShown = false;
		}
	}

	void CheckForActivation(){
		if(Input.GetKeyDown(KeyCode.E))
			OpenDoor();
	}
	void OpenDoor(){
		target.transform.Translate(new Vector3(0, 0, -10));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : MonoBehaviour {

	void OnTriggerEnter(Collider c){
		if(c.tag == "Player"){
			Debug.Log("Hitting Player");
			c.SendMessage("PlayerHit", 10f);
		}
	}
}

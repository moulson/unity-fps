using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to any entity that should have a healthpool

public class HealthSystem : MonoBehaviour {

	//Variables for entity type
	private int player = 0;
	private int enemy = 1;
	private int other = 2;
	public enum EntityType {player, enemy, other};
	public EntityType entityType;

	//variables for the health
	public GameObject healthBar;
	public GameObject UIHealthBar;
	public float maxHP;
	public float currentHP;


	// Use this for initialization
	void Start () {
		switch(entityType){
			case EntityType.player:
				PlayerStart();
				break;
			case EntityType.enemy:
				//Run enemy start method
				break;
			case EntityType.other:
				//Run other start method
				break;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayerStart(){
		//For the player, the healthbar should be a UI item
		//it just needs instantiating, position should already be set
		UIHealthBar = Instantiate(healthBar);
		//Set health to full
		currentHP = maxHP;
	}

	void PlayerHit(float damage){
		Debug.Log("Player was hit");
		float hpercent;
		Transform green;
		//Apply the damage
		currentHP = currentHP - damage;
		green = UIHealthBar.transform.Find("hp_green");

		//Get the percentage of hp remaining
		hpercent = (currentHP / maxHP);
		//Resize the green bar
		green.localScale = new Vector3(green.localScale.x * hpercent, green.localScale.y, green.localScale.z);
		
	}
}

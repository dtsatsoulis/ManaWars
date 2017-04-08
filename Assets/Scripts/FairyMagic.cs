﻿using UnityEngine;
using System.Collections;

public class FairyMagic : MonoBehaviour {

	public GameObject WizardPos;

	public GameObject Wizard;

	public Vector3 wizPosition;
	public Quaternion wizRotation;
	float distFromWiz;
	public GameObject Shield;
	public GameObject FairyShot;
	public Vector3 offsetShield;

	public Collider NearDome;

	public float fairyshieldtimer = 10f;

	// Use this for initialization
	void Start () {
		//StartCoroutine(PresenceCheck());
	}

	IEnumerator PresenceCheck(){
		
		yield return new WaitForSeconds (1f);
	}
	
	// Update is called once per frame
	void Update () {

		if (fairyshieldtimer < 10) {
			fairyshieldtimer += (Time.deltaTime) * 1;
		}

		if (fairyshieldtimer >= 10) {
			fairyshieldtimer = 10;
			//if ( enemyspell is nearby){
		//}
			wizPosition = new Vector3 (WizardPos.transform.position.x, (WizardPos.transform.position.y), (WizardPos.transform.position.z));
			wizRotation = Quaternion.LookRotation (WizardPos.transform.position, Vector3.up);

			Collider[] hitColliders = Physics.OverlapSphere (wizPosition, 4f);
			int i = 0;

			//Collider[] hitColliders = Physics.OverlapSphere (wizPosition, 4f);

			while (i < hitColliders.Length) {
				if (hitColliders [i].tag == "EnemySpell") {
					Shield.transform.position = wizPosition;
					Instantiate (Shield);
					fairyshieldtimer -= 10;
					i = hitColliders.Length;

				}
				i++;
			}

			if (Wizard.GetComponent<Human_Wizard> ().health <= 50) {
				i = 0;
				while (i < hitColliders.Length) {
					if (hitColliders [i].tag == "Enemy") {
						//Speedboost code here!

						Wizard.GetComponent<Human_Wizard> ().speed = 10;
						Wizard.GetComponent<Human_Wizard> ().isSpeedBoosted = true;

						fairyshieldtimer -= 5;
						i = hitColliders.Length;
					}
					i++;
				}
			} else {
				Collider[] ShotTargetCollider = Physics.OverlapSphere (wizPosition, 6f);
				int j = 0;

				while (j < ShotTargetCollider.Length) {
					if (ShotTargetCollider [j].tag == "Enemy") {
						FairyShot.transform.position = transform.position;
						Instantiate (FairyShot);
						fairyshieldtimer -= 3;
						j = hitColliders.Length;

					}
					j++;
				}
			}

			if(fairyshieldtimer >= 10){
				if(Wizard.GetComponent<Human_Wizard>().health < 100){
					Wizard.GetComponent<Human_Wizard>().health += 5;

					if(Wizard.GetComponent<Human_Wizard>().health > 100){
						Wizard.GetComponent<Human_Wizard>().health = 100;
					}

					fairyshieldtimer -= 1;
				}	
			}



			//else{

			//if (Wizard.GetComponent<WizardStats> ().HP < 50) {
			//}





			//offsetShield = new Vector3(Shield.transform.position.x, Shield.transform.position.y + 0.5f, Shield.transform.position.z + 2);
			//Shield.transform.rotation = Quaternion.RotateTowards (transform.rotation, wizRotation, 999999f);
			//Shield.transform.position = offsetShield;
			//Instantiate (Shield);
			//fairyshieldtimer = 6;
		}

	}

	public void OnTriggerEnter(Collider other)
	{
		/*
		if (other.tag == "EnemySpell") {
			if (fairyshieldtimer >= 6) {
				Destroy (other.gameObject);
			}
		}
		*/
	}
}
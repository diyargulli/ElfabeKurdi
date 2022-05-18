using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {
	
	private float currentAmount;

	//private int currentAmount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentAmount = PlayerPrefs.GetFloat ("currentAmount");
		//.Log("Sound Amount   "+ PlayerPrefs.GetFloat("currentAmount"));
		if ( currentAmount> 0.85f) {
		//	Awake ();
			//Debug.Log("Sound Amount");
		}

	}
	void Awake(){
		//if (!gameObject.GetComponent<AudioSource> ().isPlaying) {
		//	gameObject.GetComponent<AudioSource> ().clip = succesSound;
		//	gameObject.GetComponent<AudioSource> ().PlayOneShot (succesSound);
		//}
//		Debug.Log("Sound Amount");
	}
}

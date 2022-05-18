using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Triger : MonoBehaviour {
	public GameObject[] Mysprt;

	public int idDragged=0 ;

	void Update(){
	//	Mysprt = PlayerPrefs.GetInt("Mysprt");
	
		//Debug.Log (gameObject.name);
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("..."+other.gameObject.tag);
		if (other.gameObject.tag == "step1" && idDragged == 1 ) {
			Destroy (other.gameObject);
			Mysprt[0].SetActive (true);
			Debug.Log (gameObject.name);
		}
	
	

	if (other.gameObject.tag == "step2" && idDragged == 2) {
		Destroy (other.gameObject);
		Mysprt[1].SetActive (true);
		Debug.Log (gameObject.name);
	}



		if (other.gameObject.tag == "step3"){// && idDragged == 3) {
	Destroy (other.gameObject);
	Mysprt[2].SetActive (true);
	Debug.Log (gameObject.name);
}

}
}

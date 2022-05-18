using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartColor : MonoBehaviour {
	public GameObject alphabet;
	// Use this for initialization
	void Start () {
	//	Colors currentColor = alphabet.GetComponent<Colors> ();
		//gameObject.GetComponent<Image> ().material = currentColor.mtrl;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Image> ().fillAmount != 1) {
			Colors currentColor = alphabet.GetComponent<Colors> ();
			gameObject.GetComponent<Image> ().material = currentColor.currMaterial;
		}
	}
}

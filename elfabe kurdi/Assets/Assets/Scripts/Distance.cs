using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour {
	public Image[] alphabet;
	//float lastDist = 0;
	//float lastDist2 = 0;
	public GameObject finger;
	public GameObject[] lastObj;
	public float dist ;
	public string trace;
//	float lastFillAmmount;
	float currentTimeAmount;
	public GameObject[] steps;
	int n = 0;
	float Devide=8;
	// Use this for initialization
	void Start () {n = 0;
//		lastFillAmmount = 0.0f;
		for (int i = 1; i < steps.Length; i++) {
			steps [i].SetActive (false);
			lastObj [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		trace = PlayerPrefs.GetString ("trace");
		dist =  Vector3.Distance (finger.transform.position, lastObj[n].transform.position);
		Debug.Log ((dist / Devide));
		Tracing.fillAmount = (dist / Devide);
			//if (dist > lastDist) {
		if (trace == "tracing") {

			if (dist >= 0.3f ){//&&alphabet[n].fillAmount != 1.0f) {
				if (alphabet [n].tag == "smallpart" ){
					dist += 4;Debug.Log ("fill"+alphabet [n].fillAmount);
					if (alphabet [n].fillAmount >= 0.5f) {
						alphabet [n].fillAmount = 1;
					}
				}

				alphabet[n].fillAmount = (dist / Devide);
				if (alphabet[n].fillAmount > 0.93f)
					alphabet[n].fillAmount = 1.0f;
				currentTimeAmount =alphabet[n].fillAmount ;
			}
			if (alphabet [n].fillAmount == 1.0f) {
				steps [n].SetActive (false);
				lastObj [n].SetActive (false);
				n++;
				steps [n].SetActive (true);
				lastObj [n].SetActive (false);

			}

		} else {
			if (alphabet[n].fillAmount != 1.0f) {
				currentTimeAmount -= 5 * Time.deltaTime;
				alphabet[n].fillAmount = currentTimeAmount / 1;
			}
		}
		//		lastDist = dist;

		//	}


		//Debug.Log ("dist is: " + dist+" fill is "+alphabet.fillAmount);
	}
}

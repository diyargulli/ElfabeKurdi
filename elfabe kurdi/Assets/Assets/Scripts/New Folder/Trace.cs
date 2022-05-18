using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Trace : MonoBehaviour {
	GameObject failSound;
	public Image part ;
	float generalDist;
	float generalDist2;

	float dist;
	float dist2;

	public GameObject firstObj;
	public GameObject centerObj;
	public GameObject lastObj;
	public GameObject finger;
	public GameObject particle;
	//public GameObject hand;
	public 	bool allowTrace;
	public bool isTrace = true;
	public float currentAmount;
//	float lastFill;

	// Use this for initialization
	void Start () {
		try{
		gameObject.GetComponent<PolygonCollider2D> ().isTrigger = true;
		}catch(MissingComponentException){
		}
		allowTrace=false;
		particle.SetActive (false);

		finger.SetActive (false);
		isTrace = true;
		//gameObject.AddComponent<AudioSource> ();
		failSound = GameObject.FindGameObjectWithTag("failSound");
		failSound.GetComponent<AudioSource>().playOnAwake = false;
	}

	// Update is called once per frame
	void Update () {

		if (gameObject.tag == "180degree") {
			generalDist = Vector3.Distance (firstObj.transform.position, centerObj.transform.position);
			dist = Vector3.Distance (finger.transform.position, firstObj.transform.position);

			generalDist2 = Vector3.Distance (centerObj.transform.position, lastObj.transform.position);
			dist2 = Vector3.Distance (finger.transform.position, lastObj.transform.position);
			if (allowTrace) {
				threeDist ();
			}
		}


		if (gameObject.tag == "vertical") {
			generalDist = Vector3.Distance (firstObj.transform.position, lastObj.transform.position);

			dist = Vector3.Distance (firstObj.transform.position, finger.transform.position);
			if (allowTrace) {

				VerticalDist();

			}
		}





		currentAmount = part.fillAmount;
		if (!allowTrace && currentAmount >= 0) {
	

			currentAmount -= 2 * Time.deltaTime;
			part.fillAmount = currentAmount / 1;
		

		} 
		//PlayerPrefs.SetFloat ("currentAmount", currentAmount);
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.touchCount == 0) {
				finger.SetActive (false);
				particle.SetActive (false);
				allowTrace = false;
				isTrace = true;
			}
		}
	}
	void Awake(){
		///if(isTrace)
		//	
	}
	void OnTriggerEnter2D(Collider2D other){
		//isTrace = false;



	}
	void OnTriggerExit2D(Collider2D other){
		//if (!isTrace && allowTrace) {
//		Debug.Log(PlayerPrefs.GetFloat ("currentAmount"));
		if (currentAmount<0.87f ){  //PlayerPrefs.GetFloat ("currentAmount") < 0.85f|| PlayerPrefs.GetFloat ("currentAmount") ==0f) {
			//if (!failSound.GetComponent<AudioSource> ().isPlaying) //{
			failSound.GetComponent<AudioSource> ().Play ();
		}
		isTrace = false;
		allowTrace = false;
		finger.SetActive (false);

		particle.SetActive (false);
		Debug.Log ("colider Exit");

	}
	void OnMouseDown(){
		//	isTrace = false;
		//	allowTrace = true;
		if (gameObject.tag == "dot")
			part.fillAmount = 1;
	}
	public void OnMouseUp () {Debug.Log ("mouseUp");

		finger.SetActive (false);
		particle.SetActive (false);
		allowTrace = false;
		isTrace = true;
	}
	void OnMouseEnter(){
		finger.SetActive (false);
		if (gameObject.tag == "180degree") {
			if ((dist / generalDist) < 0.4 && (dist / generalDist) < (dist2 / generalDist2)) {
				
				isTrace = true;
				if (isTrace) {
					allowTrace = true;
					particle.SetActive (false);
				}
			}
			//if (allowTrace) {
			//		threeDist ();
			//	}
		}//180degree

		if (gameObject.tag == "vertical") {
			if ((dist / generalDist) < 0.4) {
				isTrace = true;
				if (isTrace) {
					allowTrace = true;
					particle.SetActive (false);
				}
			}
			if (allowTrace) {

				VerticalDist();

			}
		}




		Debug.Log ("mouseEntered");
	}
	void OnMouseExit(){

		finger.SetActive (false);
		isTrace = false;
		allowTrace = false;
		finger.SetActive (false);

		particle.SetActive (false);

		Debug.Log ("mouse Exit");

	}

	public void OnMouseDrag () {

	

		if (gameObject.tag == "180degree") {
			if ((dist / generalDist) < 0.4 && (dist / generalDist) < (dist2 / generalDist2)&& isTrace)  {
				allowTrace = true;
				particle.SetActive (false);
			}
			if (allowTrace) {
				threeDist ();
			}
		}//180degree

		if (gameObject.tag == "vertical") {
			if ((dist / generalDist) < 0.4 && isTrace) {
				allowTrace = true;
				particle.SetActive (false);
			}
			if (allowTrace) {

				VerticalDist();

			}
		}

		isTrace = false;


		Debug.Log (allowTrace);
	}

	void VerticalDist(){
		//if (allowTrace) {
		part.fillAmount = (dist / generalDist);
		finger.SetActive (true);
		particle.SetActive (true);
		//	}
	}
	void threeDist(){


		if (dist / generalDist <= dist2 / generalDist2) {


			part.fillAmount = ((dist / generalDist) / 2);
//			lastFill = part.fillAmount;
			finger.SetActive (true);
			particle.SetActive (true);
		} else if (dist / generalDist > dist2 / generalDist2) {

			part.fillAmount = 1 - ((dist2 / generalDist2) / 2);
			finger.SetActive (true);
			particle.SetActive (true);

		}
	}
	public void FullDegree(){

		part.fillAmount = dist;
		finger.SetActive (true);
		particle.SetActive (true);
	}
	public void FailSound(){
		failSound.GetComponent<AudioSource> ().Play ();
	}
}

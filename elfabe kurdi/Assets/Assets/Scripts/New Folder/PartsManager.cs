using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsManager : MonoBehaviour {
//	public AudioClip succesSound;
	public Animator handFollow;
	public GameObject[] part;
	public Image[] imagePart;
	public int currentPart=0;
	public float currentAmount;
	private int animId;
	public int completed;
	private int sceneid;
	public bool isSoundPlayed;
	//Color[] mycolor={new Color(Color.blue),new Color (Color.red)   };



	public AudioClip succesSound;
	// Use this for initialization
	void Start () {
		isSoundPlayed = true;
		sceneid = PlayerPrefs.GetInt ("sceneid");
		gameObject.GetComponent<AudioSource> ().clip = null;
	//	Debug.Log (clr);
		currentAmount = 0;
		currentPart = 0;
		completed = 0;
		for (int i = 1; i < part.Length; i++) {
			part [i].SetActive (false);
			imagePart [i].fillAmount = 0;
		}

		part [0].SetActive (true);
		imagePart [0].fillAmount = 0;
		playFollow ();

		//	foreach (GameObject hand in hands)
//		hand.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		
		animId = PlayerPrefs.GetInt ("animId");
		//if(completed!=1)
		//completed = PlayerPrefs.GetInt ("completed");
		currentAmount = imagePart [currentPart].fillAmount;
		if (currentPart == part.Length) {
			currentPart = 0;
			currentAmount = 0;
		}

	
		if ((currentAmount >= 0.87f) && currentPart < part.Length) {
			Debug.Log ("currentAmount in mgr" + currentAmount);
			if (isSoundPlayed){
			gameObject.GetComponent<AudioSource> ().clip = succesSound;
			gameObject.GetComponent<AudioSource> ().PlayOneShot (succesSound);
				isSoundPlayed = false;
			}

			imagePart [currentPart].fillAmount += 0.02f;
		
			Debug.Log (currentAmount);
			part [currentPart].SetActive (false);
			if (imagePart [currentPart].fillAmount == 1) {
				
				if (currentPart < part.Length - 1) {
					isSoundPlayed = true;

				//	if(part[currentPart].GetComponent<GameObject>().is

					Debug.Log ("currentAmount in mgr" + currentAmount);
					currentPart++;
					part [currentPart].SetActive (true);
				
				
					//currAm
				}
			}
			//completed=0;
			//currentAmount = 0;
		}
		PlayerPrefs.SetFloat ("currentAmount", currentAmount);

		if (currentAmount == 0) {
			handFollow.gameObject.SetActive (true);
			playFollow ();
		} else
			handFollow.gameObject.SetActive (false);
	
		PlayerPrefs.SetInt ("currentPart", currentPart);
		//PlayerPrefs.SetFloat("currentAmount",currentAmount);




	}

	public void playFollow (){
		if (handFollow.isActiveAndEnabled) {
			handFollow.Play (sceneid + "_" + animId + "handFolow" + (1 + currentPart));
			Debug.Log (sceneid + "_" + animId + "handFolow" + (1 + currentPart) + "");
		}

	}
	public void Restart(){
		handFollow.gameObject.SetActive (false);
		Start ();
	}
}

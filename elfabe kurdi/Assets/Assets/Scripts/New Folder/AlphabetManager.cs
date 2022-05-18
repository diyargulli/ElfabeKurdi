using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlphabetManager : MonoBehaviour {
	public Animator AlphabetAnim;
	public GameObject registerPanel;
	public AudioClip succesSound;
	public AudioClip finalMusic;
	public Button nextbtn;
	//public GameObject[] alphabet;
	public GameObject[] alphabetImg;

	public Image[] alphabetImgfill;
	public AudioClip[] LetterSounds;
	private AudioClip LetterSound;

	public AudioSource source;
	public int id;
	public int currentPart;
	public Image timer;
	public Text timertxt;
	public Image[] starsActv;
	public Image[] starsActvBig;
	float timeAmount = 0;
	public Image panel;
	public Animator congrats;
	public GameObject[] scripts;
	private int matsId;
	public Text letterNumber;
	//int animeId=1;
	// Use this for initialization
	private int sceneid;
	void Start () { 
		sceneid = PlayerPrefs.GetInt ("sceneid");
		id= PlayerPrefs.GetInt ("id");
		Restart ();
		//registerPanel.SetActive(false);
		LetterSound = LetterSounds [id];

		source.clip = LetterSound;
		source.playOnAwake = false;
		source.PlayOneShot(LetterSound);
		letterNumber.text = (id +(int) 1).ToString () + "/34";

	
	}


	// Update is called once per frame
	void Update () {
		currentPart = PlayerPrefs.GetInt ("currentPart");
		if (PlayerPrefs.GetInt (sceneid+ "result" + id.ToString ()) > 0) {
			nextbtn.interactable = true;
		} else {
			nextbtn.interactable = false;
		}
		if (alphabetImgfill[id].fillAmount==1){// >= 0.9f) {
			//	alphabetImgfill [id].fillAmount = 1;
			PlayerPrefs.SetInt ("animId",id);	
			panel.gameObject.SetActive (true);

			congrats.SetBool ("starscongrats", true);
		}
		else
			panel.gameObject.SetActive (false);

		if (alphabetImgfill [id].fillAmount != 1) {
			timeAmount += 1 * Time.deltaTime;
			timertxt.text = ((int)timeAmount).ToString ();
			timer.fillAmount = (15 - timeAmount) / 15;
		
			if ((int)timeAmount >= 7 && (int)timeAmount <= 15) {

				starsActv [2].gameObject.SetActive (false);
				starsActvBig [2].gameObject.SetActive (false);
			}
			if (timeAmount > 15) {
				
				starsActv [1].gameObject.SetActive (false);
				starsActvBig [1].gameObject.SetActive (false);
			}
			PlayerPrefs.SetInt ("timeAmount", (int)Mathf.RoundToInt (timeAmount));
		}

		if (panel.isActiveAndEnabled) {
			AlphabetAnim.SetBool ("IsPanelActive", true);
			if (timeAmount < 7) {
				PlayerPrefs.SetInt (sceneid+ "result" + id.ToString (), 3);
			}
			if ((int)timeAmount >= 7 && (int)timeAmount <= 15) {
				PlayerPrefs.SetInt (sceneid+  "result" + id.ToString (), 2);
			}
			if (timeAmount > 15) {
				PlayerPrefs.SetInt (sceneid+  "result" + id.ToString (), 1);
			}
			//PlayerPrefs.SetInt ("result" + id.ToString (), Mathf.RoundToInt(timeAmount));

			if (gameObject.GetComponent<AudioSource> ().clip == null) {
				gameObject.GetComponent<AudioSource> ().clip = succesSound;
				gameObject.GetComponent<AudioSource> ().PlayOneShot (succesSound);
			}
			if (gameObject.GetComponent<AudioSource> ().clip == succesSound && gameObject.GetComponent<AudioSource> ().clip != finalMusic) {
				gameObject.GetComponent<AudioSource> ().clip = finalMusic;
				gameObject.GetComponent<AudioSource> ().PlayOneShot (finalMusic);
			}
			//gameObject.GetComponent<AudioSource> ().Play ();
		} else {
			gameObject.GetComponent<AudioSource> ().clip = null;
			AlphabetAnim.SetBool ("IsPanelActive", false);
		}
		//	else {


	}
	public void PlaySound(){
		LetterSound = LetterSounds [id];

		source.clip = LetterSound;
		source.playOnAwake = false;
	//	source.PlayOneShot(LetterSound);
		//LetterId2 = PlayerPrefs.GetInt ("LetterId");
		//	Debug.Log ("hello au " +LetterId2 );
		if(!source.isPlaying)
			source.PlayOneShot(LetterSound);




	}
	public void Next(){
		AlphabetAnim.SetBool ("IsPanelActive", false);
		if (id == alphabetImg.Length-1) {
			SceneManager.LoadScene ("LearnWorld"+PlayerPrefs.GetInt("sceneid"));
		}
		if (id < alphabetImg.Length - 1) {

			
				id += 1;
				//PlaySound ();
				if (id < alphabetImg.Length)
					Restart ();
			             
		} 

	
	
	
	}
	public void HideActivePanel(){
		registerPanel. SetActive(false);Time.timeScale = 1;
	}
	public void Previous(){
		if (id != 0) {
			gameObject.GetComponent<AudioSource> ().clip = null;
			id -= 1;
			//PlaySound ();
			Restart ();
		}
	}
	public void Restart(){

		PlayerPrefs.SetInt ("animId",id);	
		PartsManager restart = alphabetImg[id].GetComponent<PartsManager> ();

		restart.Restart();
		panel.gameObject.SetActive (false);


		for (int i = 0; i < alphabetImg.Length; i++) {
			alphabetImgfill [i].fillAmount = 0;
			if (i != id) {
				alphabetImg[i].SetActive (false);
			}
		}
		alphabetImg [id].SetActive (true);

		Reset ();

	}
	public void Reset(){


		timeAmount = 0;
		timertxt.text ="0";
		timer.fillAmount = (10 - timeAmount) / 10;
	
		starsActv[0].gameObject.SetActive(true); 
		starsActv[1].gameObject.SetActive(true);
		starsActv[2].gameObject.SetActive(true);

		starsActvBig[0].gameObject.SetActive(true); 
		starsActvBig[1].gameObject.SetActive(true);
		starsActvBig[2].gameObject.SetActive(true);
		PlaySound ();
		letterNumber.text = (id +(int) 1).ToString () + "/34";
	}
}

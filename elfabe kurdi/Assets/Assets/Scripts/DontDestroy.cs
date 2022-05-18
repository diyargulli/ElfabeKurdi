using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroy : MonoBehaviour {
	public AudioClip myClip;
//	Scene scene;
	GameObject[] obj;
	// Use this for initialization
	void Start () {
		obj = GameObject.FindGameObjectsWithTag ("music");
	}
	void Update(){
	//	scene= SceneManager.GetActiveScene ();
			Awake ();

		}
	void Awake () {
		obj = GameObject.FindGameObjectsWithTag ("music");
		DontDestroyOnLoad (this.gameObject );


			
		if (!gameObject.GetComponent<AudioSource> ().isPlaying ) {
			
			gameObject.GetComponent<AudioSource> ().clip =myClip;
			gameObject.GetComponent<AudioSource> ().Play ();
		}
		if (obj.Length > 1) 
			Destroy (this.gameObject);

	}
	private void playSound1(){
		//gameObject.GetComponent<AudioSource> ().PlayOneShot(myClip);
	}
}

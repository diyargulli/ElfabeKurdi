using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetTitle : MonoBehaviour {
	public int id;
	private int sceneid;
	public int leterssize;
	private int worldIndex;   
	private int levelIndex;
	//variable which holds the stars obtained   
	//public GameObject[] stars;
	private GameObject star1;
	private GameObject star2;
	private GameObject star3;
	public int result;
	public int idTemp;
	private GameObject unlockedLevel;
		// Use this for initialization
		void Start () {
       // PlayerPrefs.DeleteAll();
		sceneid= PlayerPrefs.GetInt ("sceneid");
		leterssize = 33;
		if (sceneid == 1)
			leterssize = 30;
		if (id != 0) {
			
			unlockedLevel = GameObject.Find (sceneid+"unlocked (" + id + ")");
		}
		star1 = GameObject.Find ( "str"+sceneid+"_"+id+"_"+ 1);
		star2 = GameObject.Find ( "str"+sceneid+"_"+id+"_"+ 2);
		star3 = GameObject.Find ( "str"+sceneid+"_"+id+"_"+ 3);
		Debug.Log("str"+sceneid+"_"+id+"_"+ 3);
		star1.SetActive (false);
		star2.SetActive (false);
		star3.SetActive (false);
		//stars [0].SetActive (false);
	//	stars [1].SetActive (false);
		//stars [2].SetActive (false);
		//PlayerPrefs.GetInt (sceneid+  "result" + id.ToString ());
		//result=	PlayerPrefs.GetInt ("result" + id.ToString ());
		//	Debug.Log("result"+	PlayerPrefs.GetInt ("result" + id.ToString ()));
		if (PlayerPrefs.GetInt (sceneid+  "result" + id.ToString ())==3) {
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (true);
		}
		if (PlayerPrefs.GetInt (sceneid+  "result" + id.ToString ()) == 2) {
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (false);
		}

		if (PlayerPrefs.GetInt (sceneid+  "result" + id.ToString ()) == 1) {
			star1.SetActive (true);
			star2.SetActive (false);
			star3.SetActive (false);
		}
		if (id < leterssize) {
			if (PlayerPrefs.GetInt (sceneid+  "result" + id.ToString ()) == 0 ) {

				GameObject.Find (sceneid+"unlocked (" + (1+id) + ")").SetActive (true);

			} else {
				//if ((id >=8 && id < leterssize) &&
				///	PlayerPrefs.GetString ("DeviceId") == PlayerPrefs.GetString ("plText")&&
				//	PlayerPrefs.GetString ("plText")!="") {
				///	GameObject.Find (sceneid+"unlocked (" + (1+id) + ")").SetActive (false);
			//	}else if(id <=7){
					GameObject.Find (sceneid+"unlocked (" + (1+id) + ")").SetActive (false);
				//}

			}
		}
	}
			
	void Update(){

		if (id > 0 && unlockedLevel!= null) {
			if (unlockedLevel.activeInHierarchy ) {
				gameObject.GetComponent<Button> ().interactable = false;
			} else {
				gameObject.GetComponent<Button> ().interactable = true;	
			}

		}
	
	}

	// Use this for initialization
	//public void SetId(){
	//	PlayerPrefs.SetInt("id",id);

	//}
	void  CheckLockedLevels (){
		
	}
}

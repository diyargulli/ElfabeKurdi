using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Language : MonoBehaviour {
	
	public Button badini;
	public Button sorani;
	public Button kurmanci;
	public GameObject[] LatiniTxts;
	public Sprite[] _sendCodes;
	public Sprite[] _userCodes;
	public Sprite[] _sendBalances;
	public Sprite[] _scrollContents;


	public Image userCodeImg;
	public Image sendBalance;
	public Image scrollContent;
	public GameObject _ScrollView;
	// Use this for initialization
	void Start () {
		LatiniTxts = GameObject.FindGameObjectsWithTag ("latiniLang");
		_ScrollView.SetActive (false);
		for (int i = 0; i < LatiniTxts.Length; i++) {
			LatiniTxts [i].SetActive( false);
		}
		if (PlayerPrefs.GetInt("sceneid")==1)
			Kurmanci ();
		else 
		Badini ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Sorani(){
		kurmanci.GetComponent<Image> ().color = Color.grey;
		badini.GetComponent<Image> ().color = Color.grey;
		sorani.GetComponent<Image> ().color = Color.green;
		for (int i = 0; i < LatiniTxts.Length; i++) {
			LatiniTxts [i].SetActive( false);
		}
		ActiveObj ();

		userCodeImg.sprite= _userCodes [1];
		sendBalance.sprite= _sendBalances [1];
		scrollContent.sprite = _scrollContents [1];
	}
	public void Badini(){
		badini.GetComponent<Image> ().color = Color.green;
		sorani.GetComponent<Image> ().color = Color.grey;
		kurmanci.GetComponent<Image> ().color = Color.grey;
		for (int i = 0; i < LatiniTxts.Length; i++) {
			LatiniTxts [i].SetActive( false);
		}
		ActiveObj ();

		userCodeImg.sprite = _userCodes [0];
		sendBalance.sprite = _sendBalances [0];
		scrollContent.sprite = _scrollContents [0];
	}
	public void Kurmanci(){
		kurmanci.GetComponent<Image> ().color = Color.green;
		sorani.GetComponent<Image> ().color = Color.grey;
		badini.GetComponent<Image> ().color = Color.grey;


		DeActiveObj ();


		for (int i = 0; i < LatiniTxts.Length; i++) {
			LatiniTxts [i].SetActive( true);
		}
	}
	public void DeActiveObj(){
		
		userCodeImg.gameObject.SetActive (false);
		sendBalance.gameObject.SetActive (false);
		scrollContent.gameObject.SetActive (false);
	}
	public void ActiveObj(){
		
		userCodeImg.gameObject.SetActive (true);
		sendBalance.gameObject.SetActive (true);
		scrollContent.gameObject.SetActive (true);
	}

}

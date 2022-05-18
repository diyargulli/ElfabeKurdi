using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	public Image panel;
	public GameObject imgtLoading;
	public Transform loadingBar;
	public Text txtsec;
	public Text txtChirke;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;

	public Button btnExit;
	private bool isclicked;
	private string  sceneName="Letters";
	// Use this for initialization
	void Start () {
		//panel.gameObject.SetActive( false);
		currentAmount = 2;
		txtsec.text = currentAmount.ToString();
		loadingBar.GetComponent<Image> ().fillAmount = 1;
		imgtLoading.SetActive( false);
	}
	void Update(){
	//	if (isclicked) {
		//	panel.gameObject.SetActive( true);
		//	imgtLoading.SetActive( true);
			if (currentAmount > 0) {
				currentAmount -= speed * Time.deltaTime;
				loadingBar.GetComponent<Image> ().fillAmount = currentAmount / 2;// timerLoading;
				txtsec.GetComponent<Text> ().text = ((int)currentAmount).ToString ();

				//loadingBar.gameObject.SetActive = true;
			} else {
				//			txtsec.gameObject.SetActive = false;

			}
		//}

		if (loadingBar.GetComponent<Image> ().fillAmount == 0.0f && float.Parse( txtsec.text) == 0.0f)
			SceneManager.LoadScene (sceneName);

	}
	// Update is called once per frame
	public void TimerExit(bool isThisclicked)//string sceneName)
	{
		isclicked = isThisclicked; 
		if (!isclicked) {
			panel.gameObject.SetActive( false);
			currentAmount = 2;
			txtsec.text = currentAmount.ToString ();
			loadingBar.GetComponent<Image> ().fillAmount = 1;
			imgtLoading.SetActive (false);
		} else {

			Update ();
		}

	}
	public void scene(string setSceneName){
		//sceneName = setSceneName;
	}
}

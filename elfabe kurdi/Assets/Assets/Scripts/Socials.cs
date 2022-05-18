using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Socials : MonoBehaviour {
	public bool play;
	public Animator btnShare;
	public GameObject panel;

	bool isClicked = true;
	// Use this for initialization
	void Start () {
		
	}
	void Update(){
	}
public	void Animate(){
		if (isClicked) PlayAnim ();
		else if (!isClicked) StopAnim();
	}
	public void PlayAnim()
	{
		isClicked = false;
	
		btnShare.SetBool ("Sharebtn", true);
	}
	public void StopAnim(){
		isClicked = true;
			btnShare.SetBool ("Sharebtn", false);
	}
	public void Website(){
		Application.OpenURL ("http://badinangroup.com");
	}
	public void Facebook(){
		Application.OpenURL ("https://m.facebook.com/BadinanGroup/");
	}
    public void LinkeIn()
    {
        Application.OpenURL("https://www.linkedin.com/company-beta/18163838/");
    }
	public void GooglePlus()
	{
		Application.OpenURL ("https://plus.google.com/106400566353758821863");
	}
	public void PlayStore()
	{
		Application.OpenURL ("https://play.google.com/store/apps/developer?id=Badinan+Soft");
	}
	public void OpenPanel(){
		panel.SetActive (true);
	}
	public void ExitPanel(){
		panel.SetActive (false);
	}
    public void QuitAPP()
    {
       
		Application.Quit ();
    }


}

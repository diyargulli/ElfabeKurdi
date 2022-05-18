using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagager : MonoBehaviour {
	private Image lockLevel;
	 Scene goToScene;
	public string activeSceneName;

	void Start(){


	}
	public void Scene(string sceneName){
		Time.timeScale = 1;
		goToScene = SceneManager.GetActiveScene();
		activeSceneName = goToScene.name;

		PlayerPrefs.SetString("activeSceneName", activeSceneName);
	
		SceneManager.LoadScene (sceneName);


		//}
	}
	public void setSceneId(int sceneid){
		PlayerPrefs.SetInt ("sceneid", sceneid);
	}
	public void SetId(int id){
	//	if (lockLevel.IsActive = true) {
			PlayerPrefs.SetInt ("id", id);
	//	}

	}
	public void clearData(){
		PlayerPrefs.DeleteAll();

	}
}

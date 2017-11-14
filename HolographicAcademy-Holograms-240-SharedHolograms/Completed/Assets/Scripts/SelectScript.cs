using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScript : MonoBehaviour {
	public bool DesktopVersion = false;
	public List<GameObject> desktopObjects;
	// Use this for initialization
	void Start () {
		foreach (GameObject obj in desktopObjects) {
			obj.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && (DesktopVersion == false)) {
			//POLY.1(Clone)
			GameObject selectedplayer = null;
			selectedplayer = GameObject.Find ("P0LY.1(Clone)");
			Debug.Log ("Desktop Enables for {0}", selectedplayer);
			if (null != selectedplayer) {
				selectedplayer.GetComponent<AvatarSelector>().OnSelect();
			}
			DesktopVersion = true;
			foreach (GameObject obj in desktopObjects) {
				obj.SetActive(true);
			}
		}
	}
}

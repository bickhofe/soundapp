using UnityEngine;
using System.Collections;

public class CreateClouds : MonoBehaviour {

	public Main MainScript;
	public GameObject Cloud;
	
	// Use this for initialization
	void Start () {
		InitClouds();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void InitClouds(){
		for (int i = 0; i<MainScript.maxClouds; i++) {
			GameObject newCloud = Instantiate(Cloud, new Vector3(-6 + i, 0, -1), Quaternion.identity) as GameObject;
			float scale = Random.Range(.75f,1.25f);
			newCloud.transform.localScale = new Vector3(scale,scale,scale);
			newCloud.transform.parent = transform; 
		}
	}
}

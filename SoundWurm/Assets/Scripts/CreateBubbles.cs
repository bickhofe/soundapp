using UnityEngine;
using System.Collections;

public class CreateBubbles : MonoBehaviour {
	
	public int maxBubbles = 3;
	public GameObject Bubble;

	// Use this for initialization
	void Start () {
		InitBubbles();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void InitBubbles(){
		for (int i = 0; i<maxBubbles; i++) {
			GameObject newBubble = Instantiate(Bubble, new Vector3(-5 + i*5, 0, 0), Quaternion.identity) as GameObject;
			newBubble.transform.parent = transform; 
		}
	}
}

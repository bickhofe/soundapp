using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

	public Main MainScript;
	float bubbleHeight;
	float offset;

	// Use this for initialization
	void Start () {
        offset = Random.Range(1f, 1.5f);
        MainScript = GameObject.Find ("Main").GetComponent<Main> ();
	}
	
	// Update is called once per frame
	void Update () {
		//hover
		if (MainScript.gamePhase == 0) bubbleHeight = 3;
		else if (MainScript.gamePhase == 1 && bubbleHeight > 0) bubbleHeight -= 0.01f;
		transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time,offset)+bubbleHeight, transform.position.z);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("hit");
		if (other.gameObject.tag == "Worm") {
			Instantiate(MainScript.instruments[MainScript.bubbleCount], transform.position, Quaternion.Euler(new Vector3 (0,0,Random.Range(0,360))));
			Destroy(gameObject);
			MainScript.bubbleCount++;
		}
	}
}

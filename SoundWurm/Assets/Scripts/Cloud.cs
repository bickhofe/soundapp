using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
	
	float offset = Random.Range(1f,2f);
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//hover
		transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time/2,offset)+4, transform.position.z);
	}
	
//	void OnTriggerEnter2D(Collider2D other) {
//		Debug.Log("hit")
//		if (other.gameObject.tag == "Player") {
//			gameObject.SetActive(false);
//		}
//	}

}

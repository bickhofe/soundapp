using UnityEngine;
using System.Collections;

public class Wurm : MonoBehaviour {


	public Main MainScript;

	Vector2 touchPosition;

	public float speed = 2f;
	public float jumpForce = 2f;
	public bool isJumping = false;
	bool isTouching = false;
	bool canMove = false;
	float velocity = 0;
	float height = 0;
	public float groundLevel = -30;

	public float gravity = .5f;
	Vector3 worldPos;
	Vector3 targetPos;
	public GameObject[] Worm;
	public float[] tailOffset;

	// Use this for initialization
	void Start () {
		height = -4;
		velocity = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//gravity
		velocity -= gravity;
		height += velocity;

		if (height < groundLevel) {
			height = groundLevel;
			velocity = 0;
			isJumping = false;
		}

		// touch control
		if (MainScript.character == "Worm") {
			if (Input.touchCount > 0 && !isJumping){
				touchPosition = Input.GetTouch(0).position;
				worldPos = Camera.main.ScreenToWorldPoint (new Vector3 (touchPosition.x, 50, 10));
				isTouching = true;
			}

			if (Input.touchCount == 0 && isTouching) {
				velocity = jumpForce;
				isJumping = true;
				isTouching = false;
				MainScript.character = "";
			}
		}

		//set x & y position
		targetPos = new Vector3 (worldPos.x, height, -2);

		//worm move
		for (int i=0; i<4; i++){
			Worm[i].transform.position = Vector3.MoveTowards(Worm[i].transform.position, targetPos, tailOffset[i]);
		}
	}
}


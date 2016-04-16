using UnityEngine;
using System.Collections;

public class Wurm : MonoBehaviour {


	public Main MainScript;

	Vector2 touchPosition;
	Vector3 mousePosition;

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

	// Use this for initialization
	void Start () {
		height = groundLevel;
		velocity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		// touch control
		if (MainScript.character == "Worm") {
			
			if (Input.touchCount > 0 && !isJumping){
				isTouching = true;
				touchPosition = Input.GetTouch(0).position;
				worldPos = Camera.main.ScreenToWorldPoint (new Vector3 (touchPosition.x, 50, 10));				
			}

//			if (Input.GetMouseButton(0) && !isJumping){
//				isTouching = true;
//				mousePosition = Input.mousePosition;
//				worldPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePosition.x, 50, 10));
//			}

			if (Input.touchCount == 0 && isTouching) {
				velocity = jumpForce;
				isJumping = true;
				isTouching = false;
				MainScript.character = "";
			}

//			if (Input.GetMouseButtonUp(0)) {
//				velocity = jumpForce;
//				isJumping = true;
//				isTouching = false;
//				MainScript.character = "";
//			}
		}
			
		if (!isJumping) {
			targetPos = new Vector3 (worldPos.x, height, -2);
			// set horizontal worm position (move)
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, targetPos, step);
		} else {
			//gravity
			print (height);
			velocity -= gravity;
			height += velocity;

			// gelandet
			if (height < groundLevel) {
				height = groundLevel;
				velocity = 0;
				isJumping = false;
			}

			// set vertical worm position
			targetPos = new Vector3(transform.position.x,height,-2);
			transform.position = targetPos;
		}
			
		//flip worm
		if (targetPos.x < transform.position.x) transform.localScale = new Vector3(-1,1,1);
		else transform.localScale = new Vector3(1,1,1);
	}
}


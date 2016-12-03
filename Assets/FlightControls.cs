using UnityEngine;
using System.Collections;

public class FlightControls : MonoBehaviour {
	public const float MAX_X = 7.5f, MAX_Y = 3,
		MAX_Z = 2, MIN_X = -7.5f, MIN_Y = -3,
		MIN_Z = -2;

	private float xSpeed, ySpeed, boostSpeed, brakeSpeed, resetXSpeed, resetYSpeed, resetZSpeed;
	// Use this for initialization
	void Start () {
		xSpeed = 5;
		ySpeed = 3;
		boostSpeed = 3;
		brakeSpeed = -2;
		resetXSpeed = .5f;
		resetYSpeed = 1;
		resetZSpeed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		float velocityX, velocityY, velocityZ;

		float newX, newY, newZ;

		if (Input.GetKey(KeyCode.D)) {
			velocityX = xSpeed;
		} else {
			velocityX = 0;
		}

		if (Input.GetKey(KeyCode.A)) {
			velocityX -= xSpeed;
		}

		if (Input.GetKey(KeyCode.W)) {
			velocityY = ySpeed;
		} else {
			velocityY = 0;
		}

		if (Input.GetKey(KeyCode.S)) {
			velocityY -= ySpeed;
		}

		// Boost
		if (Input.GetKey(KeyCode.R)) {
			velocityZ = boostSpeed;
			// Brake
		} else if (Input.GetKey(KeyCode.Z)) {
			velocityZ = brakeSpeed;
		} else {
			velocityZ = 0;
		}

		if (transform.localPosition.x + velocityX * Time.deltaTime > MAX_X) {
			newX = MAX_X;
			velocityX = 0;
		} else if (transform.localPosition.x + velocityX * Time.deltaTime < MIN_X) {
			newX = MIN_X;
			velocityX = 0;
		} else {
			newX = transform.localPosition.x;
		}

		if (transform.localPosition.y + velocityY * Time.deltaTime > MAX_Y) {
			newY = MAX_Y;
			velocityY = 0;
		} else if (transform.localPosition.y + velocityY * Time.deltaTime < MIN_Y) {
			newY = MIN_Y;
			velocityY = 0;
		} else {
			newY = transform.localPosition.y;
		}

		if (transform.localPosition.z + velocityZ * Time.deltaTime > MAX_Z) {
			newZ = MAX_Z;
			velocityZ = 0;
		} else if (transform.localPosition.z + velocityZ * Time.deltaTime < MIN_Z) {
			newZ = MIN_Z;
			velocityZ = 0;
			// Reset to 0 if not braking or boosting
		} else if (velocityZ == 0 && transform.localPosition.z < 0) {
			velocityZ = resetZSpeed;
			if (transform.localPosition.z + velocityZ * Time.deltaTime > 0) {
				newZ = 0;
				velocityZ = 0;
			} else {
				newZ = transform.localPosition.z;
			}
		} else if (velocityZ == 0 && transform.localPosition.z > 0) {
			velocityZ = -resetZSpeed;
			if (transform.localPosition.z + velocityZ * Time.deltaTime < 0) {
				newZ = 0;
				velocityZ = 0;
			} else {
				newZ = transform.localPosition.z;
			}
		} else {
			newZ = transform.localPosition.z;
		}

		// This makes sure the ship doesn't go beyond the boundaries;
		transform.localPosition = new Vector3(newX, newY, newZ);

		transform.Translate(velocityX * Time.deltaTime, velocityY * Time.deltaTime, velocityZ * Time.deltaTime);
	}
}

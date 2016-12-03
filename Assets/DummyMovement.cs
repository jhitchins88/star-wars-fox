using UnityEngine;
using System.Collections;

public class DummyMovement : MonoBehaviour {
	public Vector3 heading;
	public Vector3 up;

	private float currentAngle;
	private float radius;
	private Vector3 centerPoint;

	// Use this for initialization
	void Start () {
		currentAngle = 0;
		radius = 102;
		heading = Vector3.forward;
		up = Vector3.up;
		centerPoint = new Vector3 (-10, 3, 10);
	}
	
	// Update is called once per frame
	void Update () {
		heading = new Vector3 (Mathf.Sin (currentAngle + 90), 0, Mathf.Cos (currentAngle + 90));
		up = ( centerPoint + Vector3.up * radius) -  transform.position;

		transform.position = centerPoint + new Vector3(radius * Mathf.Sin (currentAngle), 0, radius * Mathf.Cos (currentAngle));
		transform.rotation = Quaternion.LookRotation (heading, up);

		currentAngle += .002f;
	}
}

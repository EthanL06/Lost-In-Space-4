//create a script that rotates an object in 3d space
using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	public float xSpeed = 0f;
	public float ySpeed = 0f;
	public float zSpeed = 0f;
	// Update is called once per frame
	void Update () {
		transform.Rotate (xSpeed, ySpeed, zSpeed);
	}
}
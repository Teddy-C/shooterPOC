using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.networkView.isMine) {
			InputMovement ();
		}
	
	}

	void InputMovement()
	{
		if (Input.GetKey (KeyCode.Z))
			this.rigidbody.MovePosition (this.rigidbody.position + Vector3.forward * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.S))
			this.rigidbody.MovePosition (this.rigidbody.position - Vector3.forward * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.D))
			this.rigidbody.MovePosition (this.rigidbody.position + Vector3.right * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.Q))
			this.rigidbody.MovePosition (this.rigidbody.position - Vector3.right * speed * Time.deltaTime);
	}

}

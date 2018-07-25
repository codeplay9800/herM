using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollController : MonoBehaviour {

	public Animator anim;

	public Rigidbody[] rbs;

	public Rigidbody head, groin;

	// Use this for initialization
	void Start () {
		rbs = GetComponentsInChildren<Rigidbody> ();
		foreach (Rigidbody rb in rbs) {
			rb.isKinematic = true;
			rb.useGravity = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {

			anim.enabled = false;
			foreach (Rigidbody rb in rbs) {
				rb.isKinematic = false;
				rb.useGravity = true;
			}

			head.AddForce (Vector3.right * 5000);

		}
	}
}

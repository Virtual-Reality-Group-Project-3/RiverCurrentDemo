using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Based off http://answers.unity3d.com/questions/624114/a-simple-ladder-in-c-or-js.html
public class LadderClimberC : MonoBehaviour {
	private Transform selfTransform;
    public float speed = 1;
	public bool disableGravityUponEnter = true;
	public HashSet<GameObject> salmonSet = new HashSet<GameObject> ();

    public void Start() {
		selfTransform = this.GetComponent<Transform>();
    }
    public void OnTriggerEnter(Collider collider) {
		Debug.Log ("Entered " + collider.gameObject.name);
		if (collider.gameObject.CompareTag ("salmon")) {
			salmonSet.Add (collider.gameObject);
			if (disableGravityUponEnter) {
				collider.gameObject.GetComponent<Rigidbody> ().useGravity = false;
			}
		}
    }

    public void OnTriggerExit(Collider collider) {
	if (collider.gameObject.CompareTag ("salmon")) {
		salmonSet.Remove (collider.gameObject);
			if (disableGravityUponEnter) {
				collider.gameObject.GetComponent<Rigidbody> ().useGravity = true;
			}
		}
    }

    public void Update() {
		Debug.Log ("Self is " + selfTransform);
		Vector3 direction = new Vector3( selfTransform.rotation.x,selfTransform.rotation.y,selfTransform.rotation.z);
		//Ok, we have direction, lets normalize it! Calc 3 stuff!
		//Oh wait, unity has this built in.
		direction.Normalize();
		Vector3 movementVector = direction * Time.deltaTime * speed;
		foreach ( GameObject obj in salmonSet ) {
			//obj.transform.
			//Move it forward here
			obj.transform.Translate(movementVector);

		}
    }
}

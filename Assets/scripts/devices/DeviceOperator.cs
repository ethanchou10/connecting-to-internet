using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeviceOperator : MonoBehaviour {
	public float radius = 1.5f;

	void Update() {
		if (Input.GetKeyDown(KeyCode.C)) {
			Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
			foreach (Collider hitCollider in hitColliders) {
				hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}

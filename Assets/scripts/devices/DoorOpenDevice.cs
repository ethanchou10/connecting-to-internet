using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorOpenDevice : MonoBehaviour {
	[SerializeField] private Vector3 dPos;

	private bool _open;

	public void Operate() {
		if (_open) {
			Debug.Log("close");
			Vector3 pos = transform.position - dPos;
			transform.position = pos;
		} else {
			Debug.Log("open");
			Vector3 pos = transform.position + dPos;
			transform.position = pos;
		}
		_open = !_open;
	}

	public void Activate() {
		if (!_open) {
			Debug.Log("open");
			Vector3 pos = transform.position + dPos;
			transform.position = pos;
			_open = true;
		}
	}

	public void Deactivate() {
		if (_open) {
			Debug.Log("close");
			Vector3 pos = transform.position - dPos;
			transform.position = pos;
			_open = false;
		}
	}
}

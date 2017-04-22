using UnityEngine;
using System.Collections;

public class InputWrapper : MonoBehaviour {

	// A custom class to capture keyboard and virtual input

	private bool _enabled = true;
	private static InputWrapper _instance;

	public static InputWrapper Instance {
		get {
			if(_instance == null) {
				GameObject go = new GameObject("InputWrapper");
				go.AddComponent<InputWrapper>();
			}
			return _instance;
		}
	}

	private void Awake() {
		_instance = this;
	}

	public void EnableInput(bool enabled) {
		_enabled = enabled;
	}

	public bool GetRigth() {
		return _enabled && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D));
	}

	public bool GetLeft() {
		return _enabled && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A));
	}

	public bool GetUp() {
		return _enabled && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W));
	}
    
}

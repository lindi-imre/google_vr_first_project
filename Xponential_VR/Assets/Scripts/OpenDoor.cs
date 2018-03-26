using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
	bool is_gazed = false;
	float timer = 0f;

	public float lookToOpenTime = 2f;
	public bool is_opened = false;

	RectTransform rectTransform;

	void Awake() {
		rectTransform = GameObject.Find ("ProgressBar").GetComponent<RectTransform> ();
	}

	// Update is called once per frame
	void Update () {
		if (is_gazed) {
			timer += Time.deltaTime;

			rectTransform.sizeDelta = new Vector2 ((timer / lookToOpenTime) * 100, 5);
		}

		if (timer > lookToOpenTime && is_gazed) {
			is_gazed = false;
			timer = 0f;
			rectTransform.sizeDelta = Vector2.zero;
			is_opened = !is_opened;
			OpenOrCloseDoor (is_opened);
		}
	}


	public void SetGazedAt(bool gazedAt) {
		is_gazed = gazedAt;
		if (!gazedAt) {
			timer = 0f;
			rectTransform.sizeDelta = Vector2.zero;
		}
	}

	void OpenOrCloseDoor(bool is_opening) {
		transform.parent.gameObject.GetComponent<Animator> ().enabled = true;

		if (is_opening) {
			transform.parent.gameObject.GetComponent<Animator> ().Play ("door_anim");
		} else {
			transform.parent.gameObject.GetComponent<Animator> ().Play ("door_close_anim");
		}

	}
}

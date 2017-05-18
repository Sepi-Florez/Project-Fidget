using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
    public float force;
    public float deceleration;

    public float lerpTime;
    public float currentLerpTime;

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            currentLerpTime = 0;
            force += 10;

        }
        currentLerpTime += Time.deltaTime;
        if(currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }
        float t = currentLerpTime / lerpTime;
        t = Mathf.Sin(t * Mathf.PI * 0.5f);
        force = Mathf.Lerp(force, 0, t);
        transform.Rotate(0, 0, force);
        if(force <= 0.1) {
            force = 0;
        }
    }
}

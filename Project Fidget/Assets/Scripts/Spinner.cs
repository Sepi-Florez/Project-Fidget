using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {
    public static Spinner thisSpinner;

    public bool spinState;
    public delegate void Stopped();
    public event Stopped stoppedDelegate; 

    public float force;
    public float deceleration;

    public float lerpTime;
    public float currentLerpTime;

    public float spinProgress;
    public int spinCount;

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            spinState = true;
            currentLerpTime = 0;
            force += 3;
        }
        if(force != 0) {
            SpinFormula();
            SpinCount();
        }
        else if(spinState == true){
            spinState = false;
            if(stoppedDelegate != null) {
                stoppedDelegate();
            }
        }
    }
    void SpinCount() {
        spinProgress += force;
        if (spinProgress >= 360) {
            spinCount++;
            spinProgress -= 360;
            UIManager.thisManager.SpinAdd(spinCount);
        }
    }
    void SpinFormula() {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }
        float t = currentLerpTime / lerpTime;
        t = Mathf.Sin(t * Mathf.PI * 0.5f);
        force = Mathf.Lerp(force, 0, t);
        transform.Rotate(0, 0, force);
        if (force <= 0.1) {
            force = 0;
        }
    }
}

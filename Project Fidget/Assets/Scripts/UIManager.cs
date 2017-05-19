using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager thisManager;

    public Text spinCounter;

    void Awake() {
        thisManager = this;
    }
    void Start() {
        FindObjectOfType<Spinner>().stoppedDelegate += SpinStopped;
    }
    public void SpinAdd(int count) {
        spinCounter.text = count.ToString();
    }
    public void SpinStopped() {
        print("Spinner has stopped, Total spins : " + spinCounter.text);
    }
}

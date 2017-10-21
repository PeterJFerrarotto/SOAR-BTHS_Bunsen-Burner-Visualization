using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizationManager : MonoBehaviour {
    public Text intakeRateVal;
    public BunsenBurner burner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        intakeRateVal.text = (burner.AirIntakeRate * 100).ToString("0");
	}
}

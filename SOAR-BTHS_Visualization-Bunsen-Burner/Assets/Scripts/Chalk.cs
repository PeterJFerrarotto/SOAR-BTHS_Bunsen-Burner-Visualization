using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalk : MonoBehaviour {
    public GameObject soot;

    private int particleCollCount;
    public int particleCollCutoff;

	// BunsenBurner burner = GameObject.Find ("BunsenBurner").GetComponent <BunsenBurner>();
	public float intake; 

	// Use this for initialization
	void Start () {
        particleCollCount = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		intake = GameObject.Find ("BunsenBurner").GetComponent <BunsenBurner>().AirIntakeRate;
		soot.SetActive(particleCollCount >= particleCollCutoff && intake < 0.75);
	}

    private void OnDisable()
    {
        soot.SetActive(false);
        particleCollCount = 0;
    }

    private void OnParticleCollision(GameObject other)
    {
        particleCollCount++;   
    }
}

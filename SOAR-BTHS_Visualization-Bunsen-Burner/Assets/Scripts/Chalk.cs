using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalk : MonoBehaviour {
    public GameObject soot;

    private int particleCollCount;
    public int particleCollCutoff;

	// Use this for initialization
	void Start () {
        particleCollCount = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        soot.SetActive(particleCollCount >= particleCollCutoff);
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

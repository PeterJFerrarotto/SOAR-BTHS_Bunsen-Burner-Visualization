using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunsenBurner : MonoBehaviour {
    public GameObject intakeRing;
    public float minIntakeRingRot;
    public float maxIntakeRingRot;

    [SerializeField]
    private ParticleSystem flame1;

    [SerializeField]
    private ParticleSystem flame2;

	[SerializeField]
	private ParticleSystem flame3;

	[SerializeField]
	private ParticleSystem flame4a;
	[SerializeField]
	private ParticleSystem flame4b;

    public float baseLifeTimeCore;
    public float baseLifeTimeOuter;

    public float coreLifeTimeAdd;
    public float outerLifeTimeAdd;

    public float CutOff1;
	public float CutOff2;
	public float CutOff3;

    //air intake from 0 to 1
    private float airIntakeRate;

	private bool burnerOn = false;
	/*
    public bool OuterFlameOn
    {
        get
        {
            return flameOuter.isPlaying;
        }
    }
	*/
    public static float AirIntakeRate
    {
        get
        {
            return airIntakeRate;
        }
        set
        {
            if (value >= 0 && value <= 1)
            {
                airIntakeRate = value;
            }
            else if (value > 1)
            {
                airIntakeRate = 1.0f;
            }
            else if (value < 0)
            {
                airIntakeRate = 0.0f;
            }
        }
    }

	// Use this for initialization
	void Start () {
        airIntakeRate = 0;
        intakeRing.transform.localRotation = new Quaternion(0, minIntakeRingRot, 0, 0);
		flame1.Stop();
	}
	
	// Update is called once per frame
	void Update () {
        //intakeRing.transform.localRotation = Quaternion.Lerp(new Quaternion(0, minIntakeRingRot, 0, 0), new Quaternion(0, maxIntakeRingRot, 0, 0), airIntakeRate);
        //intakeRing.transform.eulerAngles = new Vector3(0, minIntakeRingRot + airIntakeRate * maxIntakeRingRot, 0);
        //ParticleSystem.MainModule mod = flame1.main;
        //mod.startLifetime = baseLifeTimeCore + airIntakeRate * coreLifeTimeAdd;

		flame1.gameObject.SetActive(burnerOn && CutOff1 > airIntakeRate && airIntakeRate >= 0.0f);
		flame2.gameObject.SetActive(burnerOn && CutOff2 > airIntakeRate && airIntakeRate >= CutOff1);
		flame3.gameObject.SetActive(burnerOn && CutOff3 > airIntakeRate && airIntakeRate >= CutOff2);
		flame4a.gameObject.SetActive(burnerOn && 1.0f >= airIntakeRate && airIntakeRate >= CutOff3);
		flame4b.gameObject.SetActive(burnerOn && 1.0f >= airIntakeRate && airIntakeRate >= CutOff3);

		/*
		if (airIntakeRate >= CutOff1)
			flame1.Stop ();
		if (airIntakeRate >= CutOff2)
			flame2.Stop ();
		if (airIntakeRate >= CutOff3)
			flame3.Stop ();
		*/
		//mod = flame2.main;
        //mod.startLifetime = baseLifeTimeOuter + airIntakeRate * outerLifeTimeAdd;
	}

    public void IgniteBurner()
    {
		//flame1.gameObject.SetActive (true);
		//flame1.Play();
		burnerOn = true;
    }

    public void TurnOffBurner()
    {
		flame1.Stop ();
		flame2.Stop ();
		flame3.Stop ();
		flame4a.Stop ();
		flame4b.Stop ();
		burnerOn = false;
    }

    public void IncreaseIntakeRate(float increaseBy)
    {
        AirIntakeRate += increaseBy;
    }

    public void DecreaseIntakeRate(float decreaseBy)
    {
        AirIntakeRate -= decreaseBy;
    }
}

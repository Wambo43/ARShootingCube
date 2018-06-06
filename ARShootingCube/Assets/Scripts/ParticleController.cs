using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    //public ParticleSystem particleSystem;
    private int eject;

    // Use this for initialization
    void Start () {
        //particleSystem = GetComponent<ParticleSystem>();
        //particleSystem.Pause(true);
        eject = Random.Range(3, 8);
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void Explode()
    {
        //particleSystem.Emit(eject);
    }
}

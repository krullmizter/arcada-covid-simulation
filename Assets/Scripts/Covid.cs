using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covid : MonoBehaviour {
    public bool infected = false;
    public Material covidYellow;

    public ParticleSystem particleSystem;

    public int duration        = 3;
    public float burstDuration = 1.0f;
    public float lifetime      = 3.0f;
    public short amount        = 200;
    public int angle           = 25;
    public float radius        = 0.1f;

    void Start() {
        particleSystem.Stop();

        var main     = particleSystem.main;
        var shape    = particleSystem.shape;
        var emission = particleSystem.emission;
        
        main.duration      = duration;
        main.startLifetime = lifetime;

        shape.angle  = angle;
        shape.radius = radius;

        emission.SetBursts(new ParticleSystem.Burst[] {
            new ParticleSystem.Burst(burstDuration, amount)
        });

        particleSystem.Play();
    }

    void OnParticleCollision(GameObject other) {

        if (infected == true && other.GetComponent<Covid>().infected == false) { // If player is infected, and the colliding player isn't, then infect the other player.
            other.GetComponent<Covid>().infected = true;
            other.GetComponent<MeshRenderer>().material = covidYellow;
            
            other.name = "Infected";
        }
    }
}
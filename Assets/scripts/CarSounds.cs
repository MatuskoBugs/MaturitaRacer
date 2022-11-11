using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSounds : MonoBehaviour
{
    //public AudioSource TireScreech;
    public AudioSource carHit;

    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    private Rigidbody carRB;
    private AudioSource carAudio;

    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;

    void Awake()
    {
        carAudio = GetComponent<AudioSource>();
        carRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        EngineSound();
    }

    void EngineSound() //toto musi mat pri sebe audio source inak crash
    {
        currentSpeed = carRB.velocity.magnitude;
        pitchFromCar = carRB.velocity.magnitude / 50f;

        if (currentSpeed < minSpeed)
        {
            carAudio.pitch = minPitch;
        }
        if (currentSpeed > minSpeed && currentSpeed < maxSpeed)
        {
            carAudio.pitch = minPitch + pitchFromCar;
        }
        if (currentSpeed >= maxSpeed)
        {
            carAudio.pitch = maxPitch;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        float relativeVel = collision.relativeVelocity.magnitude;

        float volume = relativeVel * 0.1f;

        carHit.pitch = Random.Range(0.95f, 1.05f);
        carHit.volume = volume;

        if (!carHit.isPlaying)
        {
            carHit.Play();
        }
    }

}

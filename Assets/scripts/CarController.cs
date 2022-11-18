using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float motorTorque = 100f;
    public float maxSteer = 20f;
    private Rigidbody carRB;
    public float maxSpeed;

    float velocityVSUp = 0;
    float accelInput = 0;
    float turnInput = 0;

    public WheelCollider wheelColliderLF;
    public WheelCollider wheelColliderRF;
    public WheelCollider wheelColliderLR;
    public WheelCollider wheelColliderRR;

    public Transform wheelLF;
    public Transform wheelRF;
    public Transform wheelLR;
    public Transform wheelRR;
    public Transform centerOfMass;

    // Start is called before the first frame update
    void Start()
    {
        carRB = GetComponent<Rigidbody>();
        carRB.centerOfMass = centerOfMass.localPosition;
    }

    void FixedUpdate()
    {
        if (GameManager.instance.GetGameState() == GameStates.beforeRace)
        {
            return;
        }

        ApplyEngineForce();

        wheelColliderLF.steerAngle = turnInput * maxSteer;
        wheelColliderRF.steerAngle = turnInput * maxSteer;

    }

    private void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        wheelColliderLF.GetWorldPose(out pos, out rot);
        wheelLF.position = pos;
        wheelLF.rotation = rot;

        wheelColliderRF.GetWorldPose(out pos, out rot);
        wheelRF.position = pos;
        wheelRF.rotation = rot * Quaternion.Euler(0, 180, 0);

        wheelColliderLR.GetWorldPose(out pos, out rot);
        wheelLR.position = pos;
        wheelLR.rotation = rot;

        wheelColliderRR.GetWorldPose(out pos, out rot);
        wheelRR.position = pos;
        wheelRR.rotation = rot * Quaternion.Euler(0, 180, 0);

        Debug.Log(carRB.velocity.magnitude);
        if (carRB.velocity.magnitude > maxSpeed)
        {
            carRB.velocity = Vector3.ClampMagnitude(carRB.velocity, maxSpeed);
        }
    }

    public void SetInputVector(Vector3 inputVector)
    {
        turnInput = inputVector.x;
        accelInput = inputVector.y;
    }

    void ApplyEngineForce()
    {
        velocityVSUp = Vector3.Dot(transform.up, carRB.velocity);

        if (velocityVSUp > maxSpeed && accelInput > 0)
        {
            return;
        }

        if (velocityVSUp < -maxSpeed * 0.5f && accelInput < 0)
        {
            return;
        }

        if (carRB.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelInput > 0)
        {
            return;
        }

        if (accelInput == 0)
        {
            carRB.drag = Mathf.Lerp(carRB.drag, 2.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            carRB.drag = 0;
        }

        wheelColliderLR.motorTorque = accelInput * motorTorque;
        wheelColliderRR.motorTorque = accelInput * motorTorque;
    }
}

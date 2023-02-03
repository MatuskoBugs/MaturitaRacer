using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceGameObj : MonoBehaviour
{
    public GameObject obj;

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - obj.transform.position);
    }
}

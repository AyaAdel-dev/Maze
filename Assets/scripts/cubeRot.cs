using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeRot : MonoBehaviour
{
    public float speed = 150f;
    
    void Update()
    {
        transform.Rotate(Vector3.up, speed* Time.deltaTime);
    }
}

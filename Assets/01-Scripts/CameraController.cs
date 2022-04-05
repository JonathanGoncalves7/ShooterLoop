using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] Vector3 Offset;

    private void Update()
    {
        transform.position = Target.position + Offset;
    }
}

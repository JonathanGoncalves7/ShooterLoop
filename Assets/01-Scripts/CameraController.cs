using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 Offset;

    Transform _target;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = _target.position + Offset;
    }
}

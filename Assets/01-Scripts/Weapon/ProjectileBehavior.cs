using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [System.NonSerialized] public float Speed;
    [System.NonSerialized] public float Damage;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

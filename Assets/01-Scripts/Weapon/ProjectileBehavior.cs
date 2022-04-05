using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [System.NonSerialized] public float Speed;
    [System.NonSerialized] public int Damage;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")){
            Health health = other.gameObject.GetComponent<Health>();
            health.Damage(Damage);

            Debug.Log("Damage enemy: " + Damage);
        }

        Destroy(gameObject);
    }
}

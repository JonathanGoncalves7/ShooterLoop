using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [System.NonSerialized] public float Speed;
    [System.NonSerialized] public int Damage;
    [System.NonSerialized] public AudioClip SpellCastingClip;

    AudioSource SpellCasting;

    protected void Start()
    {
        AudioManager.s_instance.PlaySpellCasting(SpellCastingClip);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        Destroy(gameObject, 1);
    }

    protected void BasicDamage(GameObject enemy)
    {
        EnemyController damaged = enemy.GetComponent<EnemyController>();
        damaged.Damage(Damage);
    }
}

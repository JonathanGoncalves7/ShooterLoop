using UnityEngine;

public class ExplosionProjectileBehavior : ProjectileBehavior
{
    [SerializeField] GameObject ProjetileVFX;
    [SerializeField] GameObject ExplosionVFX;

    bool _causedDamage;

    [System.NonSerialized] public float RadiusDamage;
    [System.NonSerialized] public AudioClip ExplosionClip;

    private new void Start()
    {
        base.Start();

        _causedDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || _causedDamage) return;

        _causedDamage = true;
        ProjetileVFX.SetActive(false);
        ExplosionVFX.SetActive(true);
        Speed = 0;
        AreaDamage();
        AudioManager.s_instance.PlaySpellCasting(ExplosionClip);

        Destroy(gameObject, 2);
    }

    private void AreaDamage()
    {
        Collider[] hit;
        hit = Physics.OverlapSphere(transform.position, RadiusDamage);

        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].transform.CompareTag("Enemy"))
            {
                BasicDamage(hit[i].transform.gameObject);
            }
        }
    }
}
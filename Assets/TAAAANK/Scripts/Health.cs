using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float maxHealth = 10;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject destroyEffect;

    public float HP { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool destroyed = false;
    void Start()
    {
        HP = maxHealth;

    }

    public void OnDamage(float damage)
    {
        if (destroyed) return;

        HP -= damage;

        if(HP <= 0)
        {
            destroyed = true;
        }

        if(!destroyed && hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);

        }
        if (destroyed)
        {
            if(destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}

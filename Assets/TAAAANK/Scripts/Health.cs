using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float maxHealth = 10;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject destroyEffect;
    float health;

    public float HP {

        get { return health; }


        set { health = Mathf.Clamp(value, 0, maxHealth); } }

    public float CurrentHealthPercentage
    {
        get { return HP / maxHealth; }

    }
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
            TankGameManager.Instance.Score += 100;
            if(destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
    public void OnHeal(float amount)
    {
        HP += amount;
    }
}

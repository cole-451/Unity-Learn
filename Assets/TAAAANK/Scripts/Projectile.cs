using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : Ammo
{
    [SerializeField] GameObject effect;
    Rigidbody rb = null;
    [SerializeField] float speed = 1.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        print($"{collision.gameObject.name} is touching you vro...");
        if (!CompareTag("Player"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.OnDamage(damage);
            }
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        }
    }
}

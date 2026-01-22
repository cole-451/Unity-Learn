using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Ammo ammo;

    [SerializeField] Transform muzzle;

    [SerializeField] float fireRate;

    [SerializeField] int maxAmmo = 300;

    private int ammoCount;
    public int AmmoCount
    {
        get { return ammoCount; }
        set { ammoCount = Mathf.Clamp(value, 0, maxAmmo); }
    }

    public bool IsReadyToFire { get; set; } = true;
    void Start()
    {
        AmmoCount = maxAmmo;
    }

    void Update()
    {
        
    }
    public void OnFire()
    {
        if (IsReadyToFire && ammoCount > 0)
        {
            AmmoCount--;
            Instantiate(ammo, muzzle.position, muzzle.rotation);
            IsReadyToFire = false;
            StartCoroutine(ResetFireCR());
        }
    }
    IEnumerator ResetFireCR() // like an alarm!!!
    {
        yield return new WaitForSeconds(fireRate);
        IsReadyToFire = true;
    }
}

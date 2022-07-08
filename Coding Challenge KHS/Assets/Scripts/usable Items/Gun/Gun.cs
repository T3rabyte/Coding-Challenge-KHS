using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawn;
    public Rigidbody bullet;
    public float bulletSpeed;

    public int bulletsInGun;

    public void Shoot() 
    {
        if (bulletsInGun > 0) 
        {
            Rigidbody bulletRigidbody;
            bulletRigidbody = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as Rigidbody;
            bulletRigidbody.AddForce(bulletSpawn.forward * bulletSpeed * Time.deltaTime);
            bulletsInGun--;
        }
    }

    public void AddAmmoClip() 
    {
        if (bulletsInGun == 0) 
        {
            bulletsInGun = 6;
        }
    }
}

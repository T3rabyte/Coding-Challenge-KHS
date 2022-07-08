using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawn;
    public Rigidbody bullet;
    public float bulletSpeed;

    public int bulletsInGun;

    /// <summary>
    /// shoots a bullet from the gun if it has at least 1 bullet in it.
    /// </summary>
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

    /// <summary>
    /// adds 6 bullets to the gun if its empty
    /// </summary>
    public void AddAmmoClip() 
    {
        if (bulletsInGun == 0) 
        {
            bulletsInGun = 6;
        }
    }
}

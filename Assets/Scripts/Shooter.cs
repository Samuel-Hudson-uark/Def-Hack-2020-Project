using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool isFiring;

    public Bullet bullet;
    public float bulletSpeed;

    public float timeBetweenShots, shotCounter, bulletLife;

    public Transform firePoint1;
    public Transform firePoint2;

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Bullet newBullet = Instantiate(bullet, firePoint1.position, firePoint1.rotation) as Bullet;
                newBullet.speed = bulletSpeed;
                newBullet.life = bulletLife;
                newBullet = Instantiate(bullet, firePoint2.position, firePoint2.rotation) as Bullet;
                newBullet.speed = bulletSpeed;
                newBullet.life = bulletLife;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}

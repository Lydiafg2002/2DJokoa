using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject finalBossBullet;

    [SerializeField]
    private Transform bulletOrigin;
    [SerializeField]
    private Transform bombOrigin;
    [SerializeField]
    private float bulletSpeed = 40.0f;
    [SerializeField]
    private float bombSpeed = 10.0f;


    public void ShootBullet()
    {
        GameObject bulletClone = Instantiate(finalBossBullet, bulletOrigin.position, bulletOrigin.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
    }

    public void DropBomb()
    {
        GameObject bombClone = Instantiate(finalBossBullet, bombOrigin.position, bombOrigin.rotation);
        bombClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bombSpeed);
    }
}

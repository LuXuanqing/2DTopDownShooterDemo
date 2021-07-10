using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float bulletSpeed = 2f;
    public float fireFrequency = 1f; //how many bullets launched per second
    private float fireCoolDown = 0f; //remained cool down time
    public static float range = 5f;
    public static float damage = 1f;

    // references
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Vector2 mousePosition;
    // private fields
    private Vector2 lookDirection;

    private void Start()
    {

    }

    void Update()
    {
        HandleMouseMove();
        HandleFire();
    }

    private void HandleMouseMove()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 根据鼠标位置和角色上的firepoint位置计算lookDir向量
        lookDirection = mousePosition - (Vector2)firePoint.position;
    }
    private void HandleFire()
    {
        // check fire cd
        if (fireCoolDown > 0)
        {
            fireCoolDown -= Time.deltaTime;
            return;
        }

        // check fire button
        if (Input.GetButton("Fire1"))
        {
            LaunchBullet();
            // reset fire cd
            fireCoolDown = 1f / fireFrequency;
        }

    }
    private void LaunchBullet()
    {
        // 在firepoint实例化子弹，使其沿着lookDirection方向运动
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = lookDirection.normalized * bulletSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public static float range = 5f;
    public static int age = 27;
    public float bulletForce = 20f;
    public float fireFrequency = 1f; //how many bullets launched per second
    private float fireCoolDown = 0f;
    private Vector2 mousePosition;
    private Vector2 lookDirection;

    private void Start() {
        Debug.Log(range);
        range--;
        Debug.Log(range);
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
        // 并根据lookDir计算旋转角度并更新firepoint的rotation
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);
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
        Debug.Log("fire!");
        // 在firepoint实例化子弹，旋转子弹使其指向鼠标位置
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // 给子弹施加一个向上的力使其运动。由于firepoint根据鼠标位置旋转，其上方始终指向鼠标位置
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); // addFoce不适用于kinematic刚体
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] GameObject _bulletfab;
    [SerializeField] float _speed;
    [SerializeField] TrapType trapType;
    float _shootTimer = 0;
    float _shootInterval = 2f;

    private void Update()
    {
        _shootTimer += Time.deltaTime;

        if (_shootTimer >= _shootInterval)
        {
            ShootBullet();
            _shootTimer= 0f;
        }
    }
    void ShootBullet()
    {
        if (trapType == TrapType.Up)
        {
            GameObject bullet = Instantiate(_bulletfab);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * _speed;
        }
        else if (trapType == TrapType.Down)
        {
            GameObject bullet = Instantiate(_bulletfab);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = -bullet.transform.up * _speed;
        }
        else if (trapType == TrapType.Right)
        {
            GameObject bullet = Instantiate(_bulletfab);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right* _speed;
        }
        else if (trapType == TrapType.Left)
        {
            GameObject bullet = Instantiate(_bulletfab);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = -bullet.transform.right *_speed;
        }
    }
}

public enum TrapType
{
    Up,
    Down,
    Right,
    Left
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _speed;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            for (int i = 0; i < 12; i++)
            {
                Invoke("BullefFire", i * 0.5f);
            }
        }
        //void BullefFire()
        //{
        // Vector3 dir;
        //GameObject temp = Instantiate(_bullet);
        // float x = Mathf.Cos(_addDeg * Mathf.Deg2Rad);
        // float y = Mathf.Sin(_addDeg * Mathf.Deg2Rad);
        // dir = new Vector3(x, y, 0);
        // temp.GetComponent<BulletMove>().Init(dir, _speed);
        // _addDeg += 30;
    }
}

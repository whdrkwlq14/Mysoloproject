using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMove : MonoBehaviour
{
    [SerializeField] Transform _prefab;
    [SerializeField] float _prefabspeed;
    [SerializeField] Rigidbody2D _hero;
    
    void Update()
    {
        if (Vector3.Distance(_hero.position, _prefab.position) > 2f)
        {
            Follow();
        }
    }
    public void Follow()
    {
        Vector3 movePrefab = _prefab.position;
        Vector3 movePlayer = _hero.position;
        Vector3 move = movePrefab - movePlayer;
        Vector3 move2 = move.normalized;
        Vector3 move3 = move2 * _prefabspeed;
        _prefab.position = (_prefab.position - move3 * Time.deltaTime);
    }
}

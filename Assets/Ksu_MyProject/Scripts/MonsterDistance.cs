using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDistance : MonoBehaviour
{
    [SerializeField] Transform _monster;
    [SerializeField] Rigidbody2D _rigPlayer;
    [SerializeField] float _speed;
    



  void Update()
    {
        if (Vector3.Distance(_rigPlayer.position, _monster.position) < 4f)
        {
            Follow();
            GameObject.Destroy(_rigPlayer.gameObject);
        }
        else if (Vector3.Distance(_rigPlayer.position, _monster.position) > 4f)
        {
           
        }
    }
    public void Follow()
    {
        Vector3 moveMonster = _monster.position;
        Vector3 movePlayer = _rigPlayer.position;
        Vector3 move = moveMonster - movePlayer;
        Vector3 move2 = move.normalized;
        Vector3 move3 = move2 * _speed;
        _monster.position = _monster.position - move3 * Time.deltaTime;
        
    }
    public void RollBack()
    {
      // Destroy(gameObject);
    }
   
}

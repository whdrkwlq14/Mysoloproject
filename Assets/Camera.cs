using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform _petmove;
    [SerializeField] float _petspeed;
    [SerializeField] Rigidbody2D _hero;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_hero.position, _petmove.position) > 100f)
        {
            Follow();
        }

    }

    public void Follow()
    {
        Vector3 movePet = _petmove.position;
        Vector3 movePlayer = _hero.position;
        Vector3 move = movePet - movePlayer;
        Vector3 move2 = move.normalized;
        Vector3 move3 = move2 * _petspeed;
        _petmove.position = _petmove.position - move3 * Time.deltaTime;

    }
}

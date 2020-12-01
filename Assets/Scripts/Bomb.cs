using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Bomb : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private float _maxLifeTime = 3f;
    private float _lifeTime = 0;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _lifeTime += Time.deltaTime;
        if(_lifeTime>=_maxLifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            _rigidbody.bodyType = RigidbodyType2D.Static;
            _animator.SetTrigger("Destroy");
            Destroy(player.gameObject);
        }
    }
}

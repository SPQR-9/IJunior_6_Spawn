using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    [SerializeField] private float _speed = 0f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = transform.right * _speed;
            _renderer.flipX = false;
            _animator.SetBool("Run", true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = transform.right * -_speed;
            _renderer.flipX = true;
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }
    }
}

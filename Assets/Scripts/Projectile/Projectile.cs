using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float lifetimeS;
    [SerializeField] private int damage;
    
    private PlayerDamageable _owner;
    private float _lifetimeLeftS;

    private void Start()
    {
        _lifetimeLeftS = lifetimeS;
    }

    public void Init(PlayerDamageable owner, Vector2 direction)
    {
        _owner = owner;
        rb.velocity = direction * speed;
    }

    private void Update()
    {
        _lifetimeLeftS -= Time.deltaTime;

        if (_lifetimeLeftS < 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.TryGetComponent(out PlayerDamageable pd) 
            || pd == _owner) { return; }
        
        pd.TakeDamage(damage);
        Destroy(gameObject);
    }
}

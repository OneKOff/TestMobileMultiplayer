using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private float shootCooldownS;

    private float _remainingShootCooldownS;

    private void Start()
    {
        _remainingShootCooldownS = shootCooldownS;
    }

    private void Update()
    {
        if (!CheckCooldown()) { return; }

        ShootProjectile();
        
        _remainingShootCooldownS = shootCooldownS;
    }

    private bool CheckCooldown()
    {
        _remainingShootCooldownS -= Time.deltaTime;

        return _remainingShootCooldownS <= 0f;
    }

    private void ShootProjectile()
    {
        var projectile = Instantiate(projectilePrefab, gunPoint.position, transform.rotation);

        var rotationAngleRad = transform.localEulerAngles.z * Mathf.Deg2Rad;
        var facingVec = new Vector2(Mathf.Cos(rotationAngleRad),Mathf.Sin(rotationAngleRad));
        
        if (!TryGetComponent(out PlayerDamageable pd)) { return; }
        
        projectile.Init(pd, facingVec);
    }
}

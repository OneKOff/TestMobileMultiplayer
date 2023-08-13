using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Area")]
    [SerializeField] private Vector2 areaBoundLeftBottom;
    [SerializeField] private Vector2 areaBoundRightTop;
    [Header("Coin Spawn")]
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private float spawnCooldownS;
    [SerializeField] private int spawnAmount;

    private float _remainingSpawnCooldownS;
    
    private void Start()
    {
        _remainingSpawnCooldownS = 0f;
    }
    
    private void Update()
    {
        if (!CheckCooldown()) { return; }

        _remainingSpawnCooldownS = spawnCooldownS;
        SpawnCoinsRandomly();
    }

    private bool CheckCooldown()
    {
        _remainingSpawnCooldownS -= Time.deltaTime;
        
        return _remainingSpawnCooldownS <= 0f;
    }
    private void SpawnCoinsRandomly()
    {
        for (var i = 0; i < spawnAmount; i++)
        {
            Instantiate(coinPrefab, transform.position + 
                                               new Vector3(Random.Range(areaBoundLeftBottom.x, areaBoundRightTop.x),
                                                   Random.Range(areaBoundLeftBottom.y, areaBoundRightTop.y)),
                                                       Quaternion.identity);
        }
    }
}

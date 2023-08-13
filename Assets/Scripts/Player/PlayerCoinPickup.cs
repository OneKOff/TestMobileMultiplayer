using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinPickup : MonoBehaviour
{
    public event Action<int> CoinPickedUp;
    
    private int _coinsAmount;

    public int CoinsAmount => _coinsAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.TryGetComponent(out Coin c)) { return; }

        Debug.Log("PlayerCoinPickup: Coin picked up");
        
        _coinsAmount++;
        CoinPickedUp?.Invoke(_coinsAmount);
        
        Destroy(c.gameObject);
    }
}

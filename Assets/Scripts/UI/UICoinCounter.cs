using System;
using TMPro;
using UnityEngine;

public class UICoinCounter : MonoBehaviour
{
    [SerializeField] private PlayerCoinPickup pcp;
    [SerializeField] private TextMeshProUGUI uiCount;
    
    private void OnEnable()
    {
        pcp.CoinPickedUp += OnCoinPickedUp;
    }
    private void OnDisable()
    {
        pcp.CoinPickedUp -= OnCoinPickedUp;
    }

    private void OnCoinPickedUp(int amount)
    {
        uiCount.text = $"{amount}";
    }
}

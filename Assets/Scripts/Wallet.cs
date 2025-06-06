using System;
using UnityEngine;

public class Wallet 
{
    public event Action<int> MoneyChanged;

    private PlayerData _playerData;

    public Wallet(PlayerData playerData)
    {
        _playerData = playerData;
    }

    public void AddMoney(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        _playerData.Money += amount;

        MoneyChanged?.Invoke(_playerData.Money);
    }

    public int GetNumberOfMoney() => _playerData.Money;

    public bool IsEnough(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        return _playerData.Money >= amount;
    }

    public void Spend(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        _playerData.Money -= amount;

        MoneyChanged?.Invoke(_playerData.Money);
    }
}

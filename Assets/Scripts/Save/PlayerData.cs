using Newtonsoft.Json;
using UnityEngine;

public class PlayerData
{
    [JsonConstructor]
    public PlayerData(string name, int money, int xP)
    {
        Name = name;
        Money = money;
        XP = xP;
    }

    public string Name { get; set; }
    public int Money {  get; set; }
    public int XP { get; set; }
}

using UnityEngine;

public class Enemy : NPC
{
    [Header("Reward")]
    [field: SerializeField] public float GoldForKill {  get; protected set; }
    [field: SerializeField] public float ExpirienceForKill { get; protected set; }
}

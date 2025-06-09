using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/ShopItem")]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public Sprite Icon {  get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, Range(0, 100000)] public int Coast {  get; private set; }
}

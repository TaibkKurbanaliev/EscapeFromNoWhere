using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/CreateItem")]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
}

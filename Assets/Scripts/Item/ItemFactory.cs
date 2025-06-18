using UnityEngine;

[CreateAssetMenu(fileName = "ItemViewFactory", menuName = "Factory")]
public class ItemFactory : ScriptableObject
{
    [SerializeField] private ItemView _ItemPrefab;

    public ItemView Get(Item item, Transform parent)
    {
        ItemView instance;

        instance = Instantiate(_ItemPrefab, parent);
        instance.Initialize(item);

        return instance;
    }
}

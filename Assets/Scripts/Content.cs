using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Content", menuName = "Content")]
public class Content : ScriptableObject
{
    [SerializeField] private List<Item> _items;

    public IEnumerable<Item> Items => _items;

    public void Add(Item item)
    {
        _items.Add(item);
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    public event Action<ItemView> Click;

    [SerializeField] private Sprite _standardBackground;
    [SerializeField] private Sprite _highlightedBackground;

    [SerializeField] private Image _contentImage;
    [SerializeField] private Image _background;

    private Sprite _icon;
    private Item _item;

    public void OnItemViewClicked(ItemView item) => Click?.Invoke(item);

    public void Initialize(Item item)
    {
        _item = item;
        _icon = item.Icon;
    }

    public void Select()
    {
        
    }

    public void UnSelect()
    {

    }

    public void Highlight()
    {

    }

    public void UnHighlight()
    {

    }
}

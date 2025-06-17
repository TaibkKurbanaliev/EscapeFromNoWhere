using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))] 
public class ShopItemView : MonoBehaviour, IPointerClickHandler
{
    public event Action<ShopItemView> Click;

    [SerializeField] private Sprite _standardBackground;
    [SerializeField] private Sprite _highlightBackground;

    [SerializeField] private Image _contentImage;
    [SerializeField] private Image _lockImage;

    [SerializeField] private IntValueView _priceView;

    private Image _backgroundImage;

    public ShopItem Item { get; private set; }
    public bool IsLock { get; private set; }
    public int Price => Item.Cost;

    public void Initialize(ShopItem item)
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.sprite = _standardBackground;

        Item = item;

        _contentImage.sprite = item.Icon;

        _priceView.Show(Price);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Click?.Invoke(this);
    }

    public void Lock()
    {
        IsLock = true;
        _lockImage.gameObject.SetActive(IsLock);
        _priceView.Show(Price);
    }

    public void Unlock()
    {
        IsLock = false;
        _lockImage.gameObject.SetActive(IsLock);
        _priceView.Hide();
    }

    public void Select() 
    {
        _backgroundImage.sprite = _highlightBackground;
    }
    public void UnSelect()
    {
        _backgroundImage.sprite = _standardBackground;
    }

    public void Highlight()  
    {
        
    }
    public void UnHighlight()
    {

    }
}

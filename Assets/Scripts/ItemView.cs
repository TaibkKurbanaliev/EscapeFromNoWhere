using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemView : MonoBehaviour, IPointerClickHandler
{
    public event Action<ItemView> Click;

    [field: SerializeField] protected Sprite StandardBackground { get; private set; }
    [field: SerializeField] protected Sprite HighlightBackground { get; private set; }

    [field: SerializeField] protected Image ContentImage { get; private set; }
    [field: SerializeField] protected Image LockImage { get; private set; }

    private Image _backgroundImage;

    public Item Item { get; private set; }
    public bool IsLock { get; private set; }
    public int Price => Item.Cost;

    public virtual void Initialize(Item item)
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.sprite = StandardBackground;

        Item = item;

        ContentImage.sprite = item.Icon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Click?.Invoke(this);
    }

    public virtual void Lock()
    {
        IsLock = true;
        LockImage.gameObject.SetActive(IsLock);
    }

    public virtual void Unlock()
    {
        IsLock = false;
        LockImage.gameObject.SetActive(IsLock);
    }

    public virtual void Select()
    {
        _backgroundImage.sprite = HighlightBackground;
    }
    public virtual void UnSelect()
    {
        _backgroundImage.sprite = StandardBackground;
    }

    public virtual void Highlight()
    {

    }
    public virtual void UnHighlight()
    {

    }
}

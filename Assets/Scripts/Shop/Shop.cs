using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Panel _panel;

    public void Show(Content content)
    {
        _panel.Show(content.Items);
    }
}

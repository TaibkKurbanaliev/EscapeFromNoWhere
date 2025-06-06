using UnityEngine;

public class ItemSO : ScriptableObject
{
    public Sprite Icon {  get; private set; }
    public string Name { get; private set; }
    public int Coast {  get; private set; }
}

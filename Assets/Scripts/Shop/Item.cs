using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [field: SerializeField] public Sprite Icon {  get; private set; }
    [field: SerializeField] public int Cost {  get; private set; }
}

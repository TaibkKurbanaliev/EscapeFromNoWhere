using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Texture2D _battleCursor;
    [SerializeField] private Texture2D _defaultCursor;

    private void Start()
    {
        Cursor.SetCursor(_defaultCursor, new Vector2(_defaultCursor.width / 2, _defaultCursor.height / 2), CursorMode.Auto);
    }
}

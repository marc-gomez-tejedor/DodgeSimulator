using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D cursorTexture; // Drag your cursor texture here
    public Vector2 hotSpot = new Vector2(0, 0); // The "active" point of the cursor
    public CursorMode cursorMode = CursorMode.Auto; // Choose the appropriate mode for your game

    void Start()
    {
        // Set the custom cursor
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}

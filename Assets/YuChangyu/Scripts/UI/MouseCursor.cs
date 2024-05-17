using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] Texture2D image;

    private void Start()
    {
        Cursor.SetCursor(image, Vector2.zero, CursorMode.Auto);
    }
}

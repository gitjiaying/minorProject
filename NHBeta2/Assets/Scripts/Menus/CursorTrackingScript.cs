using UnityEngine;
using System.Collections;

public class CursorTrackingScript : MonoBehaviour {

	public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Texture2D cursorTexture;

	void Start(){
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
}

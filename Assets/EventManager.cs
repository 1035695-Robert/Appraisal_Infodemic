using UnityEngine;

public class EventManager
{
    public delegate void RequestFieldUpdate(string questMessage,  string requestHeader, ResponseType type);
    public static RequestFieldUpdate OnRequestUpdate;

    public delegate void FontSizeUpdate();
    public static FontSizeUpdate OnFontSizeUpdate;

}

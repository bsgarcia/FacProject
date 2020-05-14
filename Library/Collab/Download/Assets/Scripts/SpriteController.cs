using UnityEngine;
using UnityEditor;

public class ScriptController : EditorWindow
{
    public Sprite FridgeSprite;
    
    [MenuItem("Example/Overwrite Texture")]
    static void Apply()
    {
        Texture2D img = Selection.activeObject as Texture2D;
        if (img == null)
        {
            EditorUtility.DisplayDialog("Select Image", "You must select a texture first!", "OK");
            return;
        }

        string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        if (path.Length != 0)
        {
            WWW www = new WWW("file:///" + path);
            www.LoadImageIntoTexture(img);
        }
    }
}
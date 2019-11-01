using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PathologyMacroHandler : MonoBehaviour {

    public string defaultPath = "D:\\Other Projects\\Hololens4Pathology and Radiology\\Pancreas_T2747-19\\pathology\\2D";
    public Image preview;
    public Texture2D image = null;

    public void LoadPathologyMacroButton() {
        string path = EditorUtility.OpenFilePanel( "Select Pathology Macro..", defaultPath, "" );
        if( path.Length != 0 ) {
            byte[] data;
            data = File.ReadAllBytes( path );
            image = new Texture2D( 2, 2 );
            image.LoadImage( data );
            Sprite s = Sprite.Create( image, new Rect( 0, 0, image.width, image.height ), Vector2.zero );
            preview.sprite = s;
            preview.SetNativeSize();
        }
    }

}

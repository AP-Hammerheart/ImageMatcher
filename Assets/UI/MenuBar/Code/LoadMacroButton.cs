using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class LoadMacroButton : MonoBehaviour {

    [Header( "Default Variables" )]
    public string defaultPath = "D:\\Other Projects\\Hololens4Pathology and Radiology\\Pancreas_T2747-19\\pathology\\2D";

    [Header( "UI" )]
    public Transform WorkArea;

    [Header( "Data Holder" )]
    public Transform PathologyMacroHandler;

    [Header( "Prefabs" )]
    public PreviewImageWindow previewWindowPrefab;
    //public PathologyMacroData pathologyMacroDataPrefab;

    public void LoadPathologyMacroButton() {
        string path = EditorUtility.OpenFilePanel( "Select Pathology Macro..", defaultPath, "" );
        if( path.Length != 0 ) {
            byte[] bytes;
            bytes = File.ReadAllBytes( path );
            Texture2D image = new Texture2D( 2, 2 );
            image.LoadImage( bytes );
            Sprite sprite = Sprite.Create( image, new Rect( 0, 0, image.width, image.height ), Vector2.zero );

            ImageData data = new ImageData( path, sprite );
            //PathologyMacroData pmd = Instantiate( pathologyMacroDataPrefab, Vector3.zero, Quaternion.identity, PathologyMacroHandler ) as PathologyMacroData;
            //pmd.imageData = data;

            PreviewImageWindow piw = Instantiate( previewWindowPrefab, WorkArea, false );
            piw.gameObject.AddComponent<PathologyMacroData>();
            piw.GetComponent<PathologyMacroData>().imageData = data;
            piw.GetComponent<WindowBar>().windowName.text = path;
            piw.gameObject.name = path;
            piw.image.sprite = data.Image;
            piw.image.SetNativeSize();
        }
    }

}

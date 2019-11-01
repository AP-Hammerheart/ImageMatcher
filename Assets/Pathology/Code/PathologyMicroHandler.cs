using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using OpenSlide;

public class PathologyMicroHandler : MonoBehaviour {

    public string defaultPath = "D:\\Other Projects\\Hololens4Pathology and Radiology\\Pancreas_T2747-19\\pathology\\2D";
    public Image preview;
    public List<Texture2D> images = new List<Texture2D>();

    public void LoadPathologyMicroButton() {
        string path = EditorUtility.OpenFilePanel( "Select Pathology Micro..", defaultPath, "" );
        if( path.Length != 0 ) {
            //byte[] data;
            //data = File.ReadAllBytes( path );
            //image = new Texture2D( 2, 2 );
            //image.LoadImage( data );
            //Sprite s = Sprite.Create( image, new Rect( 0, 0, image.width, image.height ), Vector2.zero );
            //preview.sprite = s;
            //preview.SetNativeSize();

            const int CHUNK_SIZE = 1024;

            using( FileStream stream = new FileStream( path, FileMode.Open, FileAccess.Read ) ) {
                using( BinaryReader reader = new BinaryReader( stream, new System.Text.ASCIIEncoding() ) ) {
                    byte[] chunk;

                    chunk = reader.ReadBytes( CHUNK_SIZE );
                    //while( chunk.Length > 0 ) {
                        DumpBytes( chunk, chunk.Length );
                    //    chunk = reader.ReadBytes( CHUNK_SIZE );
                    //}
                }
            }

        }
    }

    private void DumpBytes(byte[] chunk, int length) {

        Texture2D image = null;
        image = new Texture2D( 2, 2 );
        image.LoadImage( chunk );
        images.Add( image );


        Material mat = new Material(Shader.Find("Standard"));
        mat.SetTexture( "Albedo", image );
        GameObject g = GameObject.CreatePrimitive( PrimitiveType.Quad );
        g.transform.SetParent( transform );
        g.GetComponent<Renderer>().material = mat;


    }

}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class PathologyMicroHandler : MonoBehaviour {
    
    private string filePath = "";

    public string defaultPath = "D:\\Other Projects\\Hololens4Pathology and Radiology\\Pancreas_T2747-19\\histology";
    public Text preview;

    public void LoadPathologyMicroButton() {
        filePath = EditorUtility.OpenFilePanel( "Select Pathology Micro..", defaultPath, "" );

        filePath = filePath.Replace( "/", "\n" );

        preview.text = filePath;
        /*
         * 1. hämta sökväg till ndpi
         * 2. connecto ndpi sökväg till markerade område i macro
         * 3. som sedan konnectas till en bild i en serie av radiologi.
         * 
         * 
         * [R] <- R index MA rect -> [MA] <- MA rect -> [MI]
         * 
         * 
        */



    }

}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class LoadMicroButton : MonoBehaviour {

    [Header( "Default Variables" )]
    public string defaultPath = "D:\\Other Projects\\Hololens4Pathology and Radiology\\Pancreas_T2747-19\\histology";

    [Header( "UI" )]
    public Transform WorkArea;

    [Header( "Data Holder" )]
    public Transform PathologyMicroHandler;

    [Header( "Prefabs" )]
    public PreviewImageWindow previewWindowPrefab;
    public PathologyMicroData pathologyMicroDataPrefab;

    public void LoadPathologyMicroButton() {
        string filePath = EditorUtility.OpenFilePanel( "Select Pathology Micro..", defaultPath, "" );
        if( !filePath.Contains( ".ndpi" ) ) {
            filePath = "";
        } else {
            PathologyMicroData pmd = Instantiate( pathologyMicroDataPrefab, Vector3.zero, Quaternion.identity, PathologyMicroHandler ) as PathologyMicroData;
            pmd.imagePath = filePath;

            PreviewImageWindow piw = Instantiate( previewWindowPrefab, WorkArea, false );
            piw.GetComponent<WindowBar>().windowName.text = filePath;
        }
    }
}

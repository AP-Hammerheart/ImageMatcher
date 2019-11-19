using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToolVariables;

public class ConnectImages : MonoBehaviour {

    public Transform workArea;

    public string outputDirectory = "D:\\Other Projects\\Hololens4Pathology and Radiology\\Pancreas_T2747-19";

    public List<ImageConnections> imageConnections = new List<ImageConnections>();

    // Start is called before the first frame update
    void Start() {
    }

    public void ConnectButtonPress() {
        ToolMode.toolMode = ToolModes.PanZoom;
        int nrImages = workArea.GetComponentsInChildren<DICOMImageData>().Length +
                       workArea.GetComponentsInChildren<PathologyMacroData>().Length +
                       workArea.GetComponentsInChildren<PathologyMicroData>().Length;
        ImageConnections ic = new ImageConnections();
        
        ic.Images = new ImageConnections.Image[nrImages];

        for( int i =0; i< workArea.childCount ( Transform t in workArea ) {
            DICOMImageData did = t.GetComponent<DICOMImageData>();
            PathologyMacroData pmd1 = t.GetComponent<PathologyMacroData>();
            PathologyMicroData pmd2 = t.GetComponent<PathologyMicroData>();
            if( did != null ) {
                ic.Images[0] = new ImageConnections.Image();
                ic.Images[0].imageSource = did.ImageSource;
                ic.Images[0].imageType = "dicom"; //DICOM, MACRO, HISTOLOGY
                ic.Images[0].imageIndex = did.ImageIndex;
                RectTransform markArea = t.GetComponent<PreviewImageWindow>().image.transform.GetChild( 0 ).GetComponent<RectTransform>();
                Vector3[] corners = new Vector3[4];
                markArea.GetLocalCorners( corners );
                ic.Images[0].P1x = corners[0].x;
                ic.Images[0].P1y = corners[0].y;
                ic.Images[0].P2x = corners[1].x;
                ic.Images[0].P2y = corners[1].y;
                ic.Images[0].P3x = corners[2].x;
                ic.Images[0].P3y = corners[2].y;
                ic.Images[0].P4x = corners[3].x;
                ic.Images[0].P4y = corners[3].y;
                ic.Images[0].DICOMPatientRecord = did.PatientRecord;
                ic.Images[0].DICOMStudyRecord = did.StudyRecord;
                ic.Images[0].DICOMSeriesRecord = did.SeriesRecord;
                ic.Images[0].DICOMImageRecord = did.ImageRecord;
            }
            if( pmd1 != null ) {
                //save macro
                ic.Images[1] = new ImageConnections.Image();
                ic.Images[1].imageSource = pmd1.imageData.ImageSource;
                ic.Images[0].imageType = "macro"; //DICOM, MACRO, HISTOLOGY
                RectTransform markArea = t.GetComponent<PreviewImageWindow>().image.transform.GetChild( 0 ).GetComponent<RectTransform>();
                Vector3[] corners = new Vector3[4];
                markArea.GetLocalCorners( corners );
                ic.Images[1].P1x = corners[0].x;
                ic.Images[1].P1y = corners[0].y;
                ic.Images[1].P2x = corners[1].x;
                ic.Images[1].P2y = corners[1].y;
                ic.Images[1].P3x = corners[2].x;
                ic.Images[1].P3y = corners[2].y;
                ic.Images[1].P4x = corners[3].x;
                ic.Images[1].P4y = corners[3].y;
            }
            if( pmd2 != null ) {
                //save micro
                ic.Images[2] = new ImageConnections.Image();
                ic.Images[2].imageSource = pmd2.imagePath;
                ic.Images[0].imageType = "histology"; //DICOM, MACRO, HISTOLOGY
            }
        }
        imageConnections.Add( ic );
        string s = JsonHelper.ToJson<ImageConnections>( imageConnections.ToArray(), true );
        print( s );
    }

    public void CreateJson() {
        //string s = JsonHelper.ToJson<ImageConnections>( ic3, true );
    }

}

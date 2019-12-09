using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToolVariables;
using System.IO;

public class ConnectImages : MonoBehaviour {

    public Transform workArea;

    public string outputDirectory = "D:\\Other Projects\\Hololens4Pathology and Radiology\\Pancreas_T2747-19\\connections.json";

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

        print( nrImages + " " + workArea.childCount );
        for( int i = 0; i < workArea.childCount; i++ ) {
            //Transform t = workArea.GetChild( i );
            //DICOMImageData did = t.GetComponent<DICOMImageData>();
            //PathologyMacroData pmd1 = t.GetComponent<PathologyMacroData>();
            //PathologyMicroData pmd2 = t.GetComponent<PathologyMicroData>();
            //ImageConnections.RadiologyPathologyConnection im = new ImageConnections.RadiologyPathologyConnection();
            //    im.imageSource = "none";
            //    if( did != null ) {
            //        im.imageSource = did.ImageSource;
            //        im.imageType = "dicom"; //DICOM, MACRO, HISTOLOGY
            //        im.imageIndex = did.ImageIndex;
            //        RectTransform markArea = t.GetComponent<PreviewImageWindow>().image.transform.GetChild( 0 ).GetComponent<RectTransform>();
            //        Vector3[] corners = new Vector3[4];
            //        markArea.GetLocalCorners( corners );
            //        im.P1x = markArea.localPosition.x + corners[0].x;
            //        im.P1y = markArea.localPosition.y + corners[0].y;
            //        im.P2x = markArea.localPosition.x + corners[1].x;
            //        im.P2y = markArea.localPosition.y + corners[1].y;
            //        im.P3x = markArea.localPosition.x + corners[2].x;
            //        im.P3y = markArea.localPosition.y + corners[2].y;
            //        im.P4x = markArea.localPosition.x + corners[3].x;
            //        im.P4y = markArea.localPosition.y + corners[3].y;
            //        im.DICOMPatientRecord = did.PatientRecord;
            //        im.DICOMStudyRecord = did.StudyRecord;
            //        im.DICOMSeriesRecord = did.SeriesRecord;
            //        im.DICOMImageRecord = did.ImageRecord;
            //    } else if( pmd1 != null ) {
            //        //save macro
            //        im.imageSource = pmd1.imageData.ImageSource;
            //        im.imageType = "macro"; //DICOM, MACRO, HISTOLOGY
            //        RectTransform markArea = t.GetComponent<PreviewImageWindow>().image.transform.GetChild( 0 ).GetComponent<RectTransform>();
            //        Vector3[] corners = new Vector3[4];
            //        markArea.GetLocalCorners( corners );
            //        im.P1x = markArea.localPosition.x + corners[0].x;
            //        im.P1y = markArea.localPosition.y + corners[0].y;
            //        im.P2x = markArea.localPosition.x + corners[1].x;
            //        im.P2y = markArea.localPosition.y + corners[1].y;
            //        im.P3x = markArea.localPosition.x + corners[2].x;
            //        im.P3y = markArea.localPosition.y + corners[2].y;
            //        im.P4x = markArea.localPosition.x + corners[3].x;
            //        im.P4y = markArea.localPosition.y + corners[3].y;
            //    } else if( pmd2 != null ) {
            //        //save micro
            //        im.imageSource = pmd2.imagePath;
            //        im.imageType = "histology"; //DICOM, MACRO, HISTOLOGY
            //    }
            //    if( im.imageSource != "none") {
            //        print( t.name );
            //        ic.Images.Add( im );
            //    }

            //    print( i );
            //}
            //for( int i = 0; i < ic.Images.Count; i++ ) {
            //    print( i );
            //}
            //imageConnections.Add( ic );
            //for( int i = 0; i < imageConnections.Count; i++ ) {
            //    print( i );
            //}
            //string s = JsonHelper.ToJson<ImageConnections>( imageConnections.ToArray(), true );
            //print( s );
            //print( Application.dataPath );
            //File.WriteAllText( Application.dataPath + "\\connections.json", s, System.Text.Encoding.UTF8 );
        }

    }
}

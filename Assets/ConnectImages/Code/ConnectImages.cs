using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToolVariables;
using System.IO;

public class ConnectImages : MonoBehaviour {

    public Transform workArea;

    public Text labelText;

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
        ic.Images.Add( new ImageConnections.RadiologyPathologyConnection() );
        int connectIndex = 0;
        print( nrImages + " " + workArea.childCount );
        for( int i = 0; i < workArea.childCount; i++ ) {
            print( "a" );
            //check if radiology and insert
            DICOMPreviewImageWindow dpiw = workArea.GetChild( i ).GetComponent<DICOMPreviewImageWindow>();
            ImageConnections.RadiologyImage ri = new ImageConnections.RadiologyImage();
            if( dpiw != null ) {                
                ri.DICOMImageRecord = dpiw.didL.ImageRecord;
                ri.DICOMPatientRecord = dpiw.didL.PatientRecord;
                ri.DICOMStudyRecord = dpiw.didL.StudyRecord;
                ri.DICOMSeriesRecord = dpiw.didL.SeriesRecord;
                ri.DICOMImageRecord = dpiw.didL.ImageRecord;
                
                ri.imageSource = dpiw.didL.ImageSource;
                
                ri.imageIndexStart = (int)dpiw.rangeSlider.LowValue;
                ri.imageIndexEnd = (int)dpiw.rangeSlider.HighValue;

                RectTransform markArea = dpiw.imageL.transform.GetComponentInChildren<RectTransform>();
                if( markArea.gameObject.activeSelf ) {
                    Vector3[] corners = new Vector3[4];
                    markArea.GetLocalCorners( corners );
                    ri.P1x = markArea.localPosition.x + corners[0].x;
                    ri.P1y = markArea.localPosition.y + corners[0].y;
                    ri.P2x = markArea.localPosition.x + corners[1].x;
                    ri.P2y = markArea.localPosition.y + corners[1].y;
                    ri.P3x = markArea.localPosition.x + corners[2].x;
                    ri.P3y = markArea.localPosition.y + corners[2].y;
                    ri.P4x = markArea.localPosition.x + corners[3].x;
                    ri.P4y = markArea.localPosition.y + corners[3].y;
                } else {
                    ri.P1x = -1;
                    ri.P1y = -1;
                    ri.P2x = -1;
                    ri.P2y = -1;
                    ri.P3x = -1;
                    ri.P3y = -1;
                    ri.P4x = -1;
                    ri.P4y = -1;
                }
                ic.Images[connectIndex].dicom.Add( ri );
                continue;
            }
            print( "a" );
            //check if macro and insert
            MacroPreviewImageWindow mpiw = workArea.GetChild( i ).GetComponent<MacroPreviewImageWindow>();
            ImageConnections.PathologyMacroImage pmi = new ImageConnections.PathologyMacroImage();
            if( mpiw != null ) {
                pmi.label = labelText.text;
                pmi.imageSource = mpiw.GetComponent<WindowBar>().windowName.text;
                pmi.imageZoomLevel = int.Parse( mpiw.zoomLevelText.text ); //0 = normal zoom.
                print( "a" );
                RectTransform markArea = mpiw.image.transform.GetComponentInChildren<RectTransform>();
                if( markArea.gameObject.activeSelf ) {
                    Vector3[] corners = new Vector3[4];
                    markArea.GetLocalCorners( corners );
                    pmi.P1x = markArea.localPosition.x + corners[0].x;
                    pmi.P1y = markArea.localPosition.y + corners[0].y;
                    pmi.P2x = markArea.localPosition.x + corners[1].x;
                    pmi.P2y = markArea.localPosition.y + corners[1].y;
                    pmi.P3x = markArea.localPosition.x + corners[2].x;
                    pmi.P3y = markArea.localPosition.y + corners[2].y;
                    pmi.P4x = markArea.localPosition.x + corners[3].x;
                    pmi.P4y = markArea.localPosition.y + corners[3].y;
                } else {
                    pmi.P1x = -1;
                    pmi.P1y = -1;
                    pmi.P2x = -1;
                    pmi.P2y = -1;
                    pmi.P3x = -1;
                    pmi.P3y = -1;
                    pmi.P4x = -1;
                    pmi.P4y = -1;
                }
                print( "a" );
                ic.Images[connectIndex].macro.Add( pmi );
                print( "a" );
                continue;
            }
            print( "a" );
            //check if histology
            PreviewImageWindow piw = workArea.GetChild( i ).GetComponent<PreviewImageWindow>();
            ImageConnections.PathologyHistologyImage phi = new ImageConnections.PathologyHistologyImage();
            if( piw != null ) {
                phi.imageSource = piw.GetComponent<WindowBar>().windowName.text;
                ic.Images[connectIndex].histology.Add( phi );
                continue;
            }

            ic.Images[connectIndex].label = labelText.text;
            //if( ic.Images[connectIndex].dicom[0] != null &&
            //    ic.Images[connectIndex].macro[0] != null &&
            //    ic.Images[connectIndex].histology[0] != null ) {
            //    connectIndex++;
            //}
            print( "a" );
            imageConnections.Add( ic );
            for( int j = 0; j < imageConnections.Count; j++ ) {
                print( j );
            }
            string s = JsonHelper.ToJson<ImageConnections>( imageConnections.ToArray(), true );
            print( s );
            print( Application.dataPath );
            File.WriteAllText( Application.dataPath + "\\connections.json", s, System.Text.Encoding.UTF8 );




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

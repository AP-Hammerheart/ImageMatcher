using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Dicom;
using Dicom.IO;
using Dicom.Imaging;
using Dicom.Media;


public class LoadDICOMButton : MonoBehaviour {

    [Header( "Default Variables" )]
    public string defaultPath = "D:\\Other Projects\\Hololens4Pathology and Radiology\\Pancreas_T2747-19\\radiology\\Pictures";

    [Header( "UI" )]
    public Transform WorkArea;

    [Header( "Data Holder" )]
    public Transform DICOMHandler;

    [Header( "Prefabs" )]
    public DICOMPreviewImageWindow previewWindowPrefab;
    public ThumbnailWindow thumbnailWindowPrefab;
    public ThumbnailButton thumbnailButtonPrefab;

    public void LoadDICOMDIR() {
        string path = EditorUtility.OpenFilePanel( "Select DICOMDIR..", defaultPath, "" );
        if( path.Length != 0 ) {
            DicomDirectory dicomDir = Dicom.Media.DicomDirectory.Open( path );

            DICOMPreviewImageWindow piw = Instantiate( previewWindowPrefab, WorkArea, false );
            piw.gameObject.AddComponent<DICOMImageData>();
            ThumbnailWindow tw = Instantiate( thumbnailWindowPrefab, WorkArea, false );
            piw.tw = tw;
            foreach( var patientRecord in dicomDir.RootDirectoryRecordCollection ) {
                string patient = "Patient: " + patientRecord.Get<string>( DicomTag.PatientName ) + "." + patientRecord.Get<string>( DicomTag.PatientID ).ToString();

                foreach( var studyRecord in patientRecord.LowerLevelDirectoryRecordCollection ) {
                    string study = "Study: " + studyRecord.Get<string>( DicomTag.StudyInstanceUID ).ToString();

                    foreach( var seriesRecord in studyRecord.LowerLevelDirectoryRecordCollection ) {
                        string series = "Series: " + seriesRecord.Get<string>( DicomTag.SeriesInstanceUID ).ToString();
                        int imageIndex = 0;

                        foreach( var imageRecord in seriesRecord.LowerLevelDirectoryRecordCollection ) {
                            string image = "Image: " + imageRecord.Get<string>( DicomTag.ReferencedSOPInstanceUIDInFile ) + "." + imageRecord.Get<string>( DicomTag.ReferencedFileID ).ToString();

                            string dicomfile = path + string.Join( @"\", imageRecord.Get<string[]>( DicomTag.ReferencedFileID ) );
                            dicomfile = dicomfile.Replace( "DICOMDIR", "" );
                            DicomImage dcmImage = new DicomImage( dicomfile );
                            Texture2D tex = new Texture2D( dcmImage.RenderImage().AsTexture2D().width, dcmImage.RenderImage().AsTexture2D().width );
                            tex = dcmImage.RenderImage().AsTexture2D();
                            Sprite sprite = Sprite.Create( tex, new Rect( 0, 0, tex.width, tex.height ), Vector2.zero );

                            piw.GetComponent<DICOMImageData>().Initialize( patient, study, series, image, imageIndex, dicomfile, sprite );
                            

                            ThumbnailButton tb = Instantiate( thumbnailButtonPrefab, tw.content );
                            tb.gameObject.AddComponent<DICOMImageData>().Initialize( patient, study, series, image, imageIndex, dicomfile, sprite );
                            tb.image.sprite = sprite;
                            tb.text.text = (imageIndex + 1).ToString();
                            tb.previewImageWindow = piw;
                            tb.gameObject.name = imageIndex.ToString();
                            

                            imageIndex++;
                        }
                    }
                }
            }

            if( piw.GetComponent<DICOMImageData>().Image != null ) {
                piw.GetComponent<WindowBar>().windowName.text = piw.GetComponent<DICOMImageData>().PatientRecord;
                tw.GetComponent<WindowBar>().windowName.text = piw.GetComponent<DICOMImageData>().PatientRecord;
                //tw.content.GetChild( 0 ).GetComponent<ThumbnailButton>().ButtonPress();
                piw.Initialize( 1, tw.content.childCount-1 );
                piw.imageL.sprite = tw.content.GetChild( 0 ).GetComponent<ThumbnailButton>().image.sprite;
                piw.imageL.SetNativeSize();
                piw.didL = tw.content.GetChild( 0 ).GetComponent<DICOMImageData>();
                piw.imageR.sprite = tw.content.GetChild( tw.content.childCount-1 ).GetComponent<ThumbnailButton>().image.sprite;
                piw.imageR.SetNativeSize();
                piw.didR = tw.content.GetChild( tw.content.childCount - 1 ).GetComponent<DICOMImageData>();
            } else {
                Destroy( piw );
                Destroy( tw );
            }

        }
    }

}

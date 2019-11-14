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
    public PreviewImageWindow previewWindowPrefab;
    public ThumbnailWindow thumbnailWindowPrefab;
    public ThumbnailButton thumbnailButtonPrefab;
    public DICOMDirData DICOMDirDataPrefab;

    public void LoadDICOMDIR() {
        string path = EditorUtility.OpenFilePanel( "Select DICOMDIR..", defaultPath, "" );
        if( path.Length != 0 ) {
            DicomDirectory dicomDir = Dicom.Media.DicomDirectory.Open( path );

            DICOMDirData dicomdirData = Instantiate( DICOMDirDataPrefab, Vector3.zero, Quaternion.identity, DICOMHandler ) as DICOMDirData;
            PreviewImageWindow piw = Instantiate( previewWindowPrefab, WorkArea, false );
            ThumbnailWindow tw = Instantiate( thumbnailWindowPrefab, WorkArea, false );

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

                            DICOMImageData imageData = new DICOMImageData( patient, study, series, image, imageIndex, dicomfile, sprite );
                            dicomdirData.images.Add( imageData );

                            ThumbnailButton tb = Instantiate( thumbnailButtonPrefab, tw.content );
                            tb.image.sprite = sprite;
                            tb.text.text = (imageIndex + 1).ToString();
                            tb.previewImageWindow = piw;

                            imageIndex++;
                        }
                    }
                }
            }

            if( dicomdirData.images[0] != null ) {
                piw.GetComponent<WindowBar>().windowName.text = dicomdirData.images[0].PatientRecord;
                piw.image.sprite = dicomdirData.images[0].Image;
                piw.image.SetNativeSize();
                tw.GetComponent<WindowBar>().windowName.text = dicomdirData.images[0].PatientRecord;
                dicomdirData.name = dicomdirData.images[0].PatientRecord;
            } else {
                Destroy( dicomdirData );
                Destroy( piw );
                Destroy( tw );
            }

        }
    }

}

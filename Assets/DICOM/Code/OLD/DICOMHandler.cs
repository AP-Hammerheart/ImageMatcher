using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Dicom;
using Dicom.IO;
using Dicom.Imaging;
using Dicom.Media;

public class DICOMHandler : MonoBehaviour {

    //UI
    public string defaultPath = "D:\\Other Projects\\Hololens4Pathology and Radiology\\Pancreas_T2747-19\\radiology\\Pictures";
    public Image preview;
    public Slider searchSlider;
    public ScrollRect thumbnailScrollView;
    public Scrollbar thumbnailScrollBar;
    public Button thumbnailPrefab;
    public Transform thumbnailParent;
    public Text imageNumber;

    public List<DICOMImageData> dicomImages = new List<DICOMImageData>();

    public int selectedImageIndex {
        get; set;
    }

    
    private void Start() {
        preview.sprite = null;
    }

    public void LoadDICOMDIR() {
        string path = EditorUtility.OpenFilePanel( "Select DICOMDIR..", defaultPath, "" );
        if( path.Length != 0 ) {
            print( path );
            DicomDirectory dicomDir = Dicom.Media.DicomDirectory.Open( path );

            foreach( var patientRecord in dicomDir.RootDirectoryRecordCollection ) {
                //print( "Patient: " + patientRecord.Get<string>( DicomTag.PatientName ) + patientRecord.Get<string>( DicomTag.PatientID ).ToString() );

                foreach( var studyRecord in patientRecord.LowerLevelDirectoryRecordCollection ) {
                    //print( "Study: " + studyRecord.Get<string>( DicomTag.StudyInstanceUID ).ToString() );

                    foreach( var seriesRecord in studyRecord.LowerLevelDirectoryRecordCollection ) {
                        //print( "Series: " + seriesRecord.Get<string>( DicomTag.SeriesInstanceUID ).ToString() );

                        foreach( var imageRecord in seriesRecord.LowerLevelDirectoryRecordCollection ) {
                            //print( "Image: " + imageRecord.Get<string>( DicomTag.ReferencedSOPInstanceUIDInFile ) + " [" + imageRecord.Get<string>( DicomTag.ReferencedFileID ).ToString() + "]" );

                            string dicomfile = path + string.Join( @"\", imageRecord.Get<string[]>( DicomTag.ReferencedFileID ) );
                            dicomfile = dicomfile.Replace( "DICOMDIR", "" );
                            DicomImage dcmImage = new DicomImage( dicomfile );
                            Texture2D tex = new Texture2D( dcmImage.RenderImage().AsTexture2D().width, dcmImage.RenderImage().AsTexture2D().width);
                            tex = dcmImage.RenderImage().AsTexture2D();
                            Sprite sprite = Sprite.Create( tex, new Rect( 0, 0, tex.width, tex.height ), Vector2.zero );

                            string pr = patientRecord.Get<string>( DicomTag.PatientName ) + ";"+ patientRecord.Get<string>( DicomTag.PatientID ).ToString();
                            string sr = studyRecord.Get<string>( DicomTag.StudyInstanceUID ).ToString();
                            string se = seriesRecord.Get<string>( DicomTag.SeriesInstanceUID ).ToString();
                            string ir = imageRecord.Get<string>( DicomTag.ReferencedSOPInstanceUIDInFile ) + ";" + imageRecord.Get<string>( DicomTag.ReferencedFileID ).ToString();

                            //DICOMImageData data = new DICOMImageData( pr, sr, se, ir, dicomImages.Count, sprite );

                            //dicomImages.Add( data );

                            Button b = Instantiate( thumbnailPrefab, thumbnailParent ) as Button;
                            b.GetComponent<Image>().sprite = sprite;
                            b.GetComponent<DICOMThumbnailClick>().preview = preview;
                            b.GetComponent<DICOMThumbnailClick>().Index = dicomImages.Count;
                        }
                    }
                }
            }
            preview.sprite = dicomImages[0].Image;
            //set up slider
            searchSlider.maxValue = dicomImages.Count-1;
            //Update image number
            UpdateImageNumber( 1 );
        }
    }

    public void SearchSlideValueChange() {
        preview.sprite = dicomImages[(int)searchSlider.value].Image;
        UpdateImageNumber( (int)searchSlider.value + 1 );
    }

    private void UpdateImageNumber(int number) {
        imageNumber.text = number + " / " + dicomImages.Count.ToString();
        thumbnailScrollBar.value = ((float)number - 0f) / ((float)dicomImages.Count - 0f);
        selectedImageIndex = number - 1;
    }

}

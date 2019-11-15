using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectImages : MonoBehaviour {

    public GameObject dicom;
    public GameObject macro;
    public GameObject micro;

    public string outputDirectory = "D:\\Other Projects\\Hololens4Pathology and Radiology\\Pancreas_T2747-19";


    public List<ImageConnections> imageConnections = new List<ImageConnections>();

    // Start is called before the first frame update
    void Start() {

    }

    public void ConnectButtonPress() {

        //if( dicom.preview.sprite == null ) {
        //    print( "no dicom loaded" );
        //} else if( macro.preview.sprite == null ) {
        //    print( "no macro loaded" );
        //} else if( micro.preview.text == "*" ) {
        //    print( "no micro loaded" );
        //} else {
        //    ImageConnections ic = new ImageConnections();

        //    ic = new ImageConnections();
        //    ic.Images = new ImageConnections.Image[3];

        //    //DICOM
        //    ic.Images[0] = new ImageConnections.Image();
        //    ic.Images[0].imageSource = dicom.dicomImages[dicom.selectedImageIndex].PatientRecord + ";" +
        //                               dicom.dicomImages[dicom.selectedImageIndex].StudyRecord + ";" +
        //                               dicom.dicomImages[dicom.selectedImageIndex].SeriesRecord + ";" +
        //                               dicom.dicomImages[dicom.selectedImageIndex].ImageRecord;
        //    ic.Images[0].imageIndex = dicom.dicomImages[dicom.selectedImageIndex].ImageIndex;
        //    ic.Images[0].imageWidth = 0;
        //    ic.Images[0].imageHeight = 0;
        //    ic.Images[0].imageX = 0;
        //    ic.Images[0].imageY = 0;

        //    //Macro
        //    ic.Images[1] = new ImageConnections.Image();
        //    ic.Images[1].imageSource = macro.macro[0].ImageSource;
        //    ic.Images[1].imageIndex = macro.macro[0].ImageIndex;
        //    ic.Images[1].imageWidth = 0;
        //    ic.Images[1].imageHeight = 0;
        //    ic.Images[1].imageX = 0;
        //    ic.Images[1].imageY = 0;

        //    //Micro
        //    ic.Images[2] = new ImageConnections.Image();
        //    ic.Images[2].imageSource = "zxcv";

        //}
    }

    public void CreateJson() {
        //string s = JsonHelper.ToJson<ImageConnections>( ic3, true );
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailButton : MonoBehaviour {
    public Image image;
    public Text text;

    public DICOMPreviewImageWindow previewImageWindow;

    public void ButtonPress() {
        int index = -1;
        if( int.TryParse( text.text, out index ) ) {
            if( index > previewImageWindow.rangeSlider.HighValue ) {
                previewImageWindow.rangeSlider.HighValue = index;
            } else {
                previewImageWindow.rangeSlider.LowValue = index;
            }
        }
        //get index number and check which should be changed.
        //previewImageWindow.imageL.sprite = image.sprite;
        //previewImageWindow.imageL.SetNativeSize();
        //DICOMImageData tbData = GetComponent<DICOMImageData>();
        //DICOMImageData piwData = previewImageWindow.GetComponent<DICOMImageData>();
        //if( tbData != null && piwData != null ) {
        //    piwData.Initialize( tbData.PatientRecord, tbData.StudyRecord, tbData.SeriesRecord, tbData.ImageRecord, tbData.ImageIndex, tbData.ImageSource, tbData.Image );
        //}
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailButton : MonoBehaviour {
    public Image image;
    public Text text;

    public PreviewImageWindow previewImageWindow;

    public void ButtonPress() {
        previewImageWindow.image.sprite = image.sprite;
        previewImageWindow.image.SetNativeSize();
        DICOMImageData tbData = GetComponent<DICOMImageData>();
        DICOMImageData piwData = previewImageWindow.GetComponent<DICOMImageData>();
        if( tbData != null && piwData != null ) {
            piwData.Initialize( tbData.PatientRecord, tbData.StudyRecord, tbData.SeriesRecord, tbData.ImageRecord, tbData.ImageIndex, tbData.ImageSource, tbData.Image );
        }
    }

}

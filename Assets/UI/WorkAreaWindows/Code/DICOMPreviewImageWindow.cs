using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class DICOMPreviewImageWindow : MonoBehaviour
{

    public Image imageL;
    public Image imageR;
    public RangeSlider rangeSlider;
    public Text maxValueLabel;
    public Text minValueLabel;
    public Text maxSelectedValueLabel;
    public Text minSelectedValueLabel;
    public ThumbnailWindow tw;

    public DICOMImageData didL = null;
    public DICOMImageData didR = null;

    private void Start() {
    }

    public void Initialize( int minValue, int maxValue ) {
        rangeSlider.MinValue = rangeSlider.LowValue = minValue;
        rangeSlider.MaxValue = rangeSlider.HighValue = maxValue;
        maxValueLabel.text = maxSelectedValueLabel.text = maxValue.ToString();
        minValueLabel.text = minSelectedValueLabel.text = minValue.ToString();

    }

    public void Initialize( Sprite imageL, Sprite imageR, int minValue, int maxValue ) {
        //do stuff;
        this.imageL.sprite = imageL;
        this.imageR.sprite = imageR;
        rangeSlider.MinValue = minValue;
        rangeSlider.MaxValue = maxValue;
        maxValueLabel.text = maxSelectedValueLabel.text = maxValue.ToString();
        minValueLabel.text = minSelectedValueLabel.text = minValue.ToString();

    }

    public void OnSliderValueChanged() {
        DICOMImageData tbData = tw.content.GetChild( (int)rangeSlider.LowValue - 1 ).GetComponent<DICOMImageData>();
        imageL.sprite = tw.content.GetChild( (int)rangeSlider.LowValue ).GetComponent<ThumbnailButton>().image.sprite;
        didL = tbData; //.Initialize( tbData.PatientRecord, tbData.StudyRecord, tbData.SeriesRecord, tbData.ImageRecord, tbData.ImageIndex, tbData.ImageSource, tbData.Image );
        minSelectedValueLabel.text = ((int)rangeSlider.LowValue).ToString();

        tbData = tw.content.GetChild( (int)rangeSlider.HighValue ).GetComponent<DICOMImageData>();
        imageR.sprite = tw.content.GetChild( (int)rangeSlider.HighValue ).GetComponent<ThumbnailButton>().image.sprite;
        didR = tbData; //.Initialize( tbData.PatientRecord, tbData.StudyRecord, tbData.SeriesRecord, tbData.ImageRecord, tbData.ImageIndex, tbData.ImageSource, tbData.Image );
        maxSelectedValueLabel.text = ((int)rangeSlider.HighValue).ToString();
    }
}

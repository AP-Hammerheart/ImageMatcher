using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DICOMImageData : MonoBehaviour {

    public string ImageSource {
        get; set;
    }
    public string PatientRecord {
        get; set;
    }
    public string StudyRecord {
        get; set;
    }
    public string SeriesRecord {
        get; set;
    }
    public string ImageRecord {
        get; set;
    }

    public int ImageIndex {
        get; set;
    }
    public Sprite Image {
        get; set;
    }

    public DICOMImageData( string patientRecord, string studyRecord, string seriesRecord, string imageRecord, int imageIndex, string imageSource, Sprite image ) {
        this.ImageSource = imageSource;
        this.PatientRecord = patientRecord;
        this.StudyRecord = studyRecord;
        this.SeriesRecord = seriesRecord;
        this.ImageRecord = imageRecord;
        this.ImageIndex = imageIndex;
        this.Image = image;
    }

    public void Initialize( string patientRecord, string studyRecord, string seriesRecord, string imageRecord, int imageIndex, string imageSource, Sprite image ) {
        this.ImageSource = imageSource;
        this.PatientRecord = patientRecord;
        this.StudyRecord = studyRecord;
        this.SeriesRecord = seriesRecord;
        this.ImageRecord = imageRecord;
        this.ImageIndex = imageIndex;
        this.Image = image;
    }
}

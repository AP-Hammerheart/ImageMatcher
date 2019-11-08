using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DICOMImageData {

    public string PatientRecord {
        get;
    }
    public string StudyRecord {
        get;
    }
    public string SeriesRecord {
        get;
    }
    public string ImageRecord {
        get;
    }

    public int ImageIndex {
        get;
    }

    public Sprite Image {
        get;
    }

    public DICOMImageData( string patientRecord, string studyRecord, string seriesRecord, string imageRecord, int imageIndex, Sprite image ) {
        this.PatientRecord = patientRecord;
        this.StudyRecord = studyRecord;
        this.SeriesRecord = seriesRecord;
        this.ImageRecord = imageRecord;
        this.ImageIndex = imageIndex;
        this.Image = image;
    }
}

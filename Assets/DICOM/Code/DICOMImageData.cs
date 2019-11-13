using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DICOMImageData : ImageData {

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


    public DICOMImageData( string patientRecord, string studyRecord, string seriesRecord, string imageRecord, int imageIndex, string imageSource, Sprite image ) 
           : base(imageSource, image) {
        this.PatientRecord = patientRecord;
        this.StudyRecord = studyRecord;
        this.SeriesRecord = seriesRecord;
        this.ImageRecord = imageRecord;
        this.ImageIndex = imageIndex;
    }
}

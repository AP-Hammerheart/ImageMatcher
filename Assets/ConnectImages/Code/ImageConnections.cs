using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ImageConnections {
    [Serializable]
    public class Image {

        public string imageType; //DICOM, MACRO, HISTOLOGY
        public string imageSource;
        public int imageIndex;
        public float P1x;
        public float P1y;
        public float P2x;
        public float P2y;
        public float P3x;
        public float P3y;
        public float P4x;
        public float P4y;

        public string DICOMPatientRecord;
        public string DICOMStudyRecord;
        public string DICOMSeriesRecord;
        public string DICOMImageRecord;
    }
    public List<Image> Images = new List<Image>();
}
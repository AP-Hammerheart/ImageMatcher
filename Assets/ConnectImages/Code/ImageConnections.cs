using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ImageConnections {

    [Serializable]
    public class RadiologyImage {
        public string DICOMPatientRecord;
        public string DICOMStudyRecord;
        public string DICOMSeriesRecord;
        public string DICOMImageRecord;
        public string imageSource;
        public int imageIndexStart;
        public int imageIndexEnd;
        public float P1x;
        public float P1y;
        public float P2x;
        public float P2y;
        public float P3x;
        public float P3y;
        public float P4x;
        public float P4y;
    }

    [Serializable]
    public class PathologyMacroImage {
        public string label;
        public string imageSource;
        public int imageZoomLevel; //0 = normal zoom.
        public float P1x;
        public float P1y;
        public float P2x;
        public float P2y;
        public float P3x;
        public float P3y;
        public float P4x;
        public float P4y;
    }

    [Serializable]
    public class PathologyHistologyImage {
        public string imageSource;
    }
    
    [Serializable]
    public class RadiologyPathologyConnection {

        public string label;
        public List<RadiologyImage> dicom = new List<RadiologyImage>();
        public List<PathologyMacroImage> macro = new List<PathologyMacroImage>();
        public List<PathologyHistologyImage> histology = new List<PathologyHistologyImage>();

    }
    public List<RadiologyPathologyConnection> Images = new List<RadiologyPathologyConnection>();


}
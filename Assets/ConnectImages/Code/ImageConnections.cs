using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ImageConnections {
    [Serializable]
    public class Image {

        public string imageSource;
        public int imageIndex;
        public int imageWidth;
        public int imageHeight;
        public int imageX;
        public int imageY;
    }

    public Image[] Images;

}
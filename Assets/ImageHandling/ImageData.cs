using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageData {

    public string ImageSource {
        get;
    }

    public Sprite Image {
        get;
    }

    public ImageData( string imageSource, Sprite image ) {
        this.ImageSource = imageSource;
        this.Image = image;
    }
}

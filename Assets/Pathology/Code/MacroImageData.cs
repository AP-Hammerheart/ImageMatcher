using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacroImageData {

    public string ImageSource {
        get;
    }

    public int ImageIndex {
        get;
    }

    public Sprite Image {
        get;
    }

    public MacroImageData(string imageSource, int imageIndex, Sprite image ) {
        this.ImageSource = imageSource;
        this.ImageIndex = imageIndex;
        this.Image = image;
    }

    //MAKE THIS A PARENT CLASS THAT DICOMIMAGE DATA INHERITS FROM

}

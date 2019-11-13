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
    }

}

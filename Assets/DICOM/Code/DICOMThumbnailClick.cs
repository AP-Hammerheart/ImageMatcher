using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DICOMThumbnailClick : MonoBehaviour {

    private int index = 0;
    private bool indexSet = false;
    public Image preview;

    public int Index {
        get => index;
        set {
            if( indexSet ) {
                return;
            }
            indexSet = true;
            index = value;
        }
    }

    public void ThumbnailClick() {
        preview.sprite = GetComponent<Image>().sprite;
    }

}

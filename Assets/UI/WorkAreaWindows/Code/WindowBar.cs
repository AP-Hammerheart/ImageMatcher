using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowBar : MonoBehaviour {

    public GameObject WindowContent;
    public GameObject DataContent;
    public Text windowName;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ButtonClosePress() {
        //Should contain a reference to it's imagehandler so we can destroy it.
        Destroy( this.gameObject );
    }

    public void ButtonMinimizePress() {
        WindowContent.SetActive( !WindowContent.activeSelf );
    }
}

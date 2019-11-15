using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolVariables;

public class MarkSquare : MonoBehaviour {

    private CanvasGroup canvasGroup;

    public Transform panModeParent;
    public Transform transformModeParent;

    // Start is called before the first frame update
    void Start() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update() {
        if( ToolMode.toolMode == ToolModes.TransformMarkArea ) {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            if( transform.parent == panModeParent ) {
                transform.SetParent( transformModeParent, true );
            }
        } else {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            if( transform.parent == transformModeParent ) {
                transform.SetParent( panModeParent, true );
            }
        }
    }


}

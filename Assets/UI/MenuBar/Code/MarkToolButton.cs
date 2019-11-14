using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolVariables;

public class MarkToolButton : MonoBehaviour {

    public void MarkToolButtonPress() {
        ToolMode.toolMode = ToolModes.MarkArea;
    }
}

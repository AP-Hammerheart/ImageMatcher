using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolVariables;

public class PanButton : MonoBehaviour {

    public void PanButtonPress() {
        ToolMode.toolMode = ToolModes.PanZoom;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolModes {
    PanZoom,
    MarkArea,
}

public class ToolMode : MonoBehaviour {
    public ToolModes toolMode = ToolModes.PanZoom;
}

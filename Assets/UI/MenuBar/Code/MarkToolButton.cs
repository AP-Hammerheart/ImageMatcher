using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolVariables;

public class MarkToolButton : MonoBehaviour {

    public GameObject markSquarePrefab;
    public Transform workArea;

    public void CreateMarkToolButtonPress() {
        ToolMode.toolMode = ToolModes.CreateMarkArea;

        GameObject msp = Instantiate( markSquarePrefab, workArea ) as GameObject;
    }

    public void TransformMarkToolButtonPress() {
        ToolMode.toolMode = ToolModes.TransformMarkArea;
    }
}   

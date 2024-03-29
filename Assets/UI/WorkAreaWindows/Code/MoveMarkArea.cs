﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using ToolVariables;

public class MoveMarkArea : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnBeginDrag( PointerEventData eventData ) {
    }

    public void OnDrag( PointerEventData eventData ) {
        if( ToolMode.toolMode == ToolModes.TransformMarkArea ) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            worldPos.z = transform.parent.position.z;
            transform.parent.position = worldPos;
        }
    }

    public void OnEndDrag( PointerEventData eventData ) {
    }
}

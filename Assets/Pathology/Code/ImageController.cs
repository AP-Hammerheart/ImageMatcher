using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using ToolVariables;

public class ImageController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {

    private Vector3 distance = Vector3.zero;
    private Vector3 offset = Vector3.zero;
    private bool isMouseInside = false;
    private float x = 1f, y = 1f;

    public CanvasGroup moveSelectionGroup;

    private void Update() {
        if( ToolMode.toolMode == ToolModes.PanZoom && isMouseInside) {
            x += transform.localScale.x * Input.GetAxis( "Mouse ScrollWheel" );
            y += transform.localScale.y * Input.GetAxis( "Mouse ScrollWheel" );
            transform.localScale = new Vector3( x, y, 1 );
            //moveSelectionGroup.interactable = false;
            //moveSelectionGroup.blocksRaycasts = false;
            //moveSelectionGroup.transform.SetParent( transform.parent );
        } else if( ToolMode.toolMode == ToolModes.MarkArea ) {
            //moveSelectionGroup.interactable = true;
            //moveSelectionGroup.blocksRaycasts = true;
            //moveSelectionGroup.transform.SetParent( transform );
        }
    }

    public void OnBeginDrag( PointerEventData eventData ) {
        if( ToolMode.toolMode == ToolModes.PanZoom ) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            worldPos.z = transform.position.z;
            offset = worldPos - transform.position;
        } else if( ToolMode.toolMode == ToolModes.PanZoom ) {
        }
    }

    public void OnDrag( PointerEventData eventData ) {
        if( ToolMode.toolMode == ToolModes.PanZoom ) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            worldPos.z = transform.position.z;
            worldPos = worldPos - offset;
            transform.position = worldPos;
        } else if( ToolMode.toolMode == ToolModes.PanZoom ) {
        }
    }

    public void OnEndDrag( PointerEventData eventData ) {
        if( ToolMode.toolMode == ToolModes.PanZoom ) {
            offset = Vector3.zero;
        } else if( ToolMode.toolMode == ToolModes.PanZoom ) {
        }
    }

    public void OnPointerEnter( PointerEventData eventData ) {
        isMouseInside = true;
    }

    public void OnPointerExit( PointerEventData eventData ) {
        isMouseInside = false;
    }
}

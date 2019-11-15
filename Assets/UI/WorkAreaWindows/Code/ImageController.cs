using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using ToolVariables;

public class ImageController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    private Vector3 distance = Vector3.zero;
    private Vector3 offset = Vector3.zero;
    private bool isMouseInside = false;
    private float x = 1f, y = 1f;

    public CanvasGroup moveSelectionGroup;
    public GameObject markAreaPrefab;

    private void Update() {
        if( ToolMode.toolMode == ToolModes.PanZoom && isMouseInside) {
            x += transform.localScale.x * Input.GetAxis( "Mouse ScrollWheel" );
            y += transform.localScale.y * Input.GetAxis( "Mouse ScrollWheel" );
            transform.localScale = new Vector3( x, y, 1 );
        }
    }

    public void OnBeginDrag( PointerEventData eventData ) {
        if( ToolMode.toolMode == ToolModes.PanZoom ) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            worldPos.z = transform.position.z;
            offset = worldPos - transform.position;
        }
    }

    public void OnDrag( PointerEventData eventData ) {
        if( ToolMode.toolMode == ToolModes.PanZoom ) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            worldPos.z = transform.position.z;
            worldPos = worldPos - offset;
            transform.position = worldPos;
        }
    }

    public void OnEndDrag( PointerEventData eventData ) {
        if( ToolMode.toolMode == ToolModes.PanZoom ) {
            offset = Vector3.zero;
        }
    }

    public void OnPointerEnter( PointerEventData eventData ) {
        isMouseInside = true;
    }

    public void OnPointerExit( PointerEventData eventData ) {
        isMouseInside = false;
    }

    public void OnPointerClick( PointerEventData eventData ) {
        if( ToolMode.toolMode == ToolModes.CreateMarkArea /*&& transform.childCount == 0*/ ) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            worldPos.z = transform.position.z;
            markAreaPrefab.SetActive( true );
            markAreaPrefab.transform.position = worldPos;
            //GameObject msp = Instantiate( markAreaPrefab, worldPos, Quaternion.identity, transform.parent );
            //msp.GetComponent<MarkSquare>().transformModeParent = transform;
            //msp.GetComponent<MarkSquare>().panModeParent = transform.parent;
            ToolMode.toolMode = ToolModes.TransformMarkArea;
        }
    }
}

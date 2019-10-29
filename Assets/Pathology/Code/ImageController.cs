using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    private Vector3 distance = Vector3.zero;
    private Vector3 offset = Vector3.zero;
    private bool panZoomImage = true;
    private bool moveSelection = false;
    public Toggle panZoomToggle;
    public Toggle moveSelectionToggle;
    public CanvasGroup moveSelectionGroup;

    // Start is called before the first frame update
    private void Start() {
        panZoomImage = panZoomToggle.isOn;
    }

    float x = 1f, y = 1f;

    private void Update() {
        panZoomImage = panZoomToggle.isOn;
        moveSelection = moveSelectionToggle.isOn;
        if( panZoomImage ) {
            x += transform.localScale.x * Input.GetAxis( "Mouse ScrollWheel" );
            y += transform.localScale.y * Input.GetAxis( "Mouse ScrollWheel" );
            transform.localScale = new Vector3( x, y, 1 );
            moveSelectionGroup.interactable = false;
            moveSelectionGroup.blocksRaycasts = false;
            moveSelectionGroup.transform.SetParent( transform.parent );
        } else if( moveSelection ) {
            moveSelectionGroup.interactable = true;
            moveSelectionGroup.blocksRaycasts = true;
            moveSelectionGroup.transform.SetParent( transform );
        }
    }

    public void OnBeginDrag( PointerEventData eventData ) {
        if( panZoomImage ) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            worldPos.z = transform.position.z;
            offset = worldPos - transform.position;
        } else if( moveSelection ) {
        }
    }

    public void OnDrag( PointerEventData eventData ) {
        if( panZoomImage ) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            worldPos.z = transform.position.z;
            worldPos = worldPos - offset;
            transform.position = worldPos;
        } else if( moveSelection ) {
        }
    }

    public void OnEndDrag( PointerEventData eventData ) {
        if( panZoomImage ) {
            offset = Vector3.zero;
        } else if( moveSelection ) {
        }
    }
}

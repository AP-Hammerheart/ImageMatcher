using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowMover : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    private Vector3 offset = Vector3.zero;

    public void OnBeginDrag( PointerEventData eventData ) {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        worldPos.z = transform.parent.position.z;
        offset = worldPos - transform.parent.position;
    }

    public void OnDrag( PointerEventData eventData ) {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        worldPos.z = transform.parent.position.z;
        worldPos = worldPos - offset;
        transform.parent.position = worldPos;
    }

    public void OnEndDrag( PointerEventData eventData ) {
        offset = Vector3.zero;
    }
}

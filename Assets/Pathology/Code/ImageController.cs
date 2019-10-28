using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    private Vector3 distance = Vector3.zero;
    private float dist = 0f;
    private Vector3 offset = Vector3.zero;

    // Start is called before the first frame update
    void Awake() {

    }

    float x=1f, y = 1f;

    private void Update() {
        x += transform.localScale.x * Input.GetAxis( "Mouse ScrollWheel" );
        y += transform.localScale.y * Input.GetAxis( "Mouse ScrollWheel" );
        transform.localScale = new Vector3( x, y, 1 );
    }

    //Use scroll to scale
    //use mouse click to assign and move 4 corners.

    public void OnBeginDrag( PointerEventData eventData ) {
        //distance = Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint( transform.position ).z ) ) - transform.position;
        //dist = Vector2.Distance( transform.position, Input.mousePosition );
        Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        worldPos.z = transform.position.z;
        offset = worldPos - transform.position;
    }

    public void OnDrag( PointerEventData eventData ) {
        //transform.position = new Vector3( Input.mousePosition.x - dist, Input.mousePosition.y - dist, transform.position.z );
        Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        worldPos.z = transform.position.z;
        worldPos = worldPos - offset;
        transform.position = worldPos;
    }

    public void OnEndDrag( PointerEventData eventData ) {
        offset = Vector3.zero;
    }
}

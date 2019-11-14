using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotateMarkArea : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    private float startAngle = 0;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnBeginDrag( PointerEventData eventData ) {
    }

    public void OnDrag( PointerEventData eventData ) {
        Vector2 mp = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        Vector2 dir = mp - (Vector2)transform.parent.position;

        float angle = Mathf.Atan2( dir.y, dir.x ) * Mathf.Rad2Deg - startAngle;

        if( angle < transform.parent.eulerAngles.z ) {
            transform.parent.eulerAngles = new Vector3( 0, 0, angle );
        }
    }

    public void OnEndDrag( PointerEventData eventData ) {
    }
}

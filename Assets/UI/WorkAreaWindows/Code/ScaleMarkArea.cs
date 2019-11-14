using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScaleMarkArea : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Vector2 minSize;
    public Vector2 maxSize;

    private RectTransform rectTransform;
    private Vector2 currentPointerPosition;
    private Vector2 previousPointerPosition;

    void Awake() {
        rectTransform = transform.parent.GetComponent<RectTransform>();
    }

    public void OnBeginDrag( PointerEventData eventData ) {
        rectTransform.SetAsLastSibling();
        RectTransformUtility.ScreenPointToLocalPointInRectangle( rectTransform, eventData.position, eventData.pressEventCamera, out previousPointerPosition );

    }

    public void OnDrag( PointerEventData data ) {
        if( rectTransform == null )
            return;

        Vector2 sizeDelta = rectTransform.sizeDelta;

        RectTransformUtility.ScreenPointToLocalPointInRectangle( rectTransform, data.position, data.pressEventCamera, out currentPointerPosition );
        Vector2 resizeValue = currentPointerPosition - previousPointerPosition;

        sizeDelta += new Vector2( resizeValue.x, -resizeValue.y );
        sizeDelta = new Vector2(
            Mathf.Clamp( sizeDelta.x, minSize.x, maxSize.x ),
            Mathf.Clamp( sizeDelta.y, minSize.y, maxSize.y )
            );

        rectTransform.sizeDelta = sizeDelta;

        previousPointerPosition = currentPointerPosition;
    }

    public void OnEndDrag( PointerEventData eventData ) {
    }
}

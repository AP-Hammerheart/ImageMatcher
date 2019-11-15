using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMarkArea : MonoBehaviour {

    //private Vector3 offset = Vector3.zero;

    private void Start() {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        worldPos.z = transform.position.z;
        //offset = worldPos - transform.position;
    }

    // Update is called once per frame
    void Update() {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        worldPos.z = transform.position.z;
        //worldPos = worldPos - offset;
        transform.position = worldPos;

        if( Input.GetMouseButtonDown( 0 ) ) {
            Destroy( gameObject );

        }

    }
}

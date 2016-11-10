using UnityEngine;
using System.Collections;

public class OffMLight : MonoBehaviour{
    private GameObject mLight;
    private bool On;
    // private Light mlt;
    void Start(){
        On = false;
        mLight = GameObject.Find("mLight");
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            if (On) { 
                mLight.GetComponent<Light>().range = 0;
            }
        }
    }
    void OnMouseDown(){
        On = true;
    }
    void OnMouseUp(){
        On = false;
    }

}

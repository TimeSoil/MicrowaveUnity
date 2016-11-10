using UnityEngine;
using System.Collections;

public class OnMLight : MonoBehaviour {

	private GameObject mLight;
    private bool On;
   // private Light mlt;
    void Start(){
        mLight = GameObject.Find("mLight");
        On = false;
    }

	void Update () {
        if (Input.GetMouseButtonDown(0)){
            if (On)
            {
                mLight.GetComponent<Light>().range = 5;
            }
        }
	}
    void OnMouseDown()
    {
        On = true;
    }
    void OnMouseUp()
    {
        On = false;
    }
}

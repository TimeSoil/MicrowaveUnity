using UnityEngine;
using System.Collections;

public class OffFunc : MonoBehaviour {
    private GameObject mLight;
    private GameObject countDownShow;

	// Use this for initialization
	void Start () {
        mLight = GameObject.Find("mLight");
        countDownShow = GameObject.Find("countDownShow");
	}
	
	// Update is called once per frame
	void Update () {
	    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit是一个结构体对象，用来储存射线返回的信息  
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == "mOffFuncBefore")
                {
                    //1、关灯	
                    LightOff();
                    //2、倒计时为0
                    CountDownToZero();
                }
            }
        }
	}

    void LightOff()
    {
        mLight.GetComponent<Light>().range = 0;
    }
    void CountDownToZero()
    {
        GameObject.Find("ControlTime").GetComponent<TimeControl>().setTotalTime(0);
        countDownShow.GetComponent<TextMesh>().text = "00:00";
        countDownShow.GetComponent<TextMesh>().fontStyle = FontStyle.Normal;
        countDownShow.GetComponent<TextMesh>().characterSize = 0.8f;
        GameObject.Find("mOnFuncBefore").GetComponent<OnFunc>().CancelInvoke_ControlTime();
    }
}

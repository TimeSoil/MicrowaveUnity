using UnityEngine;
using System.Collections;
/*	
 *  1、开灯		
    2、倒计时		
    3、倒计时结束后，关灯		
    4、开门时，灯关、时间停止		
*/
public class OnFunc : MonoBehaviour {

    private GameObject mLight;
    private GameObject countDownShow;
    private long totalTime;
    //public  static bool On;

    public long getTotalTime()
    {
        return totalTime;
    }
    public void setTotalTime(long totalTime)
    {
        this.totalTime = totalTime;
    }
 /*   public bool getOnStatus()
    {
        return On;
    }
  * */
    public void CancelInvoke_ControlTime()
    {
        this.CancelInvoke();
    }
	void Start () {
        mLight = GameObject.Find("mLight");
        countDownShow = GameObject.Find("countDownShow");
        //On = false;
	}
	
	void Update () 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit是一个结构体对象，用来储存射线返回的信息  
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == "mOnFuncBefore")
                {
                    
                    //1、开灯	
                    
                    //2、倒计时	
                    totalTime = GameObject.Find("ControlTime").GetComponent<TimeControl>().getTotalTime();
                    if (totalTime > 0) 
                    { 
                        LightOn();
                        InvokeRepeating("CountDown", 1, 1);
                    }
                    //3、倒计时结束后，关灯		(CountDown();调用中完成)
                }
            }
        }
	}

    void LightOn()
    {
            mLight.GetComponent<Light>().range = 5;
    }
    void LightOff()
    {
        mLight.GetComponent<Light>().range = 0;
    }
    void CountDown()
    {
        int second;
        int min;
        string showTime;
       
        totalTime -= 1;
        second = (int)totalTime % 60;
        min = (int)totalTime / 60;
        if (min < 10)
        {
            if (second < 10)
            {
                showTime = "0" + min + ":" + "0" + second;
            }
            else
            {
                showTime = "0" + min + ":" + second;
            }
        }
        else
        {
            if (second < 10)
            {
                showTime = min + ":" + "0" + second;
            }
            else
            {
                showTime = min + ":" + second;
            }

        }
        countDownShow.GetComponent<TextMesh>().text = showTime;
        countDownShow.GetComponent<TextMesh>().fontStyle = FontStyle.Normal;
        countDownShow.GetComponent<TextMesh>().characterSize = 0.8f;
        print(countDownShow.GetComponent<TextMesh>().text);
        GameObject.Find("ControlTime").GetComponent<TimeControl>().setTotalTime(totalTime);
        if ((totalTime <= 0))
        {
            LightOff();
            this.CancelInvoke();
        }
    }
}

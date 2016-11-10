using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour
{
    private GameObject countDownShow;
    private GameObject F_add;
    private GameObject F_sub;
    private int LightStatus;
    private static long totalTime;
    private string showTime;
    private int min;
    private int second;

    public long getTotalTime()
    {
        return totalTime;
    }
    public void setTotalTime(long pTime)
    {
        totalTime = pTime;
    }
   /* public void setLightStatus(int LightStatus)
    {
        this.LightStatus = LightStatus;
    }
    * */

    // Use this for initialization
    void Start()
    {
        countDownShow = GameObject.Find("countDownShow");
        F_add = GameObject.Find("F+");
        F_sub = GameObject.Find("F-");
        LightStatus = 1;
        totalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
            if(LightStatus == 1)
            {
                F_add.GetComponent<TextMesh>().color = Color.red;
                F_sub.GetComponent<TextMesh>().color = Color.white;
            }
            else if (LightStatus == -1)
            {
                F_sub.GetComponent<TextMesh>().color = Color.red;
                F_add.GetComponent<TextMesh>().color = Color.white;
            }
            //创建一条射线，产生的射线是在世界空间中，从相机的近裁剪面开始并穿过屏幕position(x,y)像素坐标（position.z被忽略）  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit是一个结构体对象，用来储存射线返回的信息  
            RaycastHit hit;
            //如果射线碰撞到对象，把返回信息储存到hit中  

            //判断是否点击
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit))
                {

                    //判断状态
                    //1.如果为1或0，则加
                    if (LightStatus >= 0)
                    {
                        //如果是10秒。。。则加
                        if (hit.transform.gameObject.name == "10MinF")
                        {
                            totalTime += 60 * 10;
                        }
                        else if (hit.transform.gameObject.name == "1MinF")
                        {
                            totalTime += 60 * 1;
                        }
                        else if (hit.transform.gameObject.name == "10SF")
                        {
                            totalTime += 10;
                        }
                        else if (hit.transform.gameObject.name == "1SF")
                        {
                            totalTime += 1;
                        }
                    }

                    //2.如果为-1，则减

                    if (LightStatus < 0)
                    {
                        print("-");
                        //如果是10秒。。。则减
                        if (hit.transform.gameObject.name == "10MinF" && (totalTime - 10 * 60) >= 0)
                        {
                            totalTime -= 60 * 10;
                        }
                        else if (hit.transform.gameObject.name == "1MinF" && (totalTime - 1 * 60) >= 0)
                        {
                            totalTime -= 60 * 1;
                        }
                        else if (hit.transform.gameObject.name == "10SF" && (totalTime - 10) >= 0)
                        {
                            totalTime -= 10;
                        }
                        else if (hit.transform.gameObject.name == "1SF" && (totalTime - 1) >= 0)
                        {
                            totalTime -= 1;
                        }
                    }
                    if (hit.transform.gameObject.name == "mFunc+")
                    {
                        LightStatus = 1;
                    }
                    if (hit.transform.gameObject.name == "mFunc-")
                    {
                        LightStatus = -1;
                    }


                    GameObject.Find("mOnFuncBefore").GetComponent<OnFunc>().setTotalTime(totalTime);
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
                }
            }
        }
       
    }

    
   

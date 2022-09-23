using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scan : MonoBehaviour
{
    public GameObject light;
    public GameObject point;
    [Header("雷达参数设定")] 
    [Tooltip("射线根数")]
    [SerializeField] private int rayNum = 26;
    [Tooltip("激光雷达最大有效距离")]
    [SerializeField] [Range(1f,30f)]private float sensorLength = 15f;
    [Tooltip("激光纵向角度")]
    [SerializeField] [Range(1f, 90f)] private float angle = 90;
    [Tooltip("旋转角度步长")]
    [SerializeField] private float stepAngle = 1f;

    [Header("雷达显示效果设定")]
    [Tooltip("是否显示射线")]
    [SerializeField] private bool showRay = true;

    [Header("点云保存设定。。。")]
    /*    [Tooltip("射线颜色")]
        [SerializeField] private Color rayColor = Color.blue;*/

    private Vector3 direction;  //目前的射线方向
    private Ray ray;    //目前射线
    public RaycastHit hit; //射线扫到的点

    private LineRenderer line;
    private List<LineRenderer> lightlines;
    private void Start()
    {
        Debug.Log("aaaaa");
        lightlines = new List<LineRenderer>();
        for (int i= 0; i < rayNum; i++)//创建一堆线
        {
            GameObject temp = Instantiate(light);
            line = temp.GetComponent<LineRenderer>();
            lightlines.Add(line);
        }
        Debug.Log(lightlines.Count);
        
       // line = GetComponent<LineRenderer>();
    }
    void FixedUpdate()
    {
        //扫描
        Scan(); //向前发出射线
        transform.Rotate(0, stepAngle, 0, Space.Self);
    }

    //扫描
    void Scan()
    {
        for (int i = 0; i < rayNum; i++)
        {
            direction = Quaternion.AngleAxis(angle * i / rayNum, transform.right) * transform.forward;
            ray = new Ray(transform.position, direction);

            if (showRay) //射线可视化
            {
                if (Physics.Raycast(ray, out hit, sensorLength))
                {
                    // Debug.DrawLine(transform.position, hit.point, rayColor);//只有debug才能看到，没啥用
                    lightlines[i].GetComponent<Renderer>().enabled = true;
                    lightlines[i].positionCount = 2;
                    lightlines[i].SetPosition(0, transform.position);
                    lightlines[i].SetPosition(1, hit.point);

                    /* line.positionCount=2;
                    line.SetPosition(0, transform.position);
                    line.SetPosition(1, hit.point);*/
                    
                    //GameObject temp = Instantiate(point, hit.point, Quaternion.Euler(0, 0, 0));

                    GameObject apoint = Pool.PoolInstatient.Getpoint();//从对象池中取出一个子弹对象
                    if (apoint != null)              //如果有空闲对象，则使其激活
                    {
                        apoint.transform.position = hit.point;
                        apoint.SetActive(true);

                    }


                }
                else//没碰到障碍物
                {
                    lightlines[i].GetComponent<Renderer>().enabled = false;
                   
                }
            }       
        }
    }

}

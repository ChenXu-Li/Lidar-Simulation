using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool PoolInstatient;       //实例化一个单例
    public GameObject point;                             //我们的点对象
   // public GameObject Master;                          //岩石对象
    private bool LockPool = false;                                   //不锁定对象池的大小，可以进行扩展
    public int CountpointPool = 10000;                  //初始大小为5
   // private int CountMastertPool = 5;
    private List<GameObject> pointPool;      //点对象池
   // private List<GameObject> MasterPool;    //“岩石”对象池
    private float LastTime;                              //时间控制变量
    void Start()
    {
        PoolInstatient = this;
        LastTime = Time.time;                       //初始化时间变量
        pointPool = new List<GameObject>();            //初始化对象池
      //  MasterPool = new List<GameObject>();
        for (int NumOfStartpool = 0; NumOfStartpool < CountpointPool; NumOfStartpool++)            //为对象池中添加对象
        {
            GameObject point_P = Instantiate(point);
            point_P.SetActive(false);
            pointPool.Add(point_P);
          /*  GameObject master_P = Instantiate(Master);
            master_P.SetActive(false);
            MasterPool.Add(master_P);*/
        }
    }

    public GameObject Getpoint()                          //返回空闲对象
    {
        for (int i = 0; i < CountpointPool; i++)          //遍历对象池，寻找空闲对象
        {
            if (!pointPool[i].activeInHierarchy)              //如果对象为空闲状态，则返回这个对象
            {
                return pointPool[i];
            }
        }
        if (!LockPool)                        //如果没有空闲对象，并且没有上锁(只有start时可以创建对象），我们就往对象池里丢一个对象，并增加对象池容量
        {
            pointPool.Add(Instantiate(point));
            CountpointPool++;
        }
        return null;

    }
/*    public GameObject GetMaster()      //思想如上
    {
        for (int i = 0; i < CountMastertPool; i++)
        {
            if (!MasterPool[i].activeInHierarchy)
            {
                return MasterPool[i];
            }
        }
        if (!LockPool)
        {
            MasterPool.Add(Instantiate(Master));
            CountMastertPool++;
        }

        return null;
    }*/

    /*private void Update()     //update用来生成我们的岩石对象，我把它放在了对象管理池的类中
    {
        if (Time.time - LastTime > 2.0f)  //当时间间隔为2秒时，则从对象池中取出一个对象，并激活，重新赋予运动逻辑
        {
            if (GetMaster() != null)
            {
                GameObject master = GetMaster();
                master.transform.position = new Vector3(10, Random.Range(-3.3f, 5.5f), 0);//在y轴方向随机生成
                master.SetActive(true);                             //激活对象
                LastTime = Time.time;                      //初始化时间控制变量
            }
        }
    }*/
}


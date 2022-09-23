# 激光雷达仿真

尝试在unity中搭建驾驶场景，进行tof激光雷达的仿真

## 雷达浅析

目前来说，汽车的外界感知有两种主流方案，纯视觉传感器及雷达   

- RGB传感器
  - 双目，多目

- 雷达
  - 激光雷达
  - 毫米波雷达(电磁波)
  - 超声波雷达(机械波)

通常来说，雷达指的是英文Radar的音译(radio detection and ranging)，意思为"无线电探测和测距"，即用无线电的方法发现目标并测定它们的空间位置。

而激光雷达LiDAR(Light Detection and Ranging),是激光探测及测距系统的简称，是一种利用光波进行测量的**主动探测方式**。主动探测方式是指探测系统通过接收自身发出的信号回波来进行测量，区别于例如摄像机等通过接收环境光获取信号的被动探测方式。激光雷达通过测量激光从发出经障碍物反射到被传感器接收所经历的时间(time of flight,tof)，来计算障碍物的距离。

激光雷达一般分为**脉冲式**和**连续波式**两种。脉冲式激光雷达利用时间间隔来计算相对车距；而连续波激光雷达则通过计算反射光与反射光之间的相位差得到目标距离。

![image-20220830181526900](http://cdn.lcx-blog.top/img/image-20220830181526900.png)

## 为什么要进行仿真

1. 激光雷达的成本很高，普遍在几十万元，采用仿真可以批量模拟各种类型的雷达，节省成本。
2. 可以根据实际情况，方便的调整雷达参数，增加雷达数量，贴合需求。
3. 可以模拟各种复杂路况和天气，短时间完成大量测试，节约时间。

## 开始仿真

### 1.搭建场景

用预制模型搭建城市交通场景，摆放小车和行人

![image-20220830232916838](http://cdn.lcx-blog.top/img/image-20220830232916838.png)

### 2.创建雷达模型

为了实现激光的渲染，我们需要使用LineRender组件显示光线，使用Raycast函数来检测光线碰撞点。

使用一个sphere来显示碰撞点，同时使用伪彩色图来显示直观距离。

Tips：雷达扫描时会产生大量点，频繁创建销毁对象会大量消耗计算资源，因此我们还需要使用对象池技术。

![QQ录屏20220830234522](http://cdn.lcx-blog.top/img/QQ录屏20220830234522.gif)

![image-20220831110448351](http://cdn.lcx-blog.top/img/image-20220831110448351.png)

可以自定义调整雷达的各种参数

```c#
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
    ·····
```



### 3.仿真并生成点云模型

![image-20220831105842269](http://cdn.lcx-blog.top/img/image-20220831105842269.png)

![image-20220830235002342](http://cdn.lcx-blog.top/img/image-20220830235002342.png)

![QQ录屏20220831000245](http://cdn.lcx-blog.top/img/QQ录屏20220831000245.gif)

![image-20220831111318977](http://cdn.lcx-blog.top/img/image-20220831111318977.png)


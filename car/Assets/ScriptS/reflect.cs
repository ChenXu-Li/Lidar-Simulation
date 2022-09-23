using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


public class reflect : MonoBehaviour
{
 
    private LineRenderer _lineRender;


    private List<Vector3> _renderPoints;

    public GameObject a;
    private void Awake()
    {
        _lineRender = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _renderPoints = new List<Vector3>();
        _renderPoints.Add(transform.position); //LineRenderer以自己为起点

        _renderPoints.Add(a.transform.position);

        _lineRender.positionCount = _renderPoints.Count;
        _lineRender.SetPositions(_renderPoints.ToArray());
    }

  
  
}

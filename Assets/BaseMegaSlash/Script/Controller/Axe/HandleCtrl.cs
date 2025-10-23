// Project  RopeUp
// FileName  HandleCtrl.cs
// Author  AX
// Desc
// CreateAt   2025-09-05 09:09:41 
//


using System;
using UnityEngine;

public class HandleCtrl : MonoBehaviour
{

    public GameObject ropeLoopObj;

    public float lineWidth;
    
    private LineRenderer _lineRenderer;
    
    private Transform _startPoint;

    
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = lineWidth;
        _startPoint = transform;
    }


    void Update()
    {
        _lineRenderer.SetPosition(0, _startPoint.position);
        _lineRenderer.SetPosition(1, ropeLoopObj.transform.position);
        
    }


}



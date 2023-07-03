using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Transform mainCameraTransform;       //메인카메라
    [SerializeField] private Transform canvasTransform;           //캔버스 위치

    void Start()
    {
        mainCameraTransform = Camera.main.transform;
        canvasTransform = GetComponent<Transform>();
    }

    void Update()
    {
        canvasTransform.LookAt(mainCameraTransform);             //메인 카메라를 쳐다본다.
        
    }
}

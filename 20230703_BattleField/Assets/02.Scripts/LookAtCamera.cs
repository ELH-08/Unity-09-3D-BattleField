using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Transform mainCameraTransform;       //����ī�޶�
    [SerializeField] private Transform canvasTransform;           //ĵ���� ��ġ

    void Start()
    {
        mainCameraTransform = Camera.main.transform;
        canvasTransform = GetComponent<Transform>();
    }

    void Update()
    {
        canvasTransform.LookAt(mainCameraTransform);             //���� ī�޶� �Ĵٺ���.
        
    }
}

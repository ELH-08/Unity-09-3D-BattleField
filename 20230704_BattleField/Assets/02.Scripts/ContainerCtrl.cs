using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//컨테이너에 총알 발사시 
//1. 섬광 이펙트
//2. 오디오소스, 오디오 클립


public class ContainerCtrl : MonoBehaviour
{
    [SerializeField] private GameObject spark;                      //섬광
    [SerializeField] private AudioSource audioSource;               //오디오소스
    [SerializeField] private AudioClip sparkSound;                  //섬광 사운드

    //hit_metal

    void Start()
    {
        spark = Resources.Load<GameObject>("Effect/Spark");         //Resources 폴더 - Effect 폴더 - MetalImpacts 프리팹
        audioSource = GetComponent<AudioSource>();                  // 자신의 컴포넌트에서 호출  
        sparkSound = Resources.Load("hit_metal") as AudioClip;      // c# 방식의 형 변환
        //sparkSound = (AudioClip) Resources.Load("hit_metal");     // c 방식의 형 변환
        
    }

    //업데이트문 삭제

    //충돌 감지 통과 = Trigger

    //충돌 감지 Block
    private void OnCollisionEnter(Collision collision)          //컨테이너와 충돌시
    {
        if (collision.gameObject.CompareTag("BULLET"))          //충돌한 태그 BULLET 여부 확인
        {
            Destroy(collision.gameObject);                      //충돌한 개체(BULLET Tag) 삭제
            GameObject spk = Instantiate(spark, collision.transform.position, Quaternion.identity); //복제 생성(원본, 위치, )
            Destroy(spk, 3.0f);                                                                     //섬광 생성 3초 후에 삭제 
            audioSource.PlayOneShot(sparkSound, 1.0f);                                              //섬광 사운드    
        }
        
    }

}

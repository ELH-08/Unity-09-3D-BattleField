using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//1. 총알 발사 위치
//2. 총알 프리팹
//3. 발사 사운드

public class FireCtrl : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform FirePosition;                      //탄알 발사 위치
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private ParticleSystem MuzzleFlash;                 //탄알 발사시 총구에 나타나는 섬광 이펙트
    [SerializeField] private ParticleSystem CartridgeEjectEffect;        //탄알 발사시 나타나는 탄피 이펙트

    void Start()
    {
        FirePosition = transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Transform>();                 //FirePosition의 위치값 가져오기
        MuzzleFlash = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(0).GetComponent<ParticleSystem>(); //MuzzleFlashEffect의 컴포넌트 가져오기
        CartridgeEjectEffect = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(1).GetComponent<ParticleSystem>(); //CartridgeEjectEffect의 컴포넌트 가져오기
        bulletPrefab = (GameObject)Resources.Load("Bullet");  //C, C++ 자료형 변환 - bullet prefab 자료형을 GameObject로 맞춰줌
        audioSource = GetComponent<AudioSource>();
        fireSound = Resources.Load<AudioClip>("gunShot");    //C++ 자료형 변환 - <>안에 자료형 넣음  

    }

    // Update is called once per frame
    void Update()
    {
        Fire();                                 //발사 함수 호출

    }

    private void Fire()                  //총알 발사 함수 , private 이 클래스(스크립트)에서만 접근가능
    {
        if (Input.GetMouseButtonDown(0))            //좌 클릭을 누르면 - 0:좌, 1:우, 2:휠
        {
            if (!HandAniMotion.isRunning)            //HandAniMotion.isRunning == false  :  (HandAniMotion 스크립트에 정의된) 달리지 않을 경우에
            {
                Instantiate(bulletPrefab, FirePosition.position, FirePosition.rotation);  //프리팹 복제품 생성(what, where, how, rotation)
                audioSource.PlayOneShot(fireSound, 1.0f);                                 //????
                MuzzleFlash.Play();                                                       //섬광 이펙트 재생
                CartridgeEjectEffect.Play();                                              //탄피 이펙트 재생
            }
        }
        else if (Input.GetMouseButtonUp(0))                                               //좌 클릭을 떼면  - 0:좌, 1:우, 2:휠
        {
            MuzzleFlash.Stop();                                                           //섬광 이펙트 멈춤
            CartridgeEjectEffect.Stop();                                                  //탄피 이펙트 멈춤
        }

    }
}

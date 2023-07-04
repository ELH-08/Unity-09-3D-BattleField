using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//1. 총알 발사 위치
//2. 총알 프리팹
//3. 발사 사운드

public class FireCtrl : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform FirePosition;                     //탄알 발사 위치
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private ParticleSystem MuzzleFlash;                 //탄알 발사시 총구에 나타나는 섬광 이펙트
    [SerializeField] private ParticleSystem CartridgeEjectEffect;        //탄알 발사시 나타나는 탄피 이펙트
    [SerializeField] private Animation anim;                             //애니메이션
    
    [SerializeField] private bool isReload = false;                             //재장전 여부
    //public static int bulletCount = 0;                                        //전역으로 클래스 호출이 가능함
    public int bulletCount = 0;
    //스택 힙 데이터 : 프로그램 종료될때까지 끝까지 기억한다. 
    //객체 박싱 언박싱 


    void Start()
    {
        anim = transform.GetChild(0).GetChild(0).GetComponent<Animation>();                                              //FPSController - FirstPersonCharacter - CombatSG_Player의 애니메이션
        FirePosition = transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Transform>();                          //FirePosition의 위치값 가져오기
        MuzzleFlash = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(0).GetComponent<ParticleSystem>();          //MuzzleFlashEffect의 컴포넌트 가져오기
        CartridgeEjectEffect = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(1).GetComponent<ParticleSystem>(); //CartridgeEjectEffect의 컴포넌트 가져오기
        bulletPrefab = (GameObject)Resources.Load("Bullet");                                                             //C, C++ 자료형 변환 - bullet prefab 자료형을 GameObject로 맞춰줌
        audioSource = GetComponent<AudioSource>();
        fireSound = Resources.Load<AudioClip>("gunShot");                                                                //C++ 자료형 변환 - <>안에 자료형 넣음  

    }

    // Update is called once per frame
    void Update()
    {
        if(isReload == false)                       //재장전이 아닐 경우 (fire, reload 애니메이션 겹침 방지)
            Fire();                                 //발사 함수 호출

    }

    private void Fire()                                                                   //총알 발사 함수 , private 이 클래스(스크립트)에서만 접근가능
    {
        if (Input.GetMouseButtonDown(0))                                                  //좌 클릭을 누르면 - 0:좌, 1:우, 2:휠
        {
            if (!HandAniMotion.isRunning)                                                 //HandAniMotion.isRunning == false  :  (HandAniMotion 스크립트에 정의된) 달리지 않을 경우에
            {
                Instantiate(bulletPrefab, FirePosition.position, FirePosition.rotation);  //프리팹 복제품 생성(what, where, how, rotation)
                audioSource.PlayOneShot(fireSound, 1.0f);                                 //????
                MuzzleFlash.Play();                                                       //섬광 이펙트 재생
                CartridgeEjectEffect.Play();                                              //탄피 이펙트 재생
                anim.Play("fire");                                                        //공격 애니메이션

                bulletCount++;
                if (bulletCount == 10)                                                   //총알이 10발이면 
                {
                    StartCoroutine(ShowReloading());                                    //재장전 함수 호출
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))                                               //좌 클릭을 떼면  - 0:좌, 1:우, 2:휠
        {
            MuzzleFlash.Stop();                                                           //섬광 이펙트 멈춤
            CartridgeEjectEffect.Stop();                                                  //탄피 이펙트 멈춤
        }

    }



    IEnumerator ShowReloading() 
    {
        isReload = true;
        anim.Play("pump1");
        yield return new WaitForSeconds(1); //1초 후 
        isReload = false;
        bulletCount = 0;
    }



}

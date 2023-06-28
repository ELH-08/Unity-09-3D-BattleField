using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//1. �Ѿ� �߻� ��ġ
//2. �Ѿ� ������
//3. �߻� ����

public class FireCtrl : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform FirePosition;                      //ź�� �߻� ��ġ
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private ParticleSystem MuzzleFlash;                 //ź�� �߻�� �ѱ��� ��Ÿ���� ���� ����Ʈ
    [SerializeField] private ParticleSystem CartridgeEjectEffect;        //ź�� �߻�� ��Ÿ���� ź�� ����Ʈ

    void Start()
    {
        FirePosition = transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Transform>();                 //FirePosition�� ��ġ�� ��������
        MuzzleFlash = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(0).GetComponent<ParticleSystem>(); //MuzzleFlashEffect�� ������Ʈ ��������
        CartridgeEjectEffect = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(1).GetComponent<ParticleSystem>(); //CartridgeEjectEffect�� ������Ʈ ��������
        bulletPrefab = (GameObject)Resources.Load("Bullet");  //C, C++ �ڷ��� ��ȯ - bullet prefab �ڷ����� GameObject�� ������
        audioSource = GetComponent<AudioSource>();
        fireSound = Resources.Load<AudioClip>("gunShot");    //C++ �ڷ��� ��ȯ - <>�ȿ� �ڷ��� ����  

    }

    // Update is called once per frame
    void Update()
    {
        Fire();                                 //�߻� �Լ� ȣ��

    }

    private void Fire()                  //�Ѿ� �߻� �Լ� , private �� Ŭ����(��ũ��Ʈ)������ ���ٰ���
    {
        if (Input.GetMouseButtonDown(0))            //�� Ŭ���� ������ - 0:��, 1:��, 2:��
        {
            if (!HandAniMotion.isRunning)            //HandAniMotion.isRunning == false  :  (HandAniMotion ��ũ��Ʈ�� ���ǵ�) �޸��� ���� ��쿡
            {
                Instantiate(bulletPrefab, FirePosition.position, FirePosition.rotation);  //������ ����ǰ ����(what, where, how, rotation)
                audioSource.PlayOneShot(fireSound, 1.0f);                                 //????
                MuzzleFlash.Play();                                                       //���� ����Ʈ ���
                CartridgeEjectEffect.Play();                                              //ź�� ����Ʈ ���
            }
        }
        else if (Input.GetMouseButtonUp(0))                                               //�� Ŭ���� ����  - 0:��, 1:��, 2:��
        {
            MuzzleFlash.Stop();                                                           //���� ����Ʈ ����
            CartridgeEjectEffect.Stop();                                                  //ź�� ����Ʈ ����
        }

    }
}

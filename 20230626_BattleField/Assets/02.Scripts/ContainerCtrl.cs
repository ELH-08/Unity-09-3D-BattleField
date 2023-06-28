using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����̳ʿ� �Ѿ� �߻�� 
//1. ���� ����Ʈ
//2. ������ҽ�, ����� Ŭ��


public class ContainerCtrl : MonoBehaviour
{
    [SerializeField] private GameObject spark;                      //����
    [SerializeField] private AudioSource audioSource;               //������ҽ�
    [SerializeField] private AudioClip sparkSound;                  //���� ����

    //hit_metal

    void Start()
    {
        spark = Resources.Load<GameObject>("Effect/Spark");         //Resources ���� - Effect ���� - MetalImpacts ������
        audioSource = GetComponent<AudioSource>();                  // �ڽ��� ������Ʈ���� ȣ��  
        sparkSound = Resources.Load("hit_metal") as AudioClip;      // c# ����� �� ��ȯ
        //sparkSound = (AudioClip) Resources.Load("hit_metal");     // c ����� �� ��ȯ
        
    }

    //������Ʈ�� ����

    //�浹 ���� ��� = Trigger

    //�浹 ���� Block
    private void OnCollisionEnter(Collision collision)          //�����̳ʿ� �浹��
    {
        if (collision.gameObject.CompareTag("BULLET"))          //�浹�� �±� BULLET ���� Ȯ��
        {
            Destroy(collision.gameObject);                      //�浹�� ��ü(BULLET Tag) ����
            GameObject spk = Instantiate(spark, collision.transform.position, Quaternion.identity); //���� ����(����, ��ġ, )
            Destroy(spk, 3.0f);                                                                     //���� ���� 3�� �Ŀ� ���� 
            audioSource.PlayOneShot(sparkSound, 1.0f);                                              //���� ����    
        }
        
    }

}

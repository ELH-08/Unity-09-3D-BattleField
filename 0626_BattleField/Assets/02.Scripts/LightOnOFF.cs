using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOFF : MonoBehaviour
{

    //FPSController - Character Controller�� �浹 ����

    [SerializeField] private Light stairLight;


    void Start()
    {
        stairLight = GetComponent<Light>(); //�ڱ� �ڽ��� ���۳�Ʈ
        
    }

    //�ݹ��Լ� : ȣ�� ���ص� �˾Ƽ� ȣ���ϴ� �Լ�
    //�浹���� - isTrigger
    private void OnTriggerEnter(Collider other) //�ݶ��̴� �ȿ� ���Դٸ�
    {

        #region string ���ڿ��̶� �޸𸮰� ���ſ���
        //if (other.gameObject.tag == "Player")   //�浹�� �±װ� �÷��̾��̸�
        //{
        //    stairLight.enabled = true;          //light ���۳�Ʈ�� Ȱ��ȭ
        //}

        //��Ը� ������Ʈ�� ���ڿ��� ������� �ʴ´�. ���� �ƴϳ� �˻��ϰ�, �����Ҵ��ϰ�, ����Ʈ ����ǰ�, �⸳�� �´��� �Ҵ��ϰ�.
        //C++ Ŭ���� �ȿ� ���ڿ��� ������ �����Ҵ����� �޸𸮸� ��Ƹ��� ���� �Ҵ�ǰ�.
        //����Ʈ�� �Ҵ�ǰ� �⸳�� �´��� �˻��ϰ� ������ ???
        #endregion

        if (other.gameObject.CompareTag("Player")) //�̷��� �ϸ� �����Ҵ��� ���� �ʰ� �´��� �ƴ��� �˻縸 �Ѵ�.
        {
            stairLight.enabled = true;
        }

    }


    //�ݹ��Լ� : ȣ�� ���ص� �˾Ƽ� ȣ���ϴ� �Լ�
    //�浹���� - ��������
    private void OnTriggerExit(Collider other)  //�ݶ��̴� �ȿ� ���Դٰ� ���������ٸ� 
    {
        #region string ���ڿ��̶� �޸𸮰� ���ſ���
        //if (other.gameObject.tag == "Player")   //�浹�� �±װ� �÷��̾��̸�
        //{
        //    stairLight.enabled = false;          //light ���۳�Ʈ�� Ȱ��ȭ
        //}

        //��Ը� ������Ʈ�� ���ڿ��� ������� �ʴ´�. ���� �ƴϳ� �˻��ϰ�, �����Ҵ��ϰ�, ����Ʈ ����ǰ�, �⸳�� �´��� �Ҵ��ϰ�.
        //C++ Ŭ���� �ȿ� ���ڿ��� ������ �����Ҵ����� �޸𸮸� ��Ƹ���. ���� �Ҵ�ǰ�.
        //����Ʈ�� �Ҵ�ǰ� �⸳�� �´��� �˻��ϰ� ������ ???
        #endregion

        if (other.gameObject.CompareTag("Player"))
        {
            stairLight.enabled = true;
        }

    }//�����Ҵ� : �ʿ��Ҷ� �޸𸮰� �Ҵ�� ���� �����Ҵ��̴�.




    //�浹 ������ �ҰŶ� ������Ʈ���� �ʿ����.
    //void Update() 
    //{

    //}
}

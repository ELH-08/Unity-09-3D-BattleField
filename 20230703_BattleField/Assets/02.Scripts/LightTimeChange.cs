using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTimeChange : MonoBehaviour
{
    [SerializeField] private Light whiteLight;
    [SerializeField] private Light blueLight;
    [SerializeField] private Light yellowLight;
    [SerializeField] private AudioSource source;                    //������ҽ�
    [SerializeField] private AudioClip lightOpening;                //����Ʈ Ŭ��


    void Start()    //���� ���۰� ���ÿ�
    {
        //�ʱ갪 ����
        whiteLight = transform.GetChild(0).GetComponent<Light>();
        blueLight = transform.GetChild(1).GetComponent<Light>();
        yellowLight = transform.GetChild(2).GetComponent<Light>();
        source = GetComponent<AudioSource>();
        lightOpening = Resources.Load<AudioClip>("LightOpening");

        TurnOn();
    }

    void TurnOn() //����Ʈ �Ѵ� �Լ� ȣ��
    {
        StartCoroutine(ShowLightChange());     //StartCoroutine ȣ�� 
    }


    //*** �� �����Ӹ��� ����Ǳ� ������ ���� ������Ʈ�� ������ �ǽð����� �ݿ��ϴ� �� ���, �޸� ���� ��� StartCoroutine ȣ��
    IEnumerator ShowLightChange() //eum ������
    {
        whiteLight.enabled = true;              //��� �ѱ�
        blueLight.enabled = false;              //�Ķ��� ����
        yellowLight.enabled = false;            //����� ����
        source.PlayOneShot(lightOpening, 1.0f); //����Ʈ������ ���� ��� - �� �𸣸� , ������ �� �־���� �� �� �� �ִ�.
        yield return new WaitForSeconds(3f);    //�ش� �ڷ�ƾ�� ���� �����ϰ�, 3�� ����� �Ŀ� ���� �ܰ�� ���� - �񵿱�(�ٸ� �� �� �� �ִ�), ����� �ٸ� �� ����

        whiteLight.enabled = false;             //��� ����
        blueLight.enabled = true;               //�Ķ��� �ѱ�
        yellowLight.enabled = false;            //����� ����
        source.PlayOneShot(lightOpening, 1.0f); //����Ʈ������ ���� ��� - �� �𸣸� , ������ �� �־���� �� �� �� �ִ�.
        yield return new WaitForSeconds(3f);    //�ش� �ڷ�ƾ�� ���� �����ϰ�, 3�� ����� �Ŀ� ���� �ܰ�� ���� - �񵿱�(�ٸ� �� �� �� �ִ�), ����� �ٸ� �� ����

        whiteLight.enabled = false;             //��� ����
        blueLight.enabled = false;              //�Ķ��� ����
        yellowLight.enabled = true;             //����� �ѱ�
        source.PlayOneShot(lightOpening, 1.0f); //����Ʈ������ ���� ��� - �� �𸣸� , ������ �� �־���� �� �� �� �ִ�.
        yield return new WaitForSeconds(3f);    //�ش� �ڷ�ƾ�� ���� �����ϰ�, 3�� ����� �Ŀ� ���� �ܰ�� ���� - �񵿱�(�ٸ� �� �� �� �ִ�), ����� �ٸ� �� ����

        TurnOn();                               //TurnOn() ȣ��


        


    } 

}

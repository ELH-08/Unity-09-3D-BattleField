using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTimeChange : MonoBehaviour
{
    [SerializeField] private Light whiteLight;
    [SerializeField] private Light blueLight;
    [SerializeField] private Light yellowLight;
    [SerializeField] private AudioSource source;                    //오디오소스
    [SerializeField] private AudioClip lightOpening;                //라이트 클립


    void Start()    //게임 시작과 동시에
    {
        //초깃값 설정
        whiteLight = transform.GetChild(0).GetComponent<Light>();
        blueLight = transform.GetChild(1).GetComponent<Light>();
        yellowLight = transform.GetChild(2).GetComponent<Light>();
        source = GetComponent<AudioSource>();
        lightOpening = Resources.Load<AudioClip>("LightOpening");

        TurnOn();
    }

    void TurnOn() //라이트 켜는 함수 호출
    {
        StartCoroutine(ShowLightChange());     //StartCoroutine 호출 
    }


    //*** 매 프레임마다 실행되기 때문에 게임 오브젝트의 동작을 실시간으로 반영하는 데 사용, 메모리 낭비 대신 StartCoroutine 호출
    IEnumerator ShowLightChange() //eum 열거형
    {
        whiteLight.enabled = true;              //흰불 켜기
        blueLight.enabled = false;              //파란불 끄기
        yellowLight.enabled = false;            //노랑불 끄기
        source.PlayOneShot(lightOpening, 1.0f); //라이트오프닝 사운드 출력 - 잘 모르면 , 찍으면 뭘 넣어야할 지 알 수 있다.
        yield return new WaitForSeconds(3f);    //해당 코루틴을 실행 중지하고, 3초 경과한 후에 다음 단계로 진행 - 비동기(다른 일 할 수 있다), 동기는 다른 거 못함

        whiteLight.enabled = false;             //흰불 끄기
        blueLight.enabled = true;               //파란불 켜기
        yellowLight.enabled = false;            //노랑불 끄기
        source.PlayOneShot(lightOpening, 1.0f); //라이트오프닝 사운드 출력 - 잘 모르면 , 찍으면 뭘 넣어야할 지 알 수 있다.
        yield return new WaitForSeconds(3f);    //해당 코루틴을 실행 중지하고, 3초 경과한 후에 다음 단계로 진행 - 비동기(다른 일 할 수 있다), 동기는 다른 거 못함

        whiteLight.enabled = false;             //흰불 끄기
        blueLight.enabled = false;              //파란불 끄기
        yellowLight.enabled = true;             //노랑불 켜기
        source.PlayOneShot(lightOpening, 1.0f); //라이트오프닝 사운드 출력 - 잘 모르면 , 찍으면 뭘 넣어야할 지 알 수 있다.
        yield return new WaitForSeconds(3f);    //해당 코루틴을 실행 중지하고, 3초 경과한 후에 다음 단계로 진행 - 비동기(다른 일 할 수 있다), 동기는 다른 거 못함

        TurnOn();                               //TurnOn() 호출


        


    } 

}

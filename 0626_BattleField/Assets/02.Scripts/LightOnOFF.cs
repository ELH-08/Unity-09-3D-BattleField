using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOFF : MonoBehaviour
{

    //FPSController - Character Controller와 충돌 감지

    [SerializeField] private Light stairLight;


    void Start()
    {
        stairLight = GetComponent<Light>(); //자기 자신의 컴퍼넌트
        
    }

    //콜백함수 : 호출 안해도 알아서 호출하는 함수
    //충돌감지 - isTrigger
    private void OnTriggerEnter(Collider other) //콜라이더 안에 들어왔다면
    {

        #region string 문자열이라 메모리가 무거워짐
        //if (other.gameObject.tag == "Player")   //충돌한 태그가 플레이어이면
        //{
        //    stairLight.enabled = true;          //light 컴퍼넌트를 활성화
        //}

        //대규모 프로젝트는 문자열은 사용하지 않는다. 갔냐 아니냐 검사하고, 동적할당하고, 포인트 선언되고, 기립값 맞는지 할당하고.
        //C++ 클래스 안에 문자열이 있으면 동적할당으로 메모리를 잡아먹음 힙이 할당되고.
        //포인트가 할당되고 기립값 맞는지 검사하고 느려짐 ???
        #endregion

        if (other.gameObject.CompareTag("Player")) //이렇게 하면 동적할당이 되지 않고 맞는지 아닌지 검사만 한다.
        {
            stairLight.enabled = true;
        }

    }


    //콜백함수 : 호출 안해도 알아서 호출하는 함수
    //충돌감지 - 빠져나감
    private void OnTriggerExit(Collider other)  //콜라이더 안에 들어왔다가 빠져나갔다면 
    {
        #region string 문자열이라 메모리가 무거워짐
        //if (other.gameObject.tag == "Player")   //충돌한 태그가 플레이어이면
        //{
        //    stairLight.enabled = false;          //light 컴퍼넌트를 활성화
        //}

        //대규모 프로젝트는 문자열은 사용하지 않는다. 갔냐 아니냐 검사하고, 동적할당하고, 포인트 선언되고, 기립값 맞는지 할당하고.
        //C++ 클래스 안에 문자열이 있으면 동적할당으로 메모리를 잡아먹음. 힙이 할당되고.
        //포인트가 할당되고 기립값 맞는지 검사하고 느려짐 ???
        #endregion

        if (other.gameObject.CompareTag("Player"))
        {
            stairLight.enabled = true;
        }

    }//동적할당 : 필요할때 메모리가 할당됨 총은 동적할당이다.




    //충돌 감지만 할거라서 업데이트문은 필요없다.
    //void Update() 
    //{

    //}
}

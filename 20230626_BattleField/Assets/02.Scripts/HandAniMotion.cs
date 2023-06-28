using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAniMotion : MonoBehaviour
{
    //1. 달릴 때 총을 접는다.
    //2. 달리다가 멈추면 다시 총을 겨눈다.
    //3. 달릴 때 총 쏘는 거 금지

    


    [SerializeField]            //private 선언해도 인스펙터 창에서 보이게 - 보안떄문에 멤버필드는 거의 private으로 사용하고, 다 확인한 이후에는 serialize field는 없앤다. 
    private Animation CombatSg;
    public static bool isRunning = false;   //달리고 있는 중인지 아닌지의 여부, static  전역변수 실시간으로 메모리를 지정함. 끝까지 기억한다. 프로그램 종료할때 사라진다.
    

    void Start()
    {
        CombatSg = transform.GetChild(0).GetChild(0).GetComponent<Animation>(); // FPSController - FirstPersonCharacter - CombatSG_Player의 애니메이션

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))     //왼쪽 쉬프트와 W를 동시에 누르면
        {
            CombatSg.Play("running");               //달리는 애니메이션
            isRunning = true;                       //달리는 중
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) //왼쪽 쉬프트를 떼면
        {
            CombatSg.Play("runStop");               //총 다시 겨누기
            isRunning = false;                      //달리지 않음
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;                                               //AI기능 라이브러리를 사용


//필요한 라이브러리 
//필요한 컴포넌트 - 초깃값 설정
//필요한 내용 1. 공격 거리 2. 추적 거리 

public class SkeletonCtrl : MonoBehaviour
{

    [SerializeField] private Animator animator;                    //애니메이터
    [SerializeField] private NavMeshAgent navMeshAgent;            //플레이어 추적
    [SerializeField] private Transform skeletonTransform;          //스켈레톤 위치
    [SerializeField] private Transform playerTransform;            //플레이어 위치
    public float attackDistance = 3.5f;                            //공격 거리
    public float trackingDistance = 20f;                           //추적 거리

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        skeletonTransform = transform;
        playerTransform = GameObject.FindWithTag("Player").transform;   //플레이어 태그를 찾아 위치 저장

        
    }

    void Update() //실시간
    {
        if (SkeletonDamage.isDie ) return;  //(SkeletonDamage 스크립트) 해골이 사망 확정이면 ==true안해도 그 자체가  true, 하위 로직으로 안 내려가고 업데이트를 빠져나감.


        float ditancePandS = Vector3.Distance(playerTransform.position, skeletonTransform.position);        //플레이어와 해골의 거리 (플레이어 위치, 해골 위치 -> 순서 바뀌어도 상관없음)

        if (ditancePandS <= attackDistance)                       //공격 범위 안이면
        {
            navMeshAgent.isStopped = true;                        //네비게이션 멈춤
            animator.SetBool("isAttack", true);                   //공격 애니메이션(공격 파라미터) 활성화
        }
        else if (ditancePandS <= trackingDistance)                //추적 범위 안이면
        {
            navMeshAgent.isStopped = false;                       //네비게이션 가동
            navMeshAgent.destination = playerTransform.position;  //네비게이션 목적지 = 플레이어 위치
            animator.SetBool("isTracking", true);                 //걷기 애니메이션(추적 파라미터) 활성화
            animator.SetBool("isAttack", false);                  //공격 애니메이션(공격 파라미터) 비활성화
        }
        else                                                      //둘 다 아니면
        {
            navMeshAgent.isStopped = true;                        //네이게이션 멈춤
            animator.SetBool("isTracking", false);                //걷기 애니메이션(추적 파라미터) 비활성화
        }
    }
}

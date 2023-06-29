using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;                                   //UnityEngine의 AI기능 라이브러리를 사용


public class ZombieCtrl : MonoBehaviour
{
    //private UnityEngine.AI.NavMeshAgent agent;         //라이브러리 비호출시 이런 식으로 사용해야 한다.
    [SerializeField] private NavMeshAgent navMeshAgent;  //플레이어 추적
    [SerializeField] private Animator animator;          //애니메이션 동작
    public float traceDistance = 15.0f;                  //추적 거리
    public float attackDistance = 3.0f;                  //공격 거리
    [SerializeField] private Transform playerTransform;                   //플레이어 위치


    void Start()
    {
        //초깃값에 컴퍼넌트 설정
        playerTransform = GameObject.FindWithTag("Player").transform;       //하이어라키에서 플레이어 태그를 가진 오브젝트의 위치값 대입
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (ZombieDamage.isDie == true) return;  //(ZombieDamage 스크립트) 좀비가 사망 확정이면, 하위 로직으로 안 내려가고 업데이트를 빠져나감.


        float distanceZandP = Vector3.Distance(transform.position, playerTransform.position);    //좀비랑 플레이어 사이 거리

        if (distanceZandP <= attackDistance)                     //공격 범위 안이면
        {
            navMeshAgent.isStopped = true;                       //네비게이션 추적 중지
            animator.SetBool("isAttack", true);                  //애니메이션 공격 동작 재생
        }
        else if (distanceZandP <= traceDistance)                 //추적 범위 안이면
        {
            navMeshAgent.destination = playerTransform.position; //플레이어 추적지 목적지 =
            navMeshAgent.isStopped = false;                      //추적 시작
            animator.SetBool("isTracking", true);
            animator.SetBool("isAttack", false);
        }
        else                                                     //공격범위도 추적범위도 아니면
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("isTraking", false);
        }
    }
}

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
    private Transform playerTransform;
    void Start()
    {
        //초깃값에 컴퍼넌트 설정
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceZandP = Vector3.Distance(transform.position, playerTransform.position);    //좀비랑 플레이어 사이 거리

        if (attackDistance <= 3.0f)                     //공격 거리 3 안이면
        {
            navMeshAgent.isStopped = true;              //네비게이션 추적 중지
            animator.SetBool("isAttack", true);         //애니메이션 공격 동작 재생

        }
        else if (traceDistance <= 15.0f) 
        {
            
        }
        
    }
}

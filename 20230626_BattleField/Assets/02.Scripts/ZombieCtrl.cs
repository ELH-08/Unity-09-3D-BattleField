using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;                                   //UnityEngine�� AI��� ���̺귯���� ���


public class ZombieCtrl : MonoBehaviour
{
    //private UnityEngine.AI.NavMeshAgent agent;         //���̺귯�� ��ȣ��� �̷� ������ ����ؾ� �Ѵ�.
    [SerializeField] private NavMeshAgent navMeshAgent;  //�÷��̾� ����
    [SerializeField] private Animator animator;          //�ִϸ��̼� ����
    public float traceDistance = 15.0f;                  //���� �Ÿ�
    public float attackDistance = 3.0f;                  //���� �Ÿ�
    private Transform playerTransform;
    void Start()
    {
        //�ʱ갪�� ���۳�Ʈ ����
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceZandP = Vector3.Distance(transform.position, playerTransform.position);    //����� �÷��̾� ���� �Ÿ�

        if (attackDistance <= 3.0f)                     //���� �Ÿ� 3 ���̸�
        {
            navMeshAgent.isStopped = true;              //�׺���̼� ���� ����
            animator.SetBool("isAttack", true);         //�ִϸ��̼� ���� ���� ���

        }
        else if (traceDistance <= 15.0f) 
        {
            
        }
        
    }
}

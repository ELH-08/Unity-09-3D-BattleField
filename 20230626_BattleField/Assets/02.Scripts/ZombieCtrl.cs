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
    [SerializeField] private Transform playerTransform;                   //�÷��̾� ��ġ


    void Start()
    {
        //�ʱ갪�� ���۳�Ʈ ����
        playerTransform = GameObject.FindWithTag("Player").transform;       //���̾��Ű���� �÷��̾� �±׸� ���� ������Ʈ�� ��ġ�� ����
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (ZombieDamage.isDie == true) return;  //(ZombieDamage ��ũ��Ʈ) ���� ��� Ȯ���̸�, ���� �������� �� �������� ������Ʈ�� ��������.


        float distanceZandP = Vector3.Distance(transform.position, playerTransform.position);    //����� �÷��̾� ���� �Ÿ�

        if (distanceZandP <= attackDistance)                     //���� ���� ���̸�
        {
            navMeshAgent.isStopped = true;                       //�׺���̼� ���� ����
            animator.SetBool("isAttack", true);                  //�ִϸ��̼� ���� ���� ���
        }
        else if (distanceZandP <= traceDistance)                 //���� ���� ���̸�
        {
            navMeshAgent.destination = playerTransform.position; //�÷��̾� ������ ������ =
            navMeshAgent.isStopped = false;                      //���� ����
            animator.SetBool("isTracking", true);
            animator.SetBool("isAttack", false);
        }
        else                                                     //���ݹ����� ���������� �ƴϸ�
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("isTraking", false);
        }
    }
}

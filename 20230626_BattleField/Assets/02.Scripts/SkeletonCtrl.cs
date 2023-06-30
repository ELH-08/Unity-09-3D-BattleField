using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;                                               //AI��� ���̺귯���� ���


//�ʿ��� ���̺귯�� 
//�ʿ��� ������Ʈ - �ʱ갪 ����
//�ʿ��� ���� 1. ���� �Ÿ� 2. ���� �Ÿ� 

public class SkeletonCtrl : MonoBehaviour
{

    [SerializeField] private Animator animator;                    //�ִϸ�����
    [SerializeField] private NavMeshAgent navMeshAgent;            //�÷��̾� ����
    [SerializeField] private Transform skeletonTransform;          //���̷��� ��ġ
    [SerializeField] private Transform playerTransform;            //�÷��̾� ��ġ
    public float attackDistance = 3.5f;                            //���� �Ÿ�
    public float trackingDistance = 20f;                           //���� �Ÿ�

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        skeletonTransform = transform;
        playerTransform = GameObject.FindWithTag("Player").transform;   //�÷��̾� �±׸� ã�� ��ġ ����

        
    }

    void Update() //�ǽð�
    {
        if (SkeletonDamage.isDie ) return;  //(SkeletonDamage ��ũ��Ʈ) �ذ��� ��� Ȯ���̸� ==true���ص� �� ��ü��  true, ���� �������� �� �������� ������Ʈ�� ��������.


        float ditancePandS = Vector3.Distance(playerTransform.position, skeletonTransform.position);        //�÷��̾�� �ذ��� �Ÿ� (�÷��̾� ��ġ, �ذ� ��ġ -> ���� �ٲ� �������)

        if (ditancePandS <= attackDistance)                       //���� ���� ���̸�
        {
            navMeshAgent.isStopped = true;                        //�׺���̼� ����
            animator.SetBool("isAttack", true);                   //���� �ִϸ��̼�(���� �Ķ����) Ȱ��ȭ
        }
        else if (ditancePandS <= trackingDistance)                //���� ���� ���̸�
        {
            navMeshAgent.isStopped = false;                       //�׺���̼� ����
            navMeshAgent.destination = playerTransform.position;  //�׺���̼� ������ = �÷��̾� ��ġ
            animator.SetBool("isTracking", true);                 //�ȱ� �ִϸ��̼�(���� �Ķ����) Ȱ��ȭ
            animator.SetBool("isAttack", false);                  //���� �ִϸ��̼�(���� �Ķ����) ��Ȱ��ȭ
        }
        else                                                      //�� �� �ƴϸ�
        {
            navMeshAgent.isStopped = true;                        //���̰��̼� ����
            animator.SetBool("isTracking", false);                //�ȱ� �ִϸ��̼�(���� �Ķ����) ��Ȱ��ȭ
        }
    }
}

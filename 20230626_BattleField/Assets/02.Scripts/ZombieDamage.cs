using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bloodEffect;
    public float hp = 100f;                         //HP
    public float hpInit = 100f;                     //HP 초기값
    [SerializeField] private CapsuleCollider capsuleCollider;
    public static bool isDie = false;               //사망여부

    void Start()
    {
        //초깃값 설정 : 먼저 잡혀야하는게 우선적으로 나와야 한다.
        animator = GetComponent<Animator>();                            //자신의 컴퍼넌트에서 호출
        bloodEffect = Resources.Load<GameObject>("Effect/Blood");
        capsuleCollider = GetComponent<CapsuleCollider>();              //자신의 컴퍼넌트에서 호출

    }

    //void Update(){}

    private void OnCollisionEnter(Collision collision)          //충돌체
    {
        if (collision.gameObject.CompareTag("BULLET"))          //충돌한 개체의 태그가 BULLET이면
        {
            Destroy(collision.gameObject);                      //BULLET 삭제
            GameObject IbloodEffect = Instantiate(bloodEffect, collision.transform.position, Quaternion.identity);  //피효과 복제 생성(피효과, 충돌한 위치, 회전 없음)
            Destroy(IbloodEffect, 1.5f);
            animator.SetTrigger("isHit");                       //멈춤 애니메이션 
            hp -= 35f;                                          //충돌할때마다 hp -35 깍이고
            if (hp <= 0)                                        //hp가 0보다 작으면
            {
                Die();                                          //Die() 호출
            }

        }
    }

    void Die() 
    {
        animator.SetTrigger("isDie");                           //사망 애니메이션 호출
        capsuleCollider.enabled = false;                        //캡슐 콜라이더 비활성화 (죽은 좀비가 일어나지 않도록)
        isDie = true;                                           //사망 확정


    }

}

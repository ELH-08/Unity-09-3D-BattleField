using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                            //UI 라이브러리 사용

public class SkeletonDamage : MonoBehaviour
{
    [SerializeField] private Animator animator;                 //애니메이터
    [SerializeField] private GameObject bloodEffect;            //피효과
    [SerializeField] private CapsuleCollider capsuleCollider;   //캡슐 콜라이더
    [SerializeField] private Canvas canvas;               //UI라이브러리 필요
    [SerializeField] private Image hpBar;                 //UI라이브러리 필요
    [SerializeField] private Text hpText;                 //UI라이브러리 필요

    public float hp = 100f;                                     //HP
    public float hpInit = 100f;                                 //HP 초기값
    public static bool isDie = false;                           //사망여부


    void Start()
    {
        canvas = transform.GetChild(3).GetComponent<Canvas>();
        hpBar = transform.GetChild(3).GetChild(1).GetComponent<Image>();
        hpText = transform.GetChild(3).GetChild(2).GetComponent<Text>();
        //초깃값 설정 : 먼저 잡혀야하는게 우선적으로 나와야 한다.
        capsuleCollider = GetComponent<CapsuleCollider>();              //자신의 컴퍼넌트에서 호출
        animator = GetComponent<Animator>();                            //자신의 컴퍼넌트에서 호출
        bloodEffect = Resources.Load<GameObject>("Effect/Blood");
        hpBar.color = Color.green;                                       //
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}


    private void OnCollisionEnter(Collision collision)          //충돌체
    {
        if (collision.gameObject.CompareTag("BULLET"))          //충돌한 개체의 태그가 BULLET이면
        {
            Destroy(collision.gameObject);                      //BULLET 삭제
            GameObject IbloodEffect = Instantiate(bloodEffect, collision.transform.position, Quaternion.identity);  //피효과 복제 생성(피효과, 충돌한 위치, 회전 없음)
            Destroy(IbloodEffect, 1.5f);
            animator.SetTrigger("isHit");                       //멈춤 애니메이션 
            HP_Manager();
            if (hp <= 0)                                        //hp가 0보다 작으면
            {
                Die();                                          //Die() 호출
            }

        }
    }

    private void HP_Manager()
    {
        hp -= 35f;                                          //충돌할때마다 hp -35 깍이고
        hp = Mathf.Clamp(hp, 0f, 100f);                     //HP 음수가 못나오도록 제한을 검
        hpBar.fillAmount = hp / hpInit;                     //?
        hpText.text = " HP: " + hp.ToString();              //HP : 숫자를 출력 (문자 + 숫자를 문자형식으로 바꿔서 보다 빠르게 출력)


        if (hpBar.fillAmount <= 0.3f)                       //HP가 30프로 미만이면
        {
            hpBar.color = Color.red;
        }
        else if (hpBar.fillAmount <= 0.5f)                 //HP가 50프로 미만이면
        {
            hpBar.color = Color.yellow;
        }
    }

    void Die()
    {
        animator.SetTrigger("isDie");                           //사망 애니메이션 호출
        GetComponent<Rigidbody>().isKinematic = true;           //해골 사망했을 때 물리효과(충돌 여운으로 밀리는 효과) 없게 만듬
        capsuleCollider.enabled = false;                        //캡슐 콜라이더 비활성화 (죽은 좀비가 일어나지 않도록)
        isDie = true;                                           //사망 확정
        canvas.enabled = false;
        Destroy(gameObject, 5.0f);                              //사망하면 개체 사라지기

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;                           //UI 라이브러리 사용

public class ZombieDamage : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bloodEffect;
    [SerializeField] private CapsuleCollider capsuleCollider;
    //[SerializeField] private Image UnityEngine.UI.hpBar;               //UI라이브러리가 없으면 이런 식으로 사용해야 한다.
    [SerializeField] private Canvas canvas;               //UI라이브러리 필요
    [SerializeField] private Image hpBar;                 //UI라이브러리 필요
    [SerializeField] private Text hpText;                 //UI라이브러리 필요
    [SerializeField] private BoxCollider punchCollider;   //UI라이브러리 필요

    public float hp = 100f;                               //HP
    public float hpInit = 100f;                           //HP 초기값

    public static bool isDie = false;                     //사망여부

    void Start()
    {
        //초깃값 설정 : 먼저 잡혀야하는게 우선적으로 나와야 한다.
        punchCollider = transform.GetChild(0).GetChild(2).GetComponent<BoxCollider>();
        canvas = transform.GetChild(18).GetComponent<Canvas>();
        hpBar = transform.GetChild(18).GetChild(0).GetChild(0).GetComponent<Image>();
        hpText = transform.GetChild(18).GetChild(0).GetChild(1).GetComponent<Text>();
        capsuleCollider = GetComponent<CapsuleCollider>();                          //자신에서 호출
        animator = GetComponent<Animator>();                                        //자신에서 호출
        bloodEffect = Resources.Load<GameObject>("Effect/Blood");
        hpBar.color = Color.green;                                                  //녹색으로 설정

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
        hpText.text = " HP: " + hp.ToString();              //HP : 숫자를 출력 (문자 + 숫자를 문자형식으로 바꿔서 보다 빠르게 출력)
        hpBar.fillAmount = hp / hpInit;                     //?

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
        capsuleCollider.enabled = false;                        //캡슐 콜라이더 비활성화 (죽은 좀비가 일어나지 않도록)
        isDie = true;                                           //사망 확정
        canvas.enabled = false;
        Destroy(gameObject, 5.0f);                              //사망하면 개체 사라지기
        GameManager.instance.KillScore(1);                      //사망시 GameManager에서 킬 점수 1을 호출한다.
    }


    //public 
    public void PunchColliderEnable()                           //손 콜라이더 활성화 함수
    {
        punchCollider.enabled = true;                           //펀치 콜라이더 활성화
    }

    //public
    public void PunchColliderDisable()                          //손 콜라이더 비활성화 함수 
    {
        punchCollider.enabled = false;                          //펀치 콜라이더 비활성화
    }

}

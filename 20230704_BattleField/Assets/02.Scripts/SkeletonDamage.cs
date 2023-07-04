using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                            //UI 라이브러리(캔버스, 이미지, 텍스트 등) 사용

public class SkeletonDamage : MonoBehaviour
{
    [SerializeField] private Animator animator;                 //애니메이터
    [SerializeField] private GameObject bloodEffect;            //피 효과
    [SerializeField] private CapsuleCollider capsuleCollider;   //캡슐 콜라이더
    [SerializeField] private Canvas canvas;                     //캔버스
    [SerializeField] private Image HPbar;                       //HP 체력바 이미지
    [SerializeField] private Text HPtext;                       //HP 텍스트 

    
    public float HP = 100f;                                     //HP
    public float HPInit = 100f;                                 //HP 초기 값
    public static bool isDie = false;                           //사망 여부
    public BoxCollider swordCollider;                        //해골 검 콜라이더 - 복잡한 구조라서 찾기 힘들어서 직접 끌어서 넣음.

    void Start()
    {
        //초깃값 설정 : 먼저 잡혀야하는게 우선적으로 나와야 한다.
        canvas = transform.GetChild(3).GetComponent<Canvas>();
        HPbar = transform.GetChild(3).GetChild(1).GetComponent<Image>();
        HPtext = transform.GetChild(3).GetChild(2).GetComponent<Text>();
        capsuleCollider = GetComponent<CapsuleCollider>();                  //(이 스크립트가 달린)자신의 컴퍼넌트에서 호출
        animator = GetComponent<Animator>();                                //(이 스크립트가 달린)자신의 컴퍼넌트에서 호출
        bloodEffect = Resources.Load<GameObject>("Effect/Blood");
        HPbar.color = Color.green;                                          //해골 HP 체력바를 초록색
    }



    private void OnCollisionEnter(Collision collision)          //충돌체 진입
    {
        if (collision.gameObject.CompareTag("BULLET"))          //충돌한 개체의 태그가 BULLET이면
        {
            Destroy(collision.gameObject);                      //BULLET 삭제
            GameObject IbloodEffect = Instantiate(bloodEffect, collision.transform.position, Quaternion.identity);  //피효과 복제 생성(피효과, 충돌한 위치, 회전 없음)
            Destroy(IbloodEffect, 1.5f);                        //복제된 피 효과 삭제
            animator.SetTrigger("isHit");                       //멈춤 애니메이션 
            HP_Manager();
            if (HP <= 0)                                        //hp가 0보다 작으면
            {
                Die();                                          //Die() 호출
            }

        }
    }

    private void HP_Manager()
    {
        HP -= 35f;                                          //충돌할때마다 hp -35 깍이고
        HP = Mathf.Clamp(HP, 0f, 100f);                     //HP 음수가 못나오도록 제한을 검
        HPbar.fillAmount = HP / HPInit;                     //?
        HPtext.text = " HP: " + HP.ToString();              //HP : 숫자를 출력 (문자 + 숫자를 문자형식으로 바꿔서 보다 빠르게 출력)


        if (HPbar.fillAmount <= 0.3f)                       //HP가 30프로 미만이면
        {
            HPbar.color = Color.red;
        }
        else if (HPbar.fillAmount <= 0.5f)                 //HP가 50프로 미만이면
        {
            HPbar.color = Color.yellow;
        }
    }

    void Die()                                                  //사망 함수
    {
        animator.SetTrigger("isDie");                           //사망 애니메이션 호출
        GetComponent<Rigidbody>().isKinematic = true;           //해골 사망했을 때 물리효과(충돌 여운으로 밀리는 효과) 없게 만듬
        capsuleCollider.enabled = false;                        //캡슐 콜라이더 비활성화 (죽은 좀비가 일어나지 않도록)
        isDie = true;                                           //사망 확정
        canvas.enabled = false;
        Destroy(gameObject, 5.0f);                              //사망하면 개체 사라지기
        GameManager.instance.KillScore(1);                      //사망시 GameManager에서 킬 점수 1을 호출한다.

    }

    //public 
    public void SwordColliderEnable()                           //검 콜라이더 활성화 함수
    {
        swordCollider.enabled = true;                           //검 콜라이더 활성화     
    }

    //public
    public void SwordColliderDisable()                          //검 콜라이더 비활성화 함수 
    {
        swordCollider.enabled = false;                          //검 콜라이더 비활성화
    }
}

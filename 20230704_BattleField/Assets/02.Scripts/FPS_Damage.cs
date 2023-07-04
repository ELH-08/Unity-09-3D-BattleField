using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                               //UI 라이브러리 호출                             
using UnityEngine.SceneManagement;                  //씬 전환 관리 라이브러리 호출
using Unity.VisualScripting;                        //?

public class FPS_Damage : MonoBehaviour
{

    [SerializeField] private Image HPbar;               //HP
    [SerializeField] private float HP;                  //HP
    [SerializeField] private float HPinit = 100f;       //HP 초기값
    [SerializeField] private GameObject killCanvas;     //사망시 나타나는 캔버스


    void Start()
    {
        killCanvas = GameObject.Find("Canvas_UI").transform.GetChild(2).gameObject;
        HPbar = GameObject.Find("Canvas_UI").transform.GetChild(0).GetChild(0).GetComponent<Image>();
        HP = HPinit;                                //HP초기값 설정
        HPbar.color = Color.red;


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PUNCH"))   //만일 충돌한 태그가 펀치면
        {
            HP -= 15f;                              //HP -15씩 감소
            HP = Mathf.Clamp(HP, 0f, 100f);         //HP 범위 설정 (깍여도 0미만, 회복템 먹어도 100이상 못되도록)
            HPbar.fillAmount = HP / HPinit;
            //if (HP <= 0f)
            //    PlayerDie();
        }

        if (other.gameObject.CompareTag("SWORD"))   //만일 충돌한 태그가 검이면
        {
            HP -= 25f;                              //HP -25씩 감소
            HP = Mathf.Clamp(HP, 0f, 100f);         //HP 범위 설정 (깍여도 0미만, 회복템 먹어도 100이상 못되도록)
            HPbar.fillAmount = HP / HPinit;
            //if (HP <= 0f)
            //    PlayerDie();
        }

        //if (HP <= 0f)
        //    PlayerDie();


    }

    void PlayerDie() 
    {
        Debug.Log("플레이어 사망!");
        killCanvas.SetActive(true);                  //사망 캔버스 켜기
        Invoke("EndScene", 3.0f);                    //3초 후에 사망 씬 호출

        
    }

    void EndScene()                                  //사망 씬 
    {
        SceneManager.LoadScene("EndScene");          //EndScene으로 전환
    }

}

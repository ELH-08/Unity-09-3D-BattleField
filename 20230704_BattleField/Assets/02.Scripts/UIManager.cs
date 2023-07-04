using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                       //UI 라이브러리 호출    
using UnityEngine.SceneManagement;          //장면 전환 관리하는 라이브러리 호출
using UnityEditor;                          //Unity Editor (window 운영체제에서 유니티를 사용하는 경우) 라이브러리 호출


public class UIManager : MonoBehaviour
{
    [SerializeField] private Text FinalKillText;                  //최종 킬 수 

    void Start()
    {
        FinalKillText = GameObject.Find("Canvas_UI").transform.GetChild(2).GetChild(3).GetComponent<Text>();
        FinalKillText.text = "Final Kill : " + GameManager.instance.Totalkill.ToString();
        
        //사망 후 마우스 커서 보이도록
        Cursor.lockState = CursorLockMode.None;     //마우스 커서 숨기지 않도록 
        Cursor.visible = true;                      //마우스 커서 보이도록

        //(특정 키를 누르면)  마우스 커서 안 보이게
        //Cursor.lockState = CursorLockMode.Locked;     //마우스 커서 숨기지 않도록 
        //Cursor.visible = false;                      //마우스 커서 보이도록

    }

    public void PlayGame() 
    {

        SceneManager.LoadScene("BattleFieldScene");     //메인 씬으로 전환
    }

    public void Quit()
    {
//매크로 : 함수 호출 전에 미리 기능이 실행되는 것
        
        //두 가지 종료를 해야함 
        //1. Unity에서 종료 :
        //2. Build한 곳에서도 종료 : 

#if UNITY_EDITOR //유니티 에디터 : 윈도우에서 유니티를 사용하는 경우
        //UnityEditor.EditorApplication.isPlaying = false;  //유니티 에디터 라이브러리를 사용하지 않는 경우
        EditorApplication.isPlaying = false;
#else
       Application.Quit();                             //빌드한 곳에서 종료
#endif


    }


}

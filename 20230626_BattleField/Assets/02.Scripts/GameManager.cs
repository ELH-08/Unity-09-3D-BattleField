using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 톱니바퀴 = 설정 (게임 환경 설정)

몬스터가 태어나는 로직
1. 몬스터 프리팹
2. 스폰되는 위치 : SpawnPoint
3. 몇 초 간격으로 스폰될 건지 - ex) 좀비 3초, 해골 5초
4. 최대 몬스터 수 제한
*/

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;             //좀비 프리팹
    [SerializeField] private GameObject skeletonPrefab;           //해골 프리팹
    [SerializeField] private Transform[] spawnPoints;             //몬스터가 스폰될 위치들을 저장
    [SerializeField] private float previousTime_Z = 0f;           //이전 시간_좀비
    [SerializeField] private float previousTime_S = 0f;           //이전 시간_해골
    [SerializeField] private int maxCount = 4;                    //최대 몬스터 수 5마리로 제한
    

    void Start()
    {
        zombiePrefab = Resources.Load<GameObject>("Zombie");
        skeletonPrefab = Resources.Load<GameObject>("Skeleton");
        spawnPoints = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();  //SpawnPoints를 찾고, 자식 개체들의 위치들을 전부 배열 형태로 저장. (자기 자신까지 저장됨)
        previousTime_Z = Time.time;  //이 스크립트 시작과 동시에 해당 시간 대입
        previousTime_S = Time.time;  //이 스크립트 시작과 동시에 해당 시간 대입


    }

    void Update()
    {

        if (Time.time - previousTime_Z >= 3.0f)  //흘러간 시간(현재시 - 과거시간)이 3초 이상이면
        {
            int zombieCount = (int)GameObject.FindGameObjectsWithTag("ZOMBIE").Length; //하이어라키에서 좀비 태그를 가진 개체들의 갯수를 int형으로 변환하여 zombieCount에 저장.
            if (zombieCount <= maxCount)             //생성된 좀비 수가 최대 수 미만이면
                CreateZombie();                      //좀비 생성
            previousTime_Z = Time.time;              //과거 시간을 현재 시간으로 갱신
        }

        if (Time.time - previousTime_S >= 5.0f)  //흘러간 시간(현재시 - 과거시간)이 3초 이상이면
        {
            int skeletonCount = (int)GameObject.FindGameObjectsWithTag("SKELETON").Length; //하이어라키에서 해골 태그를 가진 개체들의 갯수를 int형으로 변환하여 zombieCount에 저장.
            if (skeletonCount <= maxCount)             //생성된 좀비 수가 최대 수 미만이면
                CreateSkeleton();                      //해골 생성
            previousTime_S = Time.time;                //과거 시간을 현재 시간으로 갱신
        }

        
    }

    void CreateZombie() 
    {
        int index = Random.Range(1, spawnPoints.Length); //배열의 두번째 부터 배열 길이값 까지  (자기 자신은 빼고 생성해야 하므로)
        Instantiate(zombiePrefab, spawnPoints[index].position, spawnPoints[index].rotation); //(what, where, how rotation)
    }

    void CreateSkeleton() 
    {
        int index = Random.Range(1, spawnPoints.Length); //배열의 두번째 부터 배열 길이값 까지  (자기 자신은 빼고 생성해야 하므로)
        Instantiate(skeletonPrefab, spawnPoints[index].position, spawnPoints[index].rotation); //(what, where, how rotation)
    }


}

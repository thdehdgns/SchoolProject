using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI Days;
    public TextMeshProUGUI Totime;
    private MainGamePlay Sedd;
    public GameObject night;
    public int ToDay = 1;
    private string AD = ""; 
    public int DayScore = 0;

    //약간 최적화하려면 updata에 말고 여기에 함수하나 만들어서 다른 코드에서 그 함수 계속 호출하면되는데 되게 귀찮네

    private void Awake()
    {
        // instance가 이미 존재하는 경우, 새로 생성된 오브젝트를 파괴
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            // 이 오브젝트를 씬 전환에서 파괴하지 않도록 설정
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Update()
    {
        ScoreReset();
        Istime();
    }

    private void Istime()
    {
        switch (DayScore)
        {
            case 0:
                AD = "아침";
                night.SetActive(false);
                break;
            case 1:
                AD = "점심";
                break;
            case 2:
                AD = "저녁";
                night.SetActive(true);
                break;
            default:
                Debug.LogWarning("시간이 이상합니다.");
                break;
        }
        

    }

    public void Sun()//버튼으로 실행
    {
        Sedd = GameObject.Find("Seed").GetComponent<MainGamePlay>();   //인스팩터 창에서 Seed를 찾고 컴퍼넌트 넣음 ㅇㅇ
        int random = Random.Range(10, 15);
        Sedd.SunnyP += random;
        if (random >= 15)
        {
            //무슨무슨 효과가 있을 예정 ㅇㅇ
        }
        Sedd.humidityP -= 10;
        random = Random.Range(10, 25);
        Sedd.freshP += random;
        DayScore += 1;
    }

    public void Water()//버튼으로 실행
    {
        Sedd = GameObject.Find("Seed").GetComponent<MainGamePlay>();
        int random = Random.Range(5, 10);
        if(random >= 10)
        {
            //무슨무슨 축하해추는 이펙트 ㅇㅇ
        }

        Sedd.humidityP += random;
        DayScore += 1;
        Sedd.SunnyP -= 5;

    }

    private void ScoreReset()
    {
        Days.text = $"{ToDay}  일차";
        Totime.text = $"{AD}";
        if (DayScore >= 3)
        {
            Sedd = GameObject.Find("Seed").GetComponent<MainGamePlay>();
            int random = Random.Range(5, 20);
            Sedd.freshP -= random;  //하루 지날때마다 신선도가 깎임
            ToDay += 1;
            DayScore = 0;
        }


        if(ToDay >= 15)
        {
            Time.timeScale = 0f;
        }
    }
}

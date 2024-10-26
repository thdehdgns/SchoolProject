using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class MainGamePlay : MonoBehaviour
{

    public int humidityP = 50;  //습도
    private int HumidityD = 50; //습도 기본값
    public int SunnyP = 0;  //태양 포인트
    public int freshP = 100; // 신선도에따라 가격변동 예정 ㅇㅇ;
    //이건 그닥 json으로 저장할 필요가 없어보임.


    private void Update()
    {
        IntoDay();
    }
    

    private void IntoDay()  //개별로 씨앗이 바뀌는거라 딱히 상관 없을듯
    {
        if(GameManager.instance.ToDay >= 15)
        {
            GameManager.instance.DayScore = 0;
            ChangeSeed();
        }

    }

    private void ChangeSeed()
    {
        //습도 ,신선도 , 그런거에 따라 씨앗이 바뀔 예정임.
        Debug.Log("15일째!");
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGamePlay : MonoBehaviour
{
    public int humidityP = 50;  //습도
    private int HumidityD = 50; //습도 기본값
    public int SunnyP = 0;  //태양 포인트
    public int freshP = 100; // 신선도에따라 가격변동 예정 ㅇㅇ;

    /// <summary>
    /// 별거없는건 알았는데 진짜 아무것도 없느건 좀 충격이네. 스탯밖에 없노;;
    /// </summary>

    private void Update()
    {
        IntoDay();
    }
    

    private void IntoDay()
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

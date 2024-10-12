using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedStateUi : MonoBehaviour
{
    public MainGamePlay gamePlay;
    public TextMeshProUGUI Sun;
    public TextMeshProUGUI Water;
    public TextMeshProUGUI Frash;
    void Start()
    {
        gamePlay = GameObject.Find("Seed").GetComponent<MainGamePlay>();
    }
    private void StateUi()
    {
        Sun.text = $"광합성 포인트 : {gamePlay.SunnyP}점!";
        Water.text = $"수분 포인트 :{gamePlay.humidityP}점!";
        Frash.text = $"신선도 {gamePlay.freshP}점!";
    }
    // Update is called once per frame
    void Update()
    {
        StateUi();
    }
}

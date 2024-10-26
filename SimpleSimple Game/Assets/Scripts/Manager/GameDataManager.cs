using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance; //데이터 매니저를 싱글톤 패턴으로 해서 저장하고 불러오기 할때마다 스크립트에서 Getcomponent 계속 안해도됨
    //json으로 게임 데이터 저장하고 불러오기

    private string gamedataPath;    //뭘 저장할지는 아직 안정함

    private void Start()
    {
        gamedataPath = Path.Combine(Application.persistentDataPath, "gamedataPath.json"); //gamedataPath.json 이라는 데이터를 json 방식으로 appdata에 저장함
    }


    public void SaveData<T>(T data) //제네릭으로 데이터를 저장 까먹을까봐 다시적음 T는 int 형식이든 string형식이든 T로 묶어서 데이터를 불러오고 저장하고 함 
    {
        string json = JsonUtility.ToJson(data); //data 객체를 JSON 문자열로 변환
        File.WriteAllText(gamedataPath, json);  //이게 핵심 write가 쓰기라서 json파일에 저장한다는 뜻이랑 비스무리함
        Debug.Log("데이터가 저장되었습니다 : " + gamedataPath);
    }

    public T LoadData<T>()  //데이터 로드
    {
        if (File.Exists(gamedataPath))  //솔직히 이거 무슨 원리인지 잘 모르겠슴
        {
            string json = File.ReadAllText(gamedataPath);
            return JsonUtility.FromJson<T>(json);
        }
        Debug.LogWarning("Game data file not found: " + gamedataPath);
        return default;
    }

    
}

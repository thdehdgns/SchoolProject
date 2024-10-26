using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
   public void IntoScene() //장면 전환 ㅇ
    {
        SceneManager.LoadScene(1);
    }


}

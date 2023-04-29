using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void loadStart()
    {
        SceneManager.LoadScene("1");
    }
    public void loadIntro()
    {
        SceneManager.LoadScene("I1");
    }
    public void loadSetting()
    {
        SceneManager.LoadScene("S1");
    }
    public void loadQuickStart()
    {
        SceneManager.LoadScene("QS");
    }
    public void loadRoomList()
    {
        SceneManager.LoadScene("RL");
    }
}

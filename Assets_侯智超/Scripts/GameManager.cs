using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject astronaut;
    public GameObject main;
    public GameObject course;
    public GameObject score;

    public Text nowScoreText;
    public Text bestScoreText;
    public GameObject newScore;
    public GameObject over;

    public bool ifReady = false;
    public bool ifStart = false;
    public Text scoreText;
    public void PlayBtnClick()
    {
        Tools.Ins.HideUI(main);
        Tools.Ins.ShowUI(course);
        Tools.Ins.ShowUI(score);
        ifReady = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ifReady) return;
        if (ifStart) return;
        if (Input.GetMouseButtonDown(0))
        {
            Tools.Ins.HideUI(course);
            astronaut.GetComponent<AstroFly>().ChangeState(true);
            ifStart = true;
        }
    }

    /// <summary>
    /// 游戏结束
    /// </summary>
    public void GameOver()
    {
        if (!ifStart) return;
        ifReady = false;
        ifStart = false;
        GameObject.Find("ColumnController").GetComponent<ColumnController>().StopMove();
        GameObject.Find("BackGround").GetComponent<bgController>().isMove = false;

        Tools.Ins.ShowUI(over);

        int score = int.Parse(scoreText.text);

        if (PlayerPrefs.GetInt("bestScore") < score)
        {
            PlayerPrefs.SetInt("bestScore", score);
            newScore.SetActive(true);
        }
        nowScoreText.text = score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();
    }
    /// <summary>
    /// 得分
    /// </summary>
    public void GetScore()
    {
        scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
    }
    /// <summary>
    /// 重新开始
    /// </summary>
    public void ReStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    /// <summary>
    /// 下一关
    /// </summary>
    public void ChangeScene()
    {
        SceneManager.LoadScene("Index + 1");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript instance;

    [SerializeField] Collider2D wall;
    [SerializeField] TextMeshProUGUI scoreTextinGame;
    [SerializeField] TextMeshProUGUI scoreTextinMenu;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameObject LossPanel;
    [SerializeField] ScoreScriptableObject scoreScriptableObject;

    private ScoreSaveFileScript scoreSaveFile;

    int score = 0;
    bool stop = false;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Load();
    }

    private void Save()
    {
        scoreSaveFile.killedinf = scoreScriptableObject.killedinf;
        string path = Application.persistentDataPath + "/score.json";
        string json = JsonUtility.ToJson(scoreSaveFile);
        File.WriteAllText(path, json);
    }

    private void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/score.json"))
        {
            string path = Application.persistentDataPath + "/score.json";
            string json = File.ReadAllText(path);
            scoreSaveFile = JsonUtility.FromJson<ScoreSaveFileScript>(json);
            scoreScriptableObject.killedinf = scoreSaveFile.killedinf;
        }
    }

    public void PointsUp()
    {
        score++;
        Debug.Log("Score: " + score);
        scoreTextinGame.text = score.ToString();
    }

    public bool GetStop()
    {
        return stop;
    }
    public void Lose()
    {
        Debug.Log("You Lose");
        LossPanel.SetActive(true);
        if(scoreScriptableObject.killedinf < score)
        {
            scoreScriptableObject.killedinf = score;
            highScoreText.text = scoreScriptableObject.killedinf.ToString();
            Save();
        }
        else
        {
            highScoreText.text = scoreSaveFile.killedinf.ToString();
        }
        scoreTextinMenu.text = score.ToString();
        bool stop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

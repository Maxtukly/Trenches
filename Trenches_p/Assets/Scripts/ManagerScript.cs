using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript instance;

    [SerializeField] Collider2D wall;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject LossPanel;

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
    }
    
    public void PointsUp()
    {
        score++;
        Debug.Log("Score: " + score);
        scoreText.text = score.ToString();
    }

    public bool GetStop()
    {
        return stop;
    }
    public void Lose()
    {
        Debug.Log("You Lose");
        LossPanel.SetActive(true);
        bool stop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

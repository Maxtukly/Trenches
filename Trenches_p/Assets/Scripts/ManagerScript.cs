using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript instance;

    [SerializeField] Collider2D wall;
    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;
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
    public void Lose()
    {
        Debug.Log("You Lose");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

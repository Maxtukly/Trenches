using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalButtonScript : MonoBehaviour
{
    [SerializeField] string SceneName;
    public void Transfer()
    {
        SceneManager.LoadScene(SceneName);
    }
}

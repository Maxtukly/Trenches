using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWalkingScript : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    public bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hit && !ManagerScript.instance.GetStop())
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}

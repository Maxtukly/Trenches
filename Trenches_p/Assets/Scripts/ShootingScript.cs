using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] Transform ShootPoint;
    Vector2 mousepos;
    Vector2 shootpointPos;

    private void Start()
    {
        shootpointPos = ShootPoint.transform.position;
    }
    void Shoot()
    {
        Vector2 dir = mousepos - shootpointPos;
        RaycastHit2D hit = Physics2D.Raycast(ShootPoint.transform.position, dir);
        Debug.DrawRay(ShootPoint.transform.position, dir, Color.red, 10);
        if (hit.collider != null && hit.collider.gameObject.name != "Player")
        {
            Debug.Log(hit.collider.gameObject.name);
            Destroy(hit.collider.gameObject);
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootpointPos = ShootPoint.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}

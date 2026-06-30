using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] Transform ShootPoint;
    [SerializeField] LayerMask ignorethis;
    Vector2 mousepos;
    Vector2 shootpointPos;

    private void Start()
    {
        shootpointPos = ShootPoint.transform.position;
    }
    async Task Shoot()
    {
        Vector2 dir = mousepos - shootpointPos;
        RaycastHit2D hit = Physics2D.Raycast(ShootPoint.transform.position, dir, ignorethis);
        Debug.DrawRay(ShootPoint.transform.position, dir, Color.red, 10);
        if (hit.collider != null && hit.collider.gameObject.name != "Player")
        {
            ManagerScript.instance.PointsUp();
            AIWalkingScript aIWalkingScript = hit.collider.gameObject.GetComponent<AIWalkingScript>();
            aIWalkingScript.hit = true;
            hit.rigidbody.AddForce(dir.normalized * 10, ForceMode2D.Impulse);
            await Task.Delay(2000);
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

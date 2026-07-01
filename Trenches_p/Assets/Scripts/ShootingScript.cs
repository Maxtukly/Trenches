using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] Transform ShootPoint;
    [SerializeField] LayerMask ignorethis;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] float reloadTime = 2f;
    [SerializeField] int maxAmmo = 5;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] ParticleSystem shootEffect;
    Vector2 mousepos;
    Vector2 shootpointPos;
    float shotTimer = 0f;
    public int currentAmmo;

    private void Start()
    {
        shootpointPos = ShootPoint.transform.position;
        currentAmmo = maxAmmo;
        ammoText.text = currentAmmo.ToString();
    }
    async Task Shoot()
    {
        if (shotTimer <= 0 && currentAmmo > 0)
        {
            Vector2 dir = mousepos - shootpointPos;
            RaycastHit2D hit = Physics2D.Raycast(ShootPoint.transform.position, dir, ignorethis);
            Debug.DrawRay(ShootPoint.transform.position, dir, Color.red, 10);
            currentAmmo--;
            ammoText.text = currentAmmo.ToString();
            shotTimer = timeBetweenShots;
            shootEffect.Play();
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
           
    }

    private void AddAmmo()
    {
        currentAmmo = maxAmmo;
    }

    async Task Reload()
    {
        await Task.Delay((int)(reloadTime * 1000));
        AddAmmo();
        ammoText.text = currentAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootpointPos = ShootPoint.transform.position;
        shotTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            Reload();
        }
    }
}

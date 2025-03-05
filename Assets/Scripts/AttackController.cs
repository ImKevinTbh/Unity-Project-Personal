using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using MEC;
public class AttackController : MonoBehaviour
{
    public GameObject bullet;
    private bool canShoot = true;

    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            Timing.RunCoroutine(Shoot().CancelWith(gameObject));
            
        }
    }

    public IEnumerator<float> Shoot()
    {
        canShoot = false;
        Instantiate(bullet, transform.position, transform.rotation);
        yield return Timing.WaitForSeconds(0.05f);
        Debug.Log("AAAA");
        canShoot = true;
        
    }


}

using UnityEngine;
using MEC;
using System;
public class BulletScript : MonoBehaviour
{
    public float Created;
    public float LifeTime;
    public float bSpeed = 1;
    private Vector2 target;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Bullet Instantiated");
        Created = Time.time;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<Rigidbody2D>().AddForce(((Vector2)gameObject.transform.position - target).normalized * bSpeed * -Vector2.one);
        Debug.Log($"Mouse target is: {target}");
        //GetComponent<Rigidbody2D>().AddForce(target.normalized * bSpeed * -Vector2.one);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < Created + LifeTime)
        {
            Debug.Log("Not Time");
            //gameObject.transform.rotation = Quaternion.LookRotation(Input.mousePosition);

        }
        else
        {
            Debug.Log("Destroyed");
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.eulerAngles = (collision.transform.rotation.normalized.eulerAngles - transform.rotation.normalized.eulerAngles);
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Boundary")) { return; }

        else
        {
            try
            {
                Timing.CallDelayed(0.01f, () => Destroy(gameObject));
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { return; }
        else if (collision.CompareTag("Boundary")) { return; }
        else
        {
            Timing.CallDelayed(0.01f, () => Destroy(gameObject));
        }

    }



}

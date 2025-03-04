using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Created;
    public float LifeTime;
    public float bSpeed = 1;
    private Vector2 target;
    // Start is called before the first frame update
    void Awake()
    {
        Created = Time.time;
        //target = Camera.current.ScreenToWorldPoint(Input.mousePosition);
        target = 
        //GetComponent<Rigidbody2D>().AddForce(((Vector2)gameObject.transform.position - target).normalized * bSpeed * -Vector2.one);
        GetComponent<Rigidbody2D>().AddForce(target.normalized * bSpeed * -Vector2.one);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < Created + LifeTime)
        {
            //gameObject.transform.rotation = Quaternion.LookRotation(Input.mousePosition);
            
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        Destroy(gameObject);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject effect;
    
    

    public float speed = 20.0f;
    public Rigidbody rb;


    float countdown = 3.0f;
    public float timer = 0.0f;

    float damage = 5;



    void Start()
    {
        
        
        rb = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        timer = timer + Time.deltaTime;
        if(timer>=countdown)
        {
            Destroy(gameObject);
            timer = 0.0f;
        }

        rb.velocity = transform.right * -speed * 10 ;
        
    }


    void OnTriggerEnter(Collider other)
    {
       
        IDamageAble damageAbleObject = other.GetComponentInParent<IDamageAble>();
        if(damageAbleObject != null)
        {
            if (!other.CompareTag("MyCharacter"))
            {

                damageAbleObject.TakeHit(damage, other);
                Instantiate(effect, gameObject.transform.position, gameObject.transform.rotation);
                GameObject.Destroy(gameObject);
                Debug.Log(other.name+" 물체에게 " + damage + "의 피해를 줬습니다. ");

            }

            
        }
        else
        {
            Debug.Log("idamageAble 물체가 아닙니다." + other.name);
        }
       
    }

   
}

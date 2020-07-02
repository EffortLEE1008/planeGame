using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : LivingEntity
{
    [SerializeField]    
    float damage;

    [SerializeField]
    GameObject effect;

    public float speed = 20.0f;
    public Rigidbody rb;

    float countdown = 20.0f;
    public float timer = 0.0f;

   

    

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        damage = 10;

        
        
        
      
        //rb.velocity = transform.right * speed;
        rb = this.GetComponent<Rigidbody>(); 


    }

    // Update is called once per frame
    void Update()
    {
                
        timer = timer + Time.deltaTime;
        if (timer >= countdown)
        {
            Destroy(gameObject);
            timer = 0.0f;
        }

        rb.velocity = transform.forward * speed ;

        
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageAble damageAble = other.GetComponentInParent<IDamageAble>();

        if(damageAble != null)
        {
            Debug.Log("물체가 부딛혔습니다.");
            if (other.CompareTag("MyCharacter"))
            {
                damageAble.TakeHit(damage, other);
                Instantiate(effect, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
                
            }
        }



    }

    public override void Die()
    {
        
        Instantiate(effect, gameObject.transform.position, gameObject.transform.rotation);
        base.Die();
        ScoreScript.score += 10;
        
    }



}

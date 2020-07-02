using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test : LivingEntity
{
    Vector3 rotation;

    Vector3 position;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Joystick joystick;

    [SerializeField]
    GameObject finishPenel;
    [SerializeField]
    GameObject menuPenal;
    [SerializeField]
    GameObject WinPenl;

    [SerializeField]
    Slider healthBar;

    [SerializeField]
    GameObject lazerSound;



    GameObject muzzle;

    float rotX = 3;
    float maxPosX = 120;
    float maxPosZ = 300;

    float countDown = .2f;
    float timer = 0.0f;

    float healthPercent;

    public override void Start()
    {
        base.Start();
        rotation = this.transform.eulerAngles;
        position = this.transform.position;

        muzzle = GameObject.Find("Muzzle");
    }

    // Update is called once per frame
    void Update()
    {

        healthPercent = health / startingHealth;
        healthBar.value = healthPercent;

        //우로 움직임 D 누르면 회전
        if (joystick.Horizontal >= .1)
        {
            position = position + new Vector3(0, 0, 60 * 1.5f) * Time.deltaTime;
            if (position.z >= maxPosZ)
            {
                position.z = maxPosZ;
            }
            this.transform.position = position;

            rotation = rotation + new Vector3(rotX, 0, 0);
            if (rotation.x >= 30)
            {
                rotation.x = 30;
            }
            this.transform.rotation = Quaternion.Euler(rotation);

        }

        //좌로 움직임 A누르면 회전
        if (joystick.Horizontal <= -.1)
        {
            position = position + new Vector3(0, 0, -60 * 1.5f) * Time.deltaTime;
            if (position.z <= -maxPosZ)
            {
                position.z = -maxPosZ;
            }
            this.transform.position = position;



            rotation = rotation + new Vector3(-rotX, 0, 0);
            if (rotation.x <= -30)
            {
                rotation.x = -30;
            }
            this.transform.rotation = Quaternion.Euler(rotation);
        }

        // 위로 이동
        if (joystick.Vertical >= .1)
        {
            position = position + new Vector3(-60 * 1.5f, 0, 0) * Time.deltaTime;
            if (position.x <= -maxPosX)
            {
                position.x = -maxPosX;
            }
            this.transform.position = position;
        }
        //아래로 이동
        if (joystick.Vertical <= -.1)
        {
            position = position + new Vector3(60 * 1.5f, 0, 0) * Time.deltaTime;
            if (position.x >= maxPosX - 10)
            {
                position.x = maxPosX - 10;
            }
            this.transform.position = position;
        }

        timer = timer + Time.deltaTime;
        if (timer >= countDown)
        {
            Instantiate(lazerSound, this.transform.position, this.transform.rotation);
            Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
            
            timer = 0;
        }
        if(ScoreScript.score >= 200)
        {
            Time.timeScale = 0f;
            WinPenl.SetActive(true);
            menuPenal.SetActive(false);
            ScoreScript.score = 0;

        }
       
    }


    public override void Die()
    {
        Time.timeScale = 0f;
        ScoreScript.score = 0;
        finishPenel.SetActive(true);
        menuPenal.SetActive(false);
    }



}

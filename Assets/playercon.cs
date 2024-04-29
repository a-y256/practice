using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercon : MonoBehaviour
{
    public Transform Camera;
    public float PlayerSpeed;
    public float RotationSpeed;
    Vector3 speed = Vector3.zero;
    Vector3 rot = Vector3.zero;

    public Animator PlayerAnimator;
    bool isRun;
    public Collider weaponCollider;
    bool canMove = true;
    public AudioSource audioSource; //AudioSourceを割り当てる
    public AudioClip AttackSE; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Move();
        Rotation();
        Attack();
        Camera.transform.position = transform.position;
    }
    
    void Move()
    {
         if(canMove==false)
        {
            return;
        }

        speed = Vector3.zero;
        rot = Vector3.zero;
        isRun =false;
        if (Input.GetKey(KeyCode.W))
        {
             
            rot.y =0;
            Moveset();
        } 
        if (Input.GetKey(KeyCode.S))
        {
            
            rot.y =180;
            Moveset();
        }   
        if (Input.GetKey(KeyCode.A))
        {
            
            rot.y = -90;
            Moveset();
        }  
        if (Input.GetKey(KeyCode.D))
        {
            
            rot.y = 90;
            Moveset();
        }  
        
        transform.Translate(speed); 
        PlayerAnimator.SetBool("run", isRun);
    }

    void Moveset()
    {
        speed.z = PlayerSpeed; 
        transform.eulerAngles = Camera.transform.eulerAngles +rot;
        isRun =true;
    }



    void Rotation()
    {
        var speed = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed.y = -RotationSpeed; 
        } 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.y = RotationSpeed; 
        }   


        Camera.transform.eulerAngles += speed; 
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            PlayerAnimator.SetBool("attack", true);
            canMove = false;
            audioSource.PlayOneShot(AttackSE);

        }  

    }

    void weaponON()
    {
        weaponCollider.enabled =true;

    }

    void weaponOFF()
    {
        weaponCollider.enabled =false;
        PlayerAnimator.SetBool("attack", false);
    }

    void CanMoveee()
    {
        canMove =true;
    }



}





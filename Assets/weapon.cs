using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject Effect;
    public AudioSource audioSource; //AudioSourceを割り当てる
    public AudioClip hitSE;  //敵に当たったときに鳴らす
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag=="Enemy") //もし当たったオブジェクトが敵なら
        {
            var effect =Instantiate(Effect);
            audioSource.PlayOneShot(hitSE);
            effect.transform.position = other.transform.position; //敵をオブジェクトの位置に
            Destroy(other.gameObject); //敵を破壊
            Destroy(effect,20);
        }
    }
}

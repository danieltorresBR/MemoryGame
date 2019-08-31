using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour{

    public Animator anim;
    public AudioSource song;
    public AudioSource canoles;
    public GameObject im;
    public GameObject ca;

    void Start(){
        anim = GetComponent<Animator>();
        im.SetActive(false);
        ca.SetActive(false);
    }

    void Update(){
        
        if(Input.GetKey(KeyCode.RightArrow)){
            if(!song.isPlaying){
                song.Play();
                im.SetActive(true);
                anim.SetBool("Talk", true);
                anim.SetBool("passivo_1", false);
            }
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            if(!canoles.isPlaying){
                canoles.Play();
                ca.SetActive(true);
                anim.SetBool("Talk", true);
                anim.SetBool("passivo_1", false);
            }
        }

        if(!song.isPlaying && !canoles.isPlaying){
            im.SetActive(false);
            ca.SetActive(false);
            anim.SetBool("Talk", false);
            anim.SetBool("passivo_1", true);
        }
    }

}

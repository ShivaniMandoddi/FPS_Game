using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    AudioSource audioSource;

    
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))                                 // Hiding the gun
            animator.SetBool("IsHide",!animator.GetBool("IsHide"));
        if (Input.GetMouseButtonDown(0))                              // Firing or Shooting
        {
            audioSource.Play();
            animator.SetTrigger("IsShoot");
            RaycastHit hit;
            Transform bulletpoint = GetComponentInChildren<Transform>();
            if (Physics.Raycast(bulletpoint.position, bulletpoint.forward, out hit, 100f))
            {
                GameObject enemyhit = hit.collider.gameObject;
                if (enemyhit.tag == "Enemy")
                {
                    enemyhit.GetComponent<EnemyController>().state = EnemyController.STATE.DEAD;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))             //Reloading 
            animator.SetTrigger("IsReload");


    }
    

}

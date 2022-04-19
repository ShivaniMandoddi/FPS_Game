using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    AudioSource audioSource;
    public GameObject enemyRagDoll;
    GameObject temp;
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
                
                if (enemyhit.tag == "Enemy" )           //Bullet hitting to enemy
                {
                    if(Random.Range(0, 5) < 2)
                    {
                        enemyhit.GetComponent<EnemyController>().state = EnemyController.STATE.DEAD;
                    }
                    else
                    {
                        temp = Instantiate(enemyRagDoll, enemyhit.transform.position, enemyhit.transform.rotation);
                        temp.transform.Find("Hips").GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 1000f);
                        Destroy(enemyhit);
                        
                    }
                }
                    
                
              
            }
        }
        if (Input.GetKeyDown(KeyCode.R))             //Reloading 
            animator.SetTrigger("IsReload");


    }
   

}

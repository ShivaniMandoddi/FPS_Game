using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))
            animator.SetBool("IsHide",!animator.GetBool("IsHide"));
        if (Input.GetMouseButtonDown(0))
            animator.SetTrigger("IsShoot");
        if (Input.GetKeyDown(KeyCode.R))
            animator.SetTrigger("IsReload");


    }
    public void TriggerAllFalse()
    {
        animator.SetBool("IsHide", false);
        animator.SetBool("IsReload", false);
    }
   
    public void Hide()
    {
          TriggerAllFalse();
        animator.SetBool("IsHide", true);

    }
    public void Shoot()
    {
        TriggerAllFalse();
        animator.SetTrigger("IsShoot");
    }

}

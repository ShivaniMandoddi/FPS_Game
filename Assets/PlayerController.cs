using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Start is called before the first frame update
    public float playerSpeed;
    public float camRotation;
    public Camera cam;
    GunController gunController;
    public Transform bulletpoint;
    public EnemyController enemyController;
    void Start()
    {
        gunController=GetComponentInChildren<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal")*playerSpeed*Time.deltaTime;          // PLayer Moving left and right
        float inputZ = Input.GetAxis("Vertical")*playerSpeed*Time.deltaTime;           // PLayer moving forward and backward
        this.transform.Translate(new Vector3(inputX, 0f, inputZ));
       
        
        // Player Rotation
        if(Input.GetKey(KeyCode.N))
        {
            this.transform.Rotate(0f, -1f, 0f);
        }
        if (Input.GetKey(KeyCode.M))
        {
            this.transform.Rotate(0f,1f, 0f);
        }
        // Cam Rotation
        float caminputx = Input.GetAxis("Mouse Y")*camRotation;
        cam.transform.Rotate(-caminputx, 0f, 0f);
        
    }
}

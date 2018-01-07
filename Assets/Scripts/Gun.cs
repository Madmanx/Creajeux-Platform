using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;              // Prefab of the rocket.
    public float speed = 20f;               // The speed the rocket will fire at.


    private PlayerControl playerCtrl;       // Reference to the PlayerControl script.
    private Animator anim;                  // Reference to the Animator component.


    void Awake()
    {
        // Setting up the references.
        anim = transform.root.gameObject.GetComponent<Animator>();
        playerCtrl = transform.root.GetComponent<PlayerControl>();
    }

    private void Start()
    {

    }


    void Update()
    {
        if (!playerCtrl.isLocalPlayer)
            return;
        // If the fire button is pressed...
        if (Input.GetButtonDown("Fire1"))
        {
            playerCtrl.CmdDoFire();
        }
    }

    public void ShootFX()
    {
        // ... set the animator Shoot trigger parameter and play the audioclip.
        anim.SetTrigger("Shoot");
        GetComponent<AudioSource>().Play();
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    public float radius = 10.0f;

    public AudioClip choppingSound;
    public AudioSource source;

    private Inventory inventory;
    private GameObject player;
    private GameObject campFire;
    public GameObject gameManager;
    public float choppingTime = 4;
    private Animator anim;
    private Rigidbody rb;

    private void Awake()
    {
        // get the componments
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        campFire = GameObject.FindGameObjectWithTag("Campfire");
        inventory = player.GetComponent<Inventory>();
        source.clip = choppingSound;
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp("e"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, radius);

            foreach (Collider col in hitColliders)
            {
                // if the player is near a tree, start chopping
                if (col.gameObject.tag == "Tree")
                {
                    // animate the player chopping
                    anim.SetBool("Chop", true);
                    StartCoroutine(Chopping(choppingTime));



                    source.Play();
                    col.gameObject.GetComponent<Tree2>().ChopMe();
                }
            }

        }
    }

    IEnumerator Chopping(float time)
    {
        yield return new WaitForSeconds(time);

        // stop the chopping animation
        anim.SetBool("Chop", false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    public float radius = 10.0f;

    public AudioClip choppingSound;
    public AudioSource source;

    public GameObject axeInHand;
    public GameObject axeOnBack;

    private Inventory inventory;
    private GameObject player;
    private GameObject campFire;
    public GameObject gameManager;
    public float choppingTime = 4;
    public int attackdamage = 2;


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
                if (col.gameObject.tag == "Tree" && axeOnBack.activeSelf)
                {
                    // force the player to face towards the tree

                    // try to diable the player from moving during the chopping animation

                    // put axe in hand
                    SwapAxe();

                    // animate the player chopping
                    anim.SetBool("Chop", true);
                    StartCoroutine(Chopping(choppingTime));



                    source.Play();
                    col.gameObject.GetComponent<Tree>().ChopMe();
                    break;
                }

                // if the player is near the axe, grab it
                // disable the axe in the stump or destroy it
                // enable the axe on the player's back
                if (col.gameObject.tag == "Axe")
                {
                    

                    // pick up animation
                    anim.SetBool("PickUp", true);

                    StartCoroutine(PickupAxe(1.0f, col.gameObject));
                    

                    break;
                }

                if (col.gameObject.tag == "Enemy")
                {
                    // take out axe
                    SwapAxe();

                    // run the attack animation
                    anim.SetTrigger("Attack");

                    // damage enemy
                    Enemy EnemyScript = col.gameObject.GetComponent<Enemy>();
                    EnemyScript.TakeDamage(attackdamage);


                    break;
                }
            }
        }
    }

    IEnumerator Chopping(float time)
    {
        yield return new WaitForSeconds(time);

        // stop the chopping animation
        anim.SetBool("Chop", false);
        SwapAxe();
    }

    IEnumerator PickupAxe(float time, GameObject gameObject)
    {
        yield return new WaitForSeconds(time);

        if (gameObject.tag == "Axe")
        {
            // activate the axe on back
            // can put in a delay later
            axeOnBack.SetActive(true);

            // destroy axe in stump
            Destroy(gameObject);

            anim.SetBool("PickUp", false);
        }
        
    }

    void SwapAxe()
    {
        // put axe in hand
        if (axeOnBack.activeSelf)
        {
            axeOnBack.SetActive(false);
            axeInHand.SetActive(true);
        } else
        {
            axeOnBack.SetActive(true);
            axeInHand.SetActive(false);
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tree : MonoBehaviour//, IPointerClickHandler
{
    public int noOfChopsForWood = 3;
    public int noOfWoodBeforeFell = 4;
    public int speed = 8;
    public int destroyTreeDelay = 5;
    public GameObject fireWood;

    private int chops;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        chops = noOfChopsForWood;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (noOfChopsForWood == 0)
            resetChops();

    }

    void FixedUpdate()
    {
        if (noOfWoodBeforeFell <= 0) {
            rb.isKinematic = false;
            rb.AddForce(transform.forward * speed);
            StartCoroutine(DestroyTree(destroyTreeDelay));

        }
    }

    public void ChopMe()
    {
        noOfChopsForWood--;
        if (noOfChopsForWood < 0)
            noOfChopsForWood = 0;
    }

    void resetChops()
    {
        noOfChopsForWood = chops;   //remove this hardcoded value
        // get the position of the respawn spot
        GameObject respawn = getChildGameObject(this.gameObject, "LogSpawn");
        // create a firewood
         Instantiate(fireWood, respawn.transform.position, Quaternion.identity);
        // fly it out of the tree
        
   

        noOfWoodBeforeFell--;
        if (noOfWoodBeforeFell <= 0) 
            noOfWoodBeforeFell = 0;
        
    }

    private GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }

    IEnumerator DestroyTree(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}

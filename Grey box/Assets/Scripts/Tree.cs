using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tree : MonoBehaviour//, IPointerClickHandler
{
    public int noOfChopsForWood = 3;
    public int noOfWoodBeforeFell = 4;
    public GameObject fireWood;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (noOfChopsForWood == 0)
            resetChops();

    }

    public void ChopMe()
    {
        noOfChopsForWood--;
        if (noOfChopsForWood < 0)
            noOfChopsForWood = 0;
    }

    void resetChops()
    {
        noOfChopsForWood = 3;   //remove this hardcoded value
        // get the position of the respawn spot
        GameObject respawn = getChildGameObject(this.gameObject, "LogSpawn");
        // create a firewood
         Instantiate(fireWood, respawn.transform.position, Quaternion.identity);
        // fly it out of the tree
        
   

        noOfWoodBeforeFell--;
        if (noOfWoodBeforeFell <= 0) {
            //make the tree fall
        }
    }

    private GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }

    //public void OnPointerClick(PointerEventData pointerEventData)
    //{
    //    noOfChopsForWood--;
    //}
}

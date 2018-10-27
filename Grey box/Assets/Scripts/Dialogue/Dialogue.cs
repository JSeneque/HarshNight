using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue  {

    // the sentences we will load into the queue
    //public string name;

    [TextArea(3,10)]
    public string[] sentences;

}

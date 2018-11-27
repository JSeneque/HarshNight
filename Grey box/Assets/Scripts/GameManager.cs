using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float radius = 10.0f;

    public AudioClip choppingSound;
    public AudioSource source;

    public GameObject meatCookedButton;
    //public Image background;
    //public TextMesh gameOverText;
    private GameObject campFire;
    private Inventory inventory;
    private GameObject player;


    // please replace with a image only
    public Image gameOverImage;
    public Text gameOverText;

    // Are we in tutorial mode
    bool isTutorialMode = false;

    public float restartDelay = 1f;

    public static GameManager instance = null;

    public enum GameState
    {

        InProgress,
        GameOver
    }

    GameState gameState;

    //Awake is always called before any Start functions
    void Awake()
    {
        // set game in idle state
        gameState = GameState.InProgress;

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        campFire = GameObject.FindGameObjectWithTag("Campfire");
        inventory = player.GetComponent<Inventory>();

        isTutorialMode = true;

        // start the player instructions
        StartCoroutine(StartTutorialInstructions(3.0f));


    }

    public void CookMeat(int slot)
    {
        //Debug.Log("Cooked the meat in slot ");

        GameObject child = inventory.slots[slot].gameObject.transform.GetChild(0).gameObject;
        Destroy(child);

        Instantiate(meatCookedButton, inventory.slots[slot].transform, false);
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        //gameOverImage.enabled = true;
        //gameOverText.enabled = true;

        Debug.Log("GameManager.GameOver() called");
        Restart();
    }

    void Restart()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator StartTutorialInstructions(float time)
    {
        yield return new WaitForSeconds(time);
        //Debug.Log("Start Player Instructions");
        GetComponent<DialogueTrigger>().TriggerDialogue();

    }

    // returns the value of tutorial mode
    public bool IsTutorialMode()
    {
        return isTutorialMode;
    }

    public void SetTutorialMode(bool mode)
    {
        isTutorialMode = mode;
    }
}

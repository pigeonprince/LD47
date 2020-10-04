using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IterationManager : MonoBehaviour
{
    int iteration = 0;
    public GameObject player;
    public Transform spawnPoint;
    public GameObject whiteRuby;
    public GameObject trinket;
    public GameObject redRubyWall;
    public GameObject hazardTiles;
    public GameObject WaterTiles;
    public GameObject hiddenRoomDetector;
    public GameObject projectileShooter;

    public GameObject lava;
    public GameObject safeLava;

    public GameObject passmemo;
    public GameObject slingshot;
    public GameObject pathFinder;
    public GameObject CrystalSkull;
    public GameObject stairs;

    public GameObject whiteRubyScreen;
    public GameObject redRubyScreen;
    public GameObject orangeRubyScreen;
    public GameObject yellowRubyScreen;
    public GameObject greenRubyScreen;
    public GameObject blueRubyScreen;
    public GameObject indigoRubyScreen;
    public GameObject purpleRubyScreen;
    public GameObject blackRubyScreen;
    public GameObject restartScreen;
    public GameObject crystalSkullScreen;
    public GameObject endingScreen;


    Health health;

    Inventory inventory;

    void Start()
    {
        health = FindObjectOfType<Health>();
        inventory = FindObjectOfType<Inventory>();
        if (iteration == 0)
        {
            StartForTheFirstTime();
            player.transform.position = spawnPoint.position;
        }
    }

    private void StartForTheFirstTime()
    {
        inventory.GetItemWithoutMessage(whiteRuby);
        iteration++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstRespawn()
    {
        redRubyWall.SetActive(false);
        whiteRubyScreen.SetActive(true);
        player.transform.position = spawnPoint.position;
        iteration++;
    }

    public void RemoveSpikes()
    {
        redRubyScreen.SetActive(true);
        hazardTiles.SetActive(false);
        player.transform.position = spawnPoint.position;
        iteration++;
    }

    public void SetBridge()
    {
        orangeRubyScreen.SetActive(true);
        lava.SetActive(false);
        safeLava.SetActive(true);
        player.transform.position = spawnPoint.position;
        iteration++;
    }
    public void RewardTrinket()
    {
        yellowRubyScreen.SetActive(true);
        inventory.GetItemWithoutMessage(trinket);
        player.transform.position = spawnPoint.position;
        iteration++;
    }

    public void ActivateProjectileShooting()
    {
        greenRubyScreen.SetActive(true);
        FindObjectOfType<PlayerController>().canLaunch = true;
        player.transform.position = spawnPoint.position;
        inventory.GetItemWithoutMessage(slingshot);
        iteration++;
    }

    public void RemoveWater()
    {
        blueRubyScreen.SetActive(true);
        WaterTiles.SetActive(false);
        player.transform.position = spawnPoint.position;
        iteration++;
    }

    public void PassMemo()
    {
        indigoRubyScreen.SetActive(true);
        inventory.GetItemWithoutMessage(passmemo);
        player.transform.position = spawnPoint.position;
        iteration++;
    }

    public void HiddenRoomDetector()
    {
        purpleRubyScreen.SetActive(true);
        inventory.GetItemWithoutMessage(pathFinder);
        hiddenRoomDetector.GetComponent<HiddenRoomDetector>().hiddenRoomDetector = true;
        player.transform.position = spawnPoint.position;
        iteration++;
    }

    public void GiveCrystalSkull()
    {
        blackRubyScreen.SetActive(true);
        inventory.GetItemWithoutMessage(CrystalSkull);
        player.transform.position = spawnPoint.position;
        iteration++;
    }

    public void OpenStairs()
    {
        crystalSkullScreen.SetActive(true);
        stairs.SetActive(true);
    }
    
    public void StartOver()
    {
        StartCoroutine(LoadGameAgain());
    }

    IEnumerator LoadGameAgain()
    {
        endingScreen.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Restart()
    {
        restartScreen.SetActive(true);
        player.transform.position = spawnPoint.position;
        health.health = 3;
    }


}

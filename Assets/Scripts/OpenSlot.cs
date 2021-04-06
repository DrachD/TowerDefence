using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSlot : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject tower;
    private GameManagerBehaviour gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
    }

    private void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            tower = (GameObject) Instantiate(towerPrefab, transform.position, Quaternion.identity);
            gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
        }
        else if (CanUpgradeTower())
        {
            tower.GetComponent<TowerData>().IncreaseLevel();
            gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
            //AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            //audioSource.PlayOneShot(audioSource.clip);
        }
    }
    private bool CanPlaceTower()
    {
        int cost = towerPrefab.GetComponent<TowerData>().levels[0].cost;
        return tower == null && gameManager.Gold >= cost;
    }
    private bool CanUpgradeTower()
    {
        if (tower != null)
        {
            TowerData towerData = tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.GetNextLevel();

            if (nextLevel != null)
            {
                return gameManager.Gold >= nextLevel.cost;
            }
        }
        return false;
    }
}

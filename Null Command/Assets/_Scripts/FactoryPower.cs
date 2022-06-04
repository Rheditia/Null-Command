using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPower : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] GameObject powerGFX;
    [SerializeField] float finishDelay = 1f;
    Switch[] levers;
    List<bool> leverState = new List<bool>();

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        levers = GetComponentsInChildren<Switch>();
    }

    private void Update()
    {
        leverState.Clear();
        foreach(Switch lever in levers)
        {
            leverState.Add(lever.IsActive);
        }
        if(!leverState.Find(state => state == true))
        {
            powerGFX.SetActive(false);
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(finishDelay);
        levelManager.ChangeLevel();
    }
}

﻿using UnityEngine;
using System.Collections;

public class SeasonManager : MonoBehaviour {

    public enum Season { spring, summer, fall, winter };
    public Season currentSeason { get; private set; }

    public GameObject[] seasonObject; //0 = spring, 1 = summer, 2 = fall, 3 = winter;

    void Start()
    {
        //Get the season objects
        seasonObject = new GameObject[4];
        if(GameObject.Find("Spring"))
            seasonObject[0] = GameObject.Find("Spring");
        if (GameObject.Find("Summer"))
            seasonObject[1] = GameObject.Find("Summer");
        if (GameObject.Find("Fall"))
            seasonObject[2] = GameObject.Find("Fall");
        if (GameObject.Find("Winter"))
            seasonObject[3] = GameObject.Find("Winter");

        currentSeason = Season.summer;
        SetSeason();
    }

    //Starts the change effect coroutine. This function is also called from other scripts
    public void SeasonChange()
    {
        StartCoroutine(ChangeEffect());
    }

    IEnumerator ChangeEffect()
    {
        //Vector3 instantiatePosition = new Vector3(originObject.position.x, originObject.position.y, 1);
        //GameObject changeEffect = Instantiate(changeSeasonEffect, instantiatePosition, transform.rotation) as GameObject;
        yield return new WaitForSeconds(0.5f);
        if (currentSeason == Season.summer)
        {
            currentSeason = Season.winter;
        }
        else
        {
            currentSeason = Season.summer;
        }
        SetSeason();
        yield return new WaitForSeconds(0.2f);
        //Destroy(changeEffect);
    }


    //Set the current season
    public void SetSeason()
    {
        foreach(GameObject season in seasonObject)
        {
            if(season != null)
                season.SetActive(false);
        }
        seasonObject[(int)currentSeason].SetActive(true);
    }

    //Sets the season object variable. The objects are defined in the game manager
    public void SetGameObjects(GameObject[] objects)
    {
        seasonObject = new GameObject[objects.Length];
        for(int i=0; i<objects.Length; i++)
        {
            seasonObject[i] = objects[i];
        }
    }
}

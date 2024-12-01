using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public LevelManager LevelManager { get; private set; }
    public GameObject Player { get; private set; }



    void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Canvas>() != null || child.GetComponent<UnityEngine.UI.Image>() != null)
            {   
                // child.transform.GetChild(0).gameObject.SetActive(false);
                child.gameObject.SetActive(false);
            }
        }

        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        LevelManager = GetComponentInChildren<LevelManager>();

        DontDestroyOnLoad(gameObject);
        var camera = GameObject.Find("Camera");
        if (camera != null)
        {
            DontDestroyOnLoad(camera);
        }

        Player = GameObject.FindWithTag("Player");
        if (Player != null)
        {
            DontDestroyOnLoad(Player);
        }
    }


}
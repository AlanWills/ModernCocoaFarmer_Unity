using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameObjectScript : MonoBehaviour
{
    public string GameObjectName;
    private GameObject gameObjectToShow;

    void Start()
    {
        gameObjectToShow = GameObject.Find(GameObjectName);
        gameObjectToShow.SetActive(false);
    }

	public void Show()
    {
        TimeManager.Paused = true;
        gameObjectToShow.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EventDialogScript : MonoBehaviour
{
    public const string EventDialog = "EventDialog";
    
    private Text description;
    private EventScript RandomEvent { get; set; }

    public void Start()
    {
        Hide();
    }

    public void Awake()
    {
        description = GameObject.Find("Description").GetComponent<Text>();
    }

    public void Show(EventScript eventScript)
    {
        RandomEvent = eventScript;

        description.text = RandomEvent.Description;
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Yes()
    {
        RandomEvent.Yes();
        Hide();
    }

    public void No()
    {
        RandomEvent.No();
        Hide();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationDialogScript : MonoBehaviour
{
    public const string NotificationDialogName = "NotificationDialog";
    
    private Vector3 resetPosition;
    private float width;
    private const float ShownTime = 6;
    private float timeShownFor;
    private Direction direction = Direction.kStopped;

    private Queue<NotificationScript> notifications = new Queue<NotificationScript>();
    private NotificationScript currentNotification;

    private Text title;
    private Text description;
    
    enum Direction
    {
        kIn,
        kOut,
        kStopped
    }

	// Use this for initialization
	void Start ()
    {
        resetPosition = transform.localPosition;
        width = gameObject.GetComponent<RectTransform>().rect.width;
        title = GameObject.Find("NotificationTitle").GetComponent<Text>();
        description = GameObject.Find("NotificationDescription").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShowEvent();
        Lerp();

        if (direction == Direction.kStopped)
        {
            timeShownFor += Time.deltaTime;
        }

        if (timeShownFor > ShownTime)
        {
            direction = Direction.kOut;
        }
    }

    private void ShowEvent()
    {
        if (currentNotification == null && notifications.Count > 0)
        {
            currentNotification = notifications.Dequeue();
            title.text = currentNotification.Title;
            description.text = currentNotification.Description;
            currentNotification.OnShow();
            direction = Direction.kIn;
            timeShownFor = 0;
        }
    }

    private void Lerp()
    {
        if (direction == Direction.kIn)
        {
            transform.localPosition += new Vector3(width * Time.deltaTime, 0, 0);

            if (transform.localPosition.x >= resetPosition.x + width)
            {
                direction = Direction.kStopped;
            }
        }
        else if (direction == Direction.kOut)
        {
            transform.localPosition -= new Vector3(width * Time.deltaTime, 0, 0);

            if (transform.localPosition.x <= resetPosition.x)
            {
                direction = Direction.kStopped;
                transform.localPosition = resetPosition;
                currentNotification = null;
            }
        }
    }

    public void QueueNotification(NotificationScript notification)
    {
        notifications.Enqueue(notification);
    }
}

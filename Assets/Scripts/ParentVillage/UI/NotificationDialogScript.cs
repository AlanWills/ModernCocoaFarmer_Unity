using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationDialogScript : MonoBehaviour
{
    public const string NotificationDialogName = "NotificationDialog";
    
    private Vector3 resetPosition;
    private float width;
    private const float ShownTime = 4;
    private float timeShownFor;
    private Direction direction = Direction.kStopped;

    private Queue<NotificationScript> notifications = new Queue<NotificationScript>();
    private NotificationScript currentNotification;

    private Text title;
    private Text description;
    private AudioSource audioSource;
    
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

        Transform notificationUI = transform.FindChild("NotificationDialogUI");
        title = notificationUI.FindChild("NotificationTitle").GetComponent<Text>();
        description = notificationUI.FindChild("NotificationDescription").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
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
            currentNotification.Show();
            direction = Direction.kIn;
            timeShownFor = 0;

            if (currentNotification.OnShowAudioClip != null)
            {
                audioSource.clip = currentNotification.OnShowAudioClip;
                audioSource.Play();
            }
        }
    }

    private void Lerp()
    {
        float distanceToCover = 1.1f * width;
        if (direction == Direction.kIn)
        {
            transform.localPosition += new Vector3(distanceToCover * Time.deltaTime, 0, 0);

            if (transform.localPosition.x >= resetPosition.x + distanceToCover)
            {
                direction = Direction.kStopped;
            }
        }
        else if (direction == Direction.kOut)
        {
            transform.localPosition -= new Vector3(distanceToCover * Time.deltaTime, 0, 0);

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

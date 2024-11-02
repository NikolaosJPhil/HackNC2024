using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InstantButtonHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    UnityEvent<PointerEventData> onPress;
    public void OnPointerDown(PointerEventData eventData)
    {
        //Call the event with the click event data
        onPress.Invoke(eventData);
    }
}
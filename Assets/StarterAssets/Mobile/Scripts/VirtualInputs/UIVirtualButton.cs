using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIVirtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    [System.Serializable]
    public class Event : UnityEvent { }

    [Header("Output")]
    public BoolEvent ImageButtontateOutputEvent;
    public Event buttonClickOutputEvent;

    public void OnPointerDown(PointerEventData eventData)
    {
        OutputImageButtontateValue(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OutputImageButtontateValue(false);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OutputButtonClickEvent();
    }

    void OutputImageButtontateValue(bool ImageButtontate)
    {
        ImageButtontateOutputEvent.Invoke(ImageButtontate);
    }

    void OutputButtonClickEvent()
    {
        buttonClickOutputEvent.Invoke();
    }

}

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ClickHandler : MonoBehaviour
{
    public UnityEvent upEvent;
    public UnityEvent downEvent;
    public UnityEvent speakEvent;

  /*  public void Start()
    {
        speakEvent?.Invoke();
    }*/
    public void Update()
    {
        speakEvent?.Invoke();

    }
    void OnMouseDown()
    {
        Debug.Log("Down");
        downEvent?.Invoke();
    }

    void OnMouseUp()
    {
        Debug.Log("Up");
        upEvent?.Invoke();
    }
}

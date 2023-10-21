using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource audioData;
    public bool WantPause = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioData.Play();
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (WantPause)
        {
            audioData.Stop();
        }
    }
}

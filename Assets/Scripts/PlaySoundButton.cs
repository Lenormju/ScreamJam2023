using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlaySoundButton : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource audioData;

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioData.Play(0);
    }
}

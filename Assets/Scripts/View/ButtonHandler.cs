using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.View
{
    public class ButtonHandler : MonoBehaviour, IPointerClickHandler
    {
        public event Action Clicked;

        public void OnPointerClick(PointerEventData eventData) => 
            Clicked?.Invoke();
    }
}
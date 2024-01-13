using TMPro;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class ErrorWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _message;
        [SerializeField] private ButtonHandler _dismissButton;

        private void OnEnable() => 
            _dismissButton.Clicked += OnDismissClick;

        private void OnDisable() => 
            _dismissButton.Clicked -= OnDismissClick;

        public void DisplayMessage(string message) =>
            _message.text = message;

        private void OnDismissClick() => 
            gameObject.SetActive(false);
    }
}
using Assets.Scripts.Controller;
using Assets.Scripts.Model;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class AuthWindow : MonoBehaviour
    {
        private AuthService _authService;

        [SerializeField] private TMP_InputField _loginInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        [SerializeField] private ButtonHandler _submitButton;

        [SerializeField] private ErrorWindow _errorWindow;

        private void Start()
        {
            _authService = new AuthService();
            _submitButton.Clicked += OnSubmitClick;
            _errorWindow.gameObject.SetActive(false);
        }

        private void OnDestroy() =>
            _submitButton.Clicked -= OnSubmitClick;

        private async UniTaskVoid AuthSubmit()
        {
            var response = await _authService.Process(_loginInputField.text, _passwordInputField.text);

            switch (response.Key)
            {
                case Tags.Success:
                    Debug.LogError(response.Value);
                    break;
                case Tags.Error:
                    DisplayError(response.Value);
                    break;
            }
        }

        private void OnSubmitClick() => 
            AuthSubmit().Forget();

        private void DisplayError(string message)
        {
            _errorWindow.gameObject.SetActive(true);
            _errorWindow.DisplayMessage(message);
        }
    }
}
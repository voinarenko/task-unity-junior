using Assets.Scripts.Model;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Controller
{
    public class AuthService : IAuthService
    {
        private const string AuthUrl = "https://stage.arenagames.api.ldtc.space/api/v3/gamedev/client/auth/sign-in";
        private const string ContentType = "application/json";

        private readonly AuthData _authData = new();

        public async UniTask<KeyValuePair<string, string>> Process(string login, string password)
        {
            using var request = UnityWebRequest.Post(AuthUrl, CreateJson(login, password), ContentType);
            try
            {
                await request.SendWebRequest();
            }
            catch
            {
                // ignored
            }

            return ProcessResponse(request);
        }

        private static KeyValuePair<string, string> ProcessResponse(UnityWebRequest request)
        {
            KeyValuePair<string, string> result;

            if (request.result != UnityWebRequest.Result.Success)
            {
                var data = JsonUtility.FromJson<ResponseErrorData>(request.downloadHandler.text);
                result = new KeyValuePair<string, string>(Tags.Error, data.message);
            }
            else
            {
                var data = JsonUtility.FromJson<ResponseSuccessData>(request.downloadHandler.text);
                result = new KeyValuePair<string, string>(Tags.Success, data.accessToken.token);
            }

            return result;
        }

        private string CreateJson(string login, string password)
        {
            _authData.password = password;
            _authData.login = login;
            return JsonUtility.ToJson(_authData);
        }
    }
}
using System;
using Assets.Scripts.Model.Tokens;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class ResponseSuccessData
    {
        public AccessToken accessToken;
        public RefreshToken refreshToken;
    }
}
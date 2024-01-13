using System;

namespace Assets.Scripts.Model.Tokens
{
    [Serializable]
    public class AccessToken
    {
        public string token;
        public int expiresIn;
    }
}
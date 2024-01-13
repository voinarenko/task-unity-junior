using System;

namespace Assets.Scripts.Model.Tokens
{
    [Serializable]
    public class RefreshToken
    {
        public string token;
        public int expiresIn;
    }
}
using System;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class ResponseErrorData
    {
        public string type;
        public string code;
        public string message;
    }
}
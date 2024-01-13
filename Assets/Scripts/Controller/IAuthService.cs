using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Controller
{
    public interface IAuthService
    {
        UniTask<KeyValuePair<string, string>> Process(string login, string password);
    }
}
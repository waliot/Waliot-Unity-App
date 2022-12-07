using System;

namespace Assets.Scripts.Helpers
{
    public static class JsonUtil
    {
        [Serializable]
        public class Wrapper<T>
        {
            public T[] Items;
        }
    }
}
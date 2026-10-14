using System;
using UnityEngine;

namespace Environment.Tasks {
    [Serializable]
    public abstract class Task : ScriptableObject {
        public abstract void Execute();
    }
}

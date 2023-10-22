using System.Collections.Generic;
using System.ComponentModel;
using Cysharp.Threading.Tasks;

namespace CodeBase.Common.Pools
{
    public abstract class Pool<TObject>
    {
        private readonly List<TObject> _activeObjects = new();
        protected readonly Queue<TObject> _disableObjects = new();
        
        public async UniTask<TObject> Take()
        {
            if (_disableObjects.Count == 0)
                await AddToPool();
            
            TObject currentObject = _disableObjects.Dequeue();
            
            _activeObjects.Add(currentObject);
            PrepareToTakeObject(currentObject);
            return currentObject;
        }

        protected void ReturnToPool(TObject activeObject)
        {
            PrepareToDisableObject(activeObject);

            _activeObjects.Remove(activeObject);
            _disableObjects.Enqueue(activeObject);
        }

        protected abstract UniTask AddToPool();
        protected abstract void PrepareToTakeObject(TObject disableObject);
        protected abstract void PrepareToDisableObject(TObject activeObject);
    }
}
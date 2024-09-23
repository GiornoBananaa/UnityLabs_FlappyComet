using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using Core;

namespace GenerationSystem
{
    public interface IObjectGenerator
    {
        void EnableGeneration();
        void DisableGeneration();
    }

    public class GameObjectGenerator<T> : IObjectGenerator where T : MonoBehaviour
    {
        private readonly Vector2 SPAWN_OFFSET = new (10, 0);
        private readonly ObjectPool<T> _objectPool;
        private readonly IFactory<T> _factory;
        private readonly Transform _spawnPosition;
        private readonly float _spawnTimeGap;
        private readonly float _spawnTimeGapSpread;
        private readonly float _lifeTime;
        private UniTask _generationTask;

        public GameObjectGenerator(IFactory<T> factory, LevelGenerationDataSO levelGenerationData)
        {
            _factory = factory;
            ObjectGenerationData objectGenerationData = levelGenerationData.ObjectGenerationDataByType[typeof(T)];
            _spawnTimeGap = objectGenerationData.SpawnTimeGap;
            _spawnTimeGapSpread = objectGenerationData.SpawnTimeGapSpread;
            _lifeTime = objectGenerationData.LifeTime;
            _spawnPosition = Camera.main.transform;
            
            _objectPool = new ObjectPool<T>(CreateObject);
        }
        
        public void EnableGeneration()
        {
            _generationTask = LoopGeneration();
        }

        public void DisableGeneration() 
        {
            if (_generationTask.Status == UniTaskStatus.Pending)
                _generationTask.Forget();
        }

        private async UniTask LoopGeneration()
        {
            while (true)
            {
                Generate();
                int timeGap = (int)(_spawnTimeGap-Random.Range(-_spawnTimeGapSpread,_spawnTimeGapSpread)) * 1000; 
                await UniTask.Delay(timeGap);
            }
        }
        
        private void Generate()
        {
            T obj = _objectPool.Get();
            if(obj==null || obj.transform == null || _spawnPosition == null)
            { 
                _objectPool.Clear();
                return;
            }
            obj.transform.position = (Vector2)_spawnPosition.position + SPAWN_OFFSET;
            obj.gameObject.SetActive(true);
            ReleaseObject(obj);
        }
        
        private async UniTask ReleaseObject(T obj)
        {
            await UniTask.Delay((int)(_lifeTime * 1000));
            if (obj == null)
                return;
            obj.gameObject.SetActive(false);
            _objectPool.Release(obj);
        }

        private T CreateObject()
        {
            T obj = _factory.Create();
            obj.gameObject.SetActive(false);
            return obj;
        }
    }
}
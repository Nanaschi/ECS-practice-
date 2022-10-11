using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SheepECS._Scripts.ECS
{
    public class ECSManager : MonoBehaviour
    {
        private EntityManager _entityManager;
        [SerializeField] private GameObject _sheepPrefab;
        [SerializeField] private int _numSheep;
        [SerializeField] private float _sheepSpeed;
    
        // Start is called before the first frame update
        void Awake()
        {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            var settings = GameObjectConversionSettings.FromWorld
                (World.DefaultGameObjectInjectionWorld, null);
            var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy
                (_sheepPrefab, settings);

            for (int i = 0; i < _numSheep; i++)
            {
                var instance = _entityManager.Instantiate(prefab);
            
                var spawnPosition = 
                    transform.TransformPoint
                        (new float3(Random.Range(-50,50),Random.Range(0,100), Random.Range(-50,50)));
            
                _entityManager.SetComponentData
                    (instance, new Translation { Value = spawnPosition });
            
            
            }
        }
    }
}
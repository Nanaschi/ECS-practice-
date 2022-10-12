using System;
using TMPro;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace TankSheep._Scripts
{
    public class ECSInterface : MonoBehaviour
    {
        private World _defaultGameObjectInjectionWorld;

        [SerializeField]
        private Button _sheepButton;

        [SerializeField]
        private TextMeshProUGUI _sheepCounter;

        private EntityQuery _entityQuery;
        
        [SerializeField]
        private GameObject _sheepPrefab;

        private EntityManager _entityManager;


        private void Awake()
        {
            _defaultGameObjectInjectionWorld = World.DefaultGameObjectInjectionWorld;
            var settings =
                GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
            var prefab =
                GameObjectConversionUtility.ConvertGameObjectHierarchy(_sheepPrefab, settings);

            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;


            for (int i = 0; i < 8; i++)
            {
                var instance = _entityManager.Instantiate(prefab);

                var spawnPosition = transform.TransformPoint
                (new float3
                    (i*2, 0,0));

                _entityManager.SetComponentData
                    (instance, new Translation {Value = spawnPosition});
            }
        }


        private void OnEnable()
        {
            _sheepButton.onClick.AddListener(ShowSpecificCounter<SheepData>);
        }

        private void OnDisable()
        {
            _sheepButton.onClick.RemoveListener(ShowSpecificCounter<SheepData>);
        }

        private void ShowSpecificCounter<T>() where T : IComponentData
        {
            _entityManager = _defaultGameObjectInjectionWorld.GetExistingSystem<MoveSystem>()
                .EntityManager;


            _entityQuery = _entityManager.CreateEntityQuery(ComponentType.ReadOnly<T>());


            _sheepCounter.text = _entityQuery.CalculateEntityCount().ToString();
        }
    }
}
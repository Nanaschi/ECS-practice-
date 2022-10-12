using System;
using TMPro;
using Unity.Entities;
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


        
        private void Start()
        {
            _defaultGameObjectInjectionWorld = World.DefaultGameObjectInjectionWorld;

        }
        
        
        private void OnEnable()
        {
            _sheepButton.onClick.AddListener(ShowSpecificCounter<TankData>);
         
        }

        private void OnDisable()
        {
            _sheepButton.onClick.RemoveListener(ShowSpecificCounter<TankData>);
        }

        private void ShowSpecificCounter<T>() where T: IComponentData
        {
            EntityManager entityManager = _defaultGameObjectInjectionWorld
                .GetExistingSystem<MoveSystem>().EntityManager;


            _entityQuery = entityManager.CreateEntityQuery
                (ComponentType.ReadOnly<T>());


            _sheepCounter.text = _entityQuery.CalculateEntityCount().ToString();
        }


    }
}
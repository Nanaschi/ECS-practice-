using System;
using Unity.Entities;
using UnityEngine;

namespace New_Folder._Scripts
{
    public class ECSInterface: MonoBehaviour
    {
        private World _defaultGameObjectInjectionWorld;

        private void Start()
        {


            
            _defaultGameObjectInjectionWorld = World.DefaultGameObjectInjectionWorld;
            EntityManager entityManager =
                _defaultGameObjectInjectionWorld.GetExistingSystem<MoveSystem>().EntityManager;
            print(entityManager.GetAllEntities().Length);

            var entityQuery = entityManager.CreateEntityQuery
                (ComponentType.ReadOnly<SheepData>());
            
            print($"Sheep Query {entityQuery.CalculateEntityCount()}");
        }
    }
}
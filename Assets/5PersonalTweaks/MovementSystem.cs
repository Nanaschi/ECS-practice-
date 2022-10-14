using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace _5PersonalTweaks
{
    public partial class MovementSystem: SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.WithName("Test").ForEach(
                (ref Rotation rotation, 
                    ref Translation translation,
                    in CubeData cubeData) =>
                {
                    translation.Value.z += cubeData.Speed;
                }).Schedule();
        }
    }
}
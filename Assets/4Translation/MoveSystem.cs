using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class MoveSystem1 : SystemBase
{
    protected override void OnUpdate()
    {
        Entities
            .WithName("MovingTanksForward")
            .ForEach((ref Translation position, ref TankData TankData, in Rotation rotation) =>
            {
                position.Value += 0.05f * math.forward(rotation.Value);
            })
            .Schedule();
    }
}

using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

/*public partial class MoveSystem1 : SystemBase
{

    
    protected override void OnUpdate()
    {
        
        
        float3 target = new(5, 5, 5);
        Entities
            .WithName("MovingTanksForward")
            .ForEach((ref Translation position, ref Rotation rotation,in TankData tankData) =>
            {
                var positionValue = target - position.Value;
                positionValue.y = 0;
                rotation.Value = quaternion.LookRotation(positionValue, math.up());
                
                position.Value += 0.05f * positionValue * math.forward(rotation.Value);
            })
            .Schedule();
    }
}*/

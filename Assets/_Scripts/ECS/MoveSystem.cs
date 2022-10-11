using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.UIElements;
using Scale = Unity.Transforms.Scale;

public partial class MoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.WithName("MoveSystem").ForEach
            ((ref Translation position) =>
            {
                position.Value += .1f* math.up();
                if (position.Value.y > 100) position.Value.y = 0;
            }).Schedule();
    }
}

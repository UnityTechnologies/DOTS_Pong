using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Jobs;

public class BallGoalCheckSystem : JobComponentSystem
{
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		Entities
			.WithAll<BallTag>()
			.WithStructuralChanges()
			.ForEach((Entity entity, ref Translation trans) =>
			{
			float3 pos = trans.Value;
			float bound = GameManager.main.xBound;

			if (pos.x >= bound)
			{
				GameManager.main.PlayerScored(0);
				EntityManager.DestroyEntity(entity);
			}
			else if (pos.x <= -bound)
			{
				GameManager.main.PlayerScored(1);
				EntityManager.DestroyEntity(entity);
			}
		}).Run();

		return inputDeps;
	}
}

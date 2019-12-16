using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;

public class IncreaseVelocityOverTimeSystem : JobComponentSystem
{
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		inputDeps.Complete();

		float deltaTime = Time.DeltaTime;

		Entities
			.ForEach((ref PhysicsVelocity vel, in SpeedIncreaseOverTimeData data) =>
			{
				var modifier = new float2(data.increasePerSecond * deltaTime);
				
				float2 newVel = vel.Linear.xy;
				newVel += math.lerp(-modifier, modifier, math.sign(newVel));

				vel.Linear.xy = newVel;
			}).Run();

		return new JobHandle();
	}
}

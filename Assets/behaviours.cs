using System;

namespace steeringBehaviours
{
	[Flags]
	public enum behaviours
	{
		none=0,
		seek =1,
		flee =2,
		avoid =4,
		persuit=8,
		flock=16,
		evade = 32,
		arrive = 64
	}
}


using System;

namespace DakteMaus
{
	public abstract class BaseInput
	{
		protected Game1 mHost;

		public BaseInput (Game1 host)
		{
			mHost = host;
		}

		public abstract void ProcessInput();
	}
}


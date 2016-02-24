using System;

using Microsoft.Xna.Framework;

public static class Constants {
	public static Vector2 ACC_JUMP = new Vector2(0, 250);
	public static Vector2 ACC_RUN_RIGHT = new Vector2(10, 0);
	public static Vector2 ACC_RUN_LEFT = new Vector2(-10, 0);
	public static Vector2 ACC_RUN_UP = new Vector2(0, 10);
	public static Vector2 ACC_RUN_DOWN = new Vector2(0,-10);
	public static Vector2 ZERO_VEC2 = new Vector2(0,0);

	public static readonly string ACTION_STATE_NAME_DEFAULT = "default";
	public static readonly string ACTION_STATE_NAME_JUMPING = "jumping";
	public static readonly string ACTION_STATE_NAME_RUNNING = "running";
	public static readonly string ACTION_STATE_NAME_FALLING = "falling";
}

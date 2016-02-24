#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

using DakteEngine;

#endregion

namespace DakteMaus
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager mGraphics;
		SpriteBatch mSpriteBatch;
		World mWorld;
		Camera mCamera;
		Actor mPlayer;
		Physics mPhysics;
		BaseInput mInput;

		public Game1 ()
		{
			mGraphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            

			mGraphics.IsFullScreen = false;

			mGraphics.SynchronizeWithVerticalRetrace = false;

		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			mWorld = new World ();
			mPhysics = new Physics ();
			mCamera = new Camera (
				new Vector2 (0, 0), 
				new Vector2 (400, 400), 
				Utility.GenerateRectangleTexture(this.GraphicsDevice, 400, 400, Color.Green));
			mInput = new KeyboardInput (this);

			base.Initialize ();

		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			mSpriteBatch = new SpriteBatch (GraphicsDevice);

			//TODO: use this.Content to load your game content here 
			Texture2D newtonTexture = Content.Load<Texture2D>("newton/newton_right_stand_20x20x1");
			Animation newtonAnimate = new Animation (newtonTexture, 0f);
			mPlayer = new Actor (new Vector2 (20, 20), new Vector2 (0, 390), new Vector2 (0, 0));
			mPlayer.Animation = newtonAnimate;

			mWorld.AddActor (mPlayer);

			ActionState testState = Utility.LoadFromJson<ActionState> ("Content/newton_standing_actionstate.json");

			Solid s1 = new Solid (new Vector2 (300, 100), new Vector2 (0, 0), new Vector2 (0, 0));
			Texture2D t1 = Utility.GenerateRectangleTexture (this.GraphicsDevice, (int)s1.Size.X, (int)s1.Size.Y, Color.Red);

			s1.Animation = new Animation (t1, 0f);

			Solid s2 = new Solid (new Vector2 (100, 100), new Vector2 (300, 100), new Vector2 (0, 0));
			Texture2D t2 = Utility.GenerateRectangleTexture (this.GraphicsDevice, (int)s2.Size.X, (int)s2.Size.Y, Color.Blue);
			s2.Animation = new Animation (t2, 0f);

			mWorld.AddSolid (s1);
			mWorld.AddSolid (s2);

		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			mInput.ProcessInput ();

			// TODO: Add your update logic here	
			float deltaSeconds = (float) gameTime.ElapsedGameTime.TotalSeconds;
			mPhysics.Update (mWorld, deltaSeconds);
			mWorld.Update(deltaSeconds);

			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			mGraphics.GraphicsDevice.Clear (Color.CornflowerBlue);
		
			mCamera.DrawWorld(mSpriteBatch, mWorld);
            
			base.Draw (gameTime);
		}

		#region Control Commands
		public void RunRightCommand() {
			mPlayer.Accelerate(Constants.ACC_RUN_RIGHT);
		}

		public void RunLeftCommand() {
			mPlayer.Accelerate(Constants.ACC_RUN_LEFT);
		}

		public void JumpCommand() {
			mPlayer.Accelerate(Constants.ACC_JUMP);
		}
		#endregion


	}
}


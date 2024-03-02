public class Pong
{
	Texture2D ballTexture;
	Texture2D paddleTexture;
	Texture2D backgroundTexture;
	Texture2D frameTexture;

	Vector2 ballSpeed = new Vector2(4, 4);
	Vector2 ballPosition = new Vector2();
	
	public Vector2 slotMachinePosition = new Vector2(-1, -1);
	
	bool isRunning = false;
	bool gameOver = false;
	
	public bool IsPC = false;
	
	public float tick = 0.0f;
	
	int PointsCpu = 0;
	int PointsPlr = 0;
	
	Vector2 paddlePlrPosition;
	Vector2 paddlePlrPositionOld;
	Vector2 paddleCpuPosition;
	Vector2 paddleCpuPositionOld;
	
	Vector2 framePosition;
	
	public bool IsRunning
	{
		set { isRunning = value; }
		get { return isRunning; }
	}
	
	public Pong()
	{
		ballSpeed = new Vector2();
		ballPosition = new Vector2();
		framePosition = new Vector2();
		paddlePlrPosition = new Vector2();
		paddleCpuPosition = new Vector2();
		
		paddlePlrPositionOld = new Vector2();
		paddleCpuPositionOld = new Vector2();
		
		ballTexture = Main.goreTexture[Config.goreID["pong_ball"]];
		paddleTexture = Main.goreTexture[Config.goreID["pong_paddle"]];
		
		backgroundTexture = Main.goreTexture[Config.goreID["pong_bg"]];
		frameTexture = Main.goreTexture[Config.goreID["pong_frame"]];
	}
	
	public void Reset()
	{
		int direction = Main.rand.Next(3);
		ballSpeed =
				direction == 0 ? new Vector2(3, 1.8f) :
				direction == 1 ? new Vector2(3, -1.8f) :
				direction == 2 ? new Vector2(-3, 1.8f) :
				new Vector2(-3, -1.8f);
	
		ballPosition = new Vector2();
		
		ballPosition.X = (Main.screenWidth / 2) - (ballTexture.Width / 2);
		ballPosition.Y = (Main.screenHeight / 2) - (ballTexture.Height / 2);
		
		paddlePlrPosition.X = framePosition.X + 64;
		paddlePlrPosition.Y = (Main.screenHeight / 2) - (paddleTexture.Height / 2);
		
		paddleCpuPosition.X = framePosition.X + frameTexture.Width - (64 + 16);
		paddleCpuPosition.Y = (Main.screenHeight / 2) - (paddleTexture.Height / 2);
		
		paddlePlrPositionOld = new Vector2();
		paddleCpuPositionOld = new Vector2();
	}
	
	public void StartNewGame()
	{
		framePosition.X = (Main.screenWidth / 2) - (frameTexture.Width / 2);
		framePosition.Y = (Main.screenHeight / 2) - (frameTexture.Height / 2);
		
		isRunning = true;
		gameOver = false;
		
		IsPC = false;
		
		PointsCpu = PointsPlr = 0;
		
		Reset();
	}
	
	public void Update(Vector2 playerPosition)
	{
		float distance = Vector2.Distance(playerPosition, slotMachinePosition);
		Player player = Main.player[Main.myPlayer];
		bool lastRound = false;
	
		if(distance > 5)
			isRunning = false;
			
		Item silverCoin = SearchItem(player, 72);
		
		if(!IsPC)
		{
			if(silverCoin == null)
			{
				isRunning = false;
			}
		}
		
		if(!isRunning)
			return;
			
		if(gameOver)
			return;
			
		if(!IsPC)
		{
			tick++;
			
			if(tick >= 300.0f)
			{
				tick = 0.0f;
				
				if(lastRound == true)
				{
					isRunning = false;
					return;
				}
				
				if(silverCoin != null && silverCoin.stack > 1)
				{
					silverCoin.stack -= 1;
					lastRound = false;
				}
				else if(silverCoin != null && silverCoin.stack == 1)
				{
					silverCoin.stack -= 1;
					lastRound = true;
				}
			}
		}
		
		int frameMinY = (int)framePosition.Y + 16;
		int frameMaxY = (int)framePosition.Y + frameTexture.Height - 16;
		int frameMinX = (int)framePosition.X + 16;
		int frameMaxX = (int)framePosition.X + frameTexture.Width - 16;
		
		Rectangle paddlePlrRect = new Rectangle((int)paddlePlrPosition.X, (int)paddlePlrPosition.Y, paddleTexture.Width, paddleTexture.Height);
		Rectangle paddleCpuRect = new Rectangle((int)paddleCpuPosition.X, (int)paddleCpuPosition.Y, paddleTexture.Width, paddleTexture.Height);
		Rectangle ballRect = new Rectangle((int)ballPosition.X, (int)ballPosition.Y, ballTexture.Width, ballTexture.Height);
		
		// Update the paddle's position
		paddlePlrPositionOld = paddlePlrPosition;
		paddleCpuPositionOld = paddleCpuPosition;
		
		Microsoft.Xna.Framework.Input.KeyboardState keyState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
		
		if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
		{
			if(paddlePlrPosition.Y > frameMinY)
				paddlePlrPosition.Y -= 5;
		}
		else if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S))
		{
			if((paddlePlrPosition.Y + paddleTexture.Height) < frameMaxY) 
				paddlePlrPosition.Y += 5;
		}
		
		float CPUPaddleSpeed = 7.7f;
		float cpuChange = CPUPaddleSpeed * 0.52f;
		
		// CPU Paddle
		if (paddleCpuPosition.Y > ballPosition.Y + cpuChange)
		{
			if(paddleCpuPosition.Y > frameMinY)
				paddleCpuPosition.Y -= cpuChange;
		}
		else if (paddleCpuPosition.Y < ballPosition.Y - cpuChange)
		{
			if((paddleCpuPosition.Y + paddleTexture.Height) < frameMaxY) 
				paddleCpuPosition.Y += cpuChange;
		}
		
		// Collision detection	
		float speedPlrY = paddlePlrPosition.Y - paddlePlrPositionOld.Y;
		if(speedPlrY == 0)
			speedPlrY = 1.1f;
			
		float speedCpuY = paddleCpuPosition.Y - paddleCpuPositionOld.Y;
		if(speedCpuY == 0)
			speedCpuY = 1.1f;

		if(ballRect.Intersects(paddlePlrRect))
		{
			ballSpeed.X = Math.Abs(ballSpeed.X);
			
			ballSpeed.Y = speedPlrY * 0.9f;
				
			ballSpeed *= 1.05f;
			
			if(SoundHandler.customSoundInstance[SoundHandler.soundID["pong"]].State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
				Main.PlaySound(2,-1,-1,SoundHandler.soundID["pong"]);
		}	
		
		if(ballRect.Intersects(paddleCpuRect))
		{
			ballSpeed.X = -Math.Abs(ballSpeed.X);
			
			ballSpeed.Y = speedCpuY * 0.9f;
				
			ballSpeed *= 1.05f;
			
			if(SoundHandler.customSoundInstance[SoundHandler.soundID["pong"]].State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
				Main.PlaySound(2,-1,-1,SoundHandler.soundID["pong"]);
		}
		
		ballPosition += ballSpeed;
		
		if(ballPosition.X + ballTexture.Width > frameMaxX)
		{
			PointsPlr+=1;
			Reset();
			
			Main.PlaySound(18,-1,-1,1);
		}
		else if(ballPosition.X < frameMinX)
		{
			PointsCpu+=1;
			Reset();
			
			Main.PlaySound(18,-1,-1,1);
		}
		
	    if (ballPosition.Y + ballTexture.Height > frameMaxY || ballPosition.Y < frameMinY)
		{
			if(ballPosition.Y + ballTexture.Height > frameMaxY)
				ballPosition.Y -= 0.5f;
			else if(ballPosition.Y < frameMinY)
				ballPosition.Y += 0.5f;
			 
			ballSpeed.Y *= -1;
			
			if(SoundHandler.customSoundInstance[SoundHandler.soundID["pong"]].State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
				Main.PlaySound(2,-1,-1,SoundHandler.soundID["pong"]);
		}	
		
		if(PointsPlr >= 9 || PointsCpu >= 9)
		{
			gameOver = true;
			Reset();
			
			if(PointsPlr > PointsCpu)
			{
				if(!IsPC)
				{
					SearchItem(player, 72).stack += 50;
					Main.PlaySound(18,-1,-1,1); 
				}
				
				ModWorld.Achieve(0, "PONGPROFI");
			}
		}
	}
	
	Item SearchItem(Player player, int type)
	{
		if(IsPC)
			return null;
	
		for(int i = 0; i < player.inventory.Length; i++)
		{
			if(player.inventory[i].type == type && player.inventory[i].stack > 0)
			{
				return player.inventory[i];
			}
		}
		
		return null;
	}
	
	public void Draw(SpriteBatch spriteBatch)
	{
		if(!isRunning)
			return;
			
		string text = "";
		Vector2 textPos = new Vector2();
		Vector2 fontOrigin = new Vector2();
			
		spriteBatch.Draw(backgroundTexture, framePosition, Color.White);
		
		spriteBatch.Draw(ballTexture, ballPosition, Color.White);
		
		spriteBatch.Draw(paddleTexture, paddlePlrPosition, Color.White);
		spriteBatch.Draw(paddleTexture, paddleCpuPosition, Color.White);
		
		spriteBatch.Draw(frameTexture, framePosition, Color.White);
		
		// Player Score
		text = PointsPlr.ToString();
		textPos = new Vector2(framePosition.X + (frameTexture.Width/2) - 32, framePosition.Y - 4);
		fontOrigin = Main.fontDeathText.MeasureString(text) / 2;
	
		ModWorld.DrawText(spriteBatch, text, textPos, fontOrigin, Color.White, Main.fontDeathText);
		
		// CPU Score
		text = PointsCpu.ToString();
		textPos = new Vector2(framePosition.X + (frameTexture.Width/2) + 32, framePosition.Y - 4);
		fontOrigin = Main.fontDeathText.MeasureString(text) / 2;
	
		ModWorld.DrawText(spriteBatch, text, textPos, fontOrigin, Color.White, Main.fontDeathText);
		
		// Draw GameOver/Won Text
		if(!gameOver)
			return;
		
		if(PointsPlr >= 9)
		{
			text = "You Won!";
		}
		else if(PointsCpu >= 9)
		{
			text = "You Lost!";
		}
			
		textPos = new Vector2(framePosition.X + frameTexture.Width / 2, framePosition.Y + frameTexture.Height / 2);
		fontOrigin = Main.fontDeathText.MeasureString(text) / 2;
	
		ModWorld.DrawText(spriteBatch, text, textPos, fontOrigin, Color.Gold, Main.fontDeathText, 1.2f);
		
		// Draw Buttons
		ModWorld.oldMouseState = ModWorld.mouseState;
		ModWorld.mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();

		Rectangle mouseRect = new Rectangle(ModWorld.mouseState.X, ModWorld.mouseState.Y, 1, 1);
		Rectangle buttonRect;
		Color textColor = Color.White;
	
		// Button 'Close'
		text = "Close";
		textPos = new Vector2(framePosition.X + frameTexture.Width / 2, framePosition.Y + (frameTexture.Height / 2) + 64);
		fontOrigin = Main.fontMouseText.MeasureString(text) / 2;
	
		buttonRect = new Rectangle((int)(textPos.X-fontOrigin.X), (int)(textPos.Y-fontOrigin.Y), (int)fontOrigin.X*2, (int)fontOrigin.Y*2);
	
		if(mouseRect.Intersects(buttonRect))
		{
			textColor = Color.Yellow;
			
			if(mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && oldMouseState != mouseState)
			{
				Main.PlaySound(12,-1,-1,1);
				isRunning = false;
			}
		}
		else
		{
			textColor = Color.White;
		}
	
		ModWorld.DrawText(spriteBatch, text, textPos, fontOrigin, textColor, Main.fontMouseText);
		
		// Button 'New game'
		text = "New Game";
		textPos = new Vector2(framePosition.X + frameTexture.Width / 2, framePosition.Y + (frameTexture.Height / 2) + 32);
		fontOrigin = Main.fontMouseText.MeasureString(text) / 2;
	
		buttonRect = new Rectangle((int)(textPos.X-fontOrigin.X), (int)(textPos.Y-fontOrigin.Y), (int)fontOrigin.X*2, (int)fontOrigin.Y*2);
	
		if(mouseRect.Intersects(buttonRect))
		{
			textColor = Color.Yellow;
			
			if(mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && oldMouseState != mouseState)
			{
				Main.PlaySound(12,-1,-1,1);
				StartNewGame();
			}
		}
		else
		{
			textColor = Color.White;
		}
	
		ModWorld.DrawText(spriteBatch, text, textPos, fontOrigin, textColor, Main.fontMouseText);
	}
}

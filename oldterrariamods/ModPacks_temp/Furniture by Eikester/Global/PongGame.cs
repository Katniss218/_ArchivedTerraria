public class SimpleTexture
{
	public Texture2D Create(int sizeX, int sizeY)
	{
		float scale = Main.screenWidth / 800f;
	
		int sX = (int)(sizeX * scale);
		int sY = (int)(sizeY * scale);
	
		Texture2D texture = new Texture2D(Config.mainInstance.GraphicsDevice, sX, sY, false, SurfaceFormat.Color);
		
		Color[] colors = new Color[sX * sY];
 
		for (int x = 0; x < sX; x++)
		{
			for (int y = 0; y < sY; y++)
			{
				colors[x + y * sX] = Color.White;
			}
		}
		
		texture.SetData(colors);
		
		return texture;
	}
}

public class PongGame
{
	private Bat rightBat;
	private Bat leftBat;
	private Input input;
	private Ball ball;
	private Menu menu;
	
	private int resetTimer;
	private bool resetTimerInUse;
	private bool lastScored;
	
	private Texture2D background;
	private Texture2D background2;
	
	public bool IsPC = false;
	
	public enum GameStates
	{
		Menu,
		Running,
		End
	}
	
	public static GameStates gamestate;
	
	public void Initialize()
	{
		background = Main.goreTexture[Config.goreID["bg"]];
		
		SimpleTexture st = new SimpleTexture();
		background2 = st.Create(16,16);
	
		rightBat = new AIBat(new Vector2(Main.screenWidth, Main.screenHeight), false);
		leftBat = new Bat(new Vector2(Main.screenWidth, Main.screenHeight), true);
		
		input = new Input();
		
		ball = new Ball(new Vector2(Main.screenWidth, Main.screenHeight));
		
		resetTimer = 0;
		resetTimerInUse = true;
		lastScored = false;
		
		gamestate = GameStates.Menu;
		
		menu = new Menu();
	}
	
	public void Draw(SpriteBatch spriteBatch)
	{
		if (gamestate == GameStates.Running)
        {
			spriteBatch.Draw(background, new Rectangle(0,0,Main.screenWidth, Main.screenHeight), Color.White); 
		
			leftBat.Draw(spriteBatch);
			rightBat.Draw(spriteBatch);
			ball.Draw(spriteBatch);
			spriteBatch.DrawString(Main.fontDeathText, leftBat.GetPoints().ToString(), new Vector2((Main.screenWidth / 2) - (Main.fontDeathText.MeasureString(leftBat.GetPoints().ToString()).X / 2) - 32, 20), Color.White);
			spriteBatch.DrawString(Main.fontDeathText, rightBat.GetPoints().ToString(), new Vector2((Main.screenWidth / 2) - (Main.fontDeathText.MeasureString(rightBat.GetPoints().ToString()).X / 2) + 32, 20), Color.White);
		}
        else if (gamestate == GameStates.Menu)
        {
			spriteBatch.Draw(background2, new Rectangle(0,0,Main.screenWidth, Main.screenHeight), Color.Black); 
            menu.DrawMenu(spriteBatch, Main.screenWidth);
        }
        else if (gamestate == GameStates.End)
        {
			spriteBatch.Draw(background2, new Rectangle(0,0,Main.screenWidth, Main.screenHeight), Color.Black); 
            menu.DrawEndScreen(spriteBatch, Main.screenWidth);
        }
	}
	
	public void Update()
	{
		input.Update();
		
		Player player = Main.player[Main.myPlayer];
		
		Main.playerInventory = true;

        if (gamestate == GameStates.Running)
        {
			if(input.EscapePressed)
				ModWorld.pongGameRunning = false;
			
			if (leftBat.GetPoints() > 9)
			{
				menu.InfoText = "You Won";
				
				if(!IsPC)
				{
					SearchItem(player, 73).stack += 20;
					Main.PlaySound(18,-1,-1,1); 
				}
				
				ModWorld.Achieve(0, "PONGPROFI");
				gamestate = GameStates.End;
			}
			else if (rightBat.GetPoints() > 9)
			{
				menu.InfoText = "You Lost";
				gamestate = GameStates.End;
			}
			if (resetTimerInUse)
			{
				resetTimer++;
				ball.Stop();
			}

			if (resetTimer == 60)
			{
				resetTimerInUse = false;
				ball.Reset(lastScored);
				resetTimer = 0;
			}

			if (input.LeftDown || input.RightDown) 
				leftBat.MoveDown();
			else if (input.LeftUp || input.RightUp) 
				leftBat.MoveUp();

			leftBat.UpdatePosition(ball);
			rightBat.UpdatePosition(ball);
			ball.UpdatePosition();
			
			if (ball.GetDirection() > 1.5f * Math.PI || ball.GetDirection() < 0.5f * Math.PI)                 
			{                     
				if (rightBat.GetSize().Intersects(ball.GetSize()))                     
				{                         
					ball.BatHit(CheckHitLocation(rightBat));                     
				}                 
			}                 
			else if (leftBat.GetSize().Intersects(ball.GetSize()))                 
			{                         
				ball.BatHit(CheckHitLocation(leftBat));                 
			}
			
			if (!resetTimerInUse)                 
			{                     
				if (ball.GetPosition().X > Main.screenWidth)
				{
					resetTimerInUse = true;
					lastScored = true;
					leftBat.IncrementPoints();
				}
				else if (ball.GetPosition().X < 0)
				{

					resetTimerInUse = true;
					lastScored = false;

					rightBat.IncrementPoints();
				}
			}
        }
		else if (gamestate == GameStates.Menu)
		{
			if (input.RightDown || input.LeftDown)
			{
				menu.Iterator++;
			}
			else if (input.RightUp || input.LeftUp)
			{
				menu.Iterator--;
			}

			if (input.MenuSelect)
			{
				if (menu.Iterator == 0)
				{
					bool startGame = true;
					if(!IsPC)
					{
						Item coin = SearchItem(player, 73);
						
						if(coin == null)
						{
							startGame = false;
							menu.MenuItems[0] = "Not enough Coins!";
						}
						else if(coin != null && coin.stack > 1)
						{
							coin.stack -= 1;
							Main.PlaySound(18,-1,-1,1); 
							startGame = true;
						}
						else if(coin != null && coin.stack == 1)
						{
							coin.stack -= 1;
							Main.PlaySound(18,-1,-1,1); 
							coin = new Item();
							startGame = true;
						}
					}
				
					if(startGame == true)
					{
						gamestate = GameStates.Running;
						SetUpSingle();
					}
				}
				else if (menu.Iterator == 1)
				{
					Main.playerInventory = false;
					ModWorld.pongGameRunning = false;
				}
				menu.Iterator = 0;
			}
		}
		else if (gamestate == GameStates.End)
		{
			if (input.MenuSelect)
			{
				gamestate = GameStates.Menu;
			}
		}
	}
	
	Item SearchItem(Player player, int type)
	{
		for(int i = 0; i < player.inventory.Length; i++)
		{
			if(player.inventory[i].type == type && player.inventory[i].stack > 0)
			{
				return player.inventory[i];
			}
		}
		
		return null;
	}
	
	private void SetUpSingle()
	{
		rightBat = new AIBat(new Vector2(Main.screenWidth, Main.screenHeight), false);
		leftBat = new Bat(new Vector2(Main.screenWidth, Main.screenHeight), true);
	}
	
	private int CheckHitLocation(Bat bat)
	{
		int block = 0;
		if (ball.GetPosition().Y < bat.GetPosition().Y + bat.GetSize().Height / 20) block = 1;
		else if (ball.GetPosition().Y < bat.GetPosition().Y + bat.GetSize().Height / 10 * 2) block = 2;
		else if (ball.GetPosition().Y < bat.GetPosition().Y + bat.GetSize().Height / 10 * 3) block = 3;
		else if (ball.GetPosition().Y < bat.GetPosition().Y + bat.GetSize().Height / 10 * 4) block = 4;
		else if (ball.GetPosition().Y < bat.GetPosition().Y + bat.GetSize().Height / 10 * 5) block = 5;
		else if (ball.GetPosition().Y < bat.GetPosition().Y + bat.GetSize().Height / 10 * 6) block = 6;
		else if (ball.GetPosition().Y < bat.GetPosition().Y + bat.GetSize().Height / 10 * 7) block = 7;
		else if (ball.GetPosition().Y < bat.GetPosition().Y + bat.GetSize().Height / 10 * 8) block = 8;
		else if (ball.GetPosition().Y < bat.GetPosition().Y + bat.GetSize().Height / 20 * 19) block = 9;
		else block = 10;
		return block;
	}
}

public class Menu
{
	public List<string> MenuItems;
	private int iterator;
	public string InfoText { get; set; }
	public string Title { get; set; }
	
	public int Iterator
	{
		get
		{
			return iterator;
		}
		set
		{
			iterator = value;
			if (iterator > MenuItems.Count - 1) iterator = MenuItems.Count - 1;
			if (iterator < 0) iterator = 0;
		}
	}
	
	public Menu()
	{
		Title = "Pong";
		MenuItems = new List<string>();
		MenuItems.Add("Play (1 Gold Coin)");
		MenuItems.Add("Exit Game");
		Iterator = 0;
		InfoText = string.Empty;
	}
	
	public int GetNumberOfOptions()
	{
		return MenuItems.Count;
	}

	public string GetItem(int index)
	{
		return MenuItems[index];
	}
	
	public void DrawMenu(SpriteBatch batch, int screenWidth)
	{
		batch.DrawString(Main.fontDeathText, Title, new Vector2(screenWidth / 2 - Main.fontDeathText.MeasureString(Title).X / 2, 20), Color.White);
		int yPos = 300;
		for (int i = 0; i < GetNumberOfOptions(); i++)
		{
			Color colour = Color.White;
			if (i == Iterator)
			{
				colour = Color.Yellow;
			}
		batch.DrawString(Main.fontDeathText, GetItem(i), new Vector2(screenWidth / 2 - Main.fontDeathText.MeasureString(GetItem(i)).X / 2, yPos), colour);
		yPos += 60;
		}
	}
	
	public void DrawEndScreen(SpriteBatch batch, int screenWidth)
	{
		batch.DrawString(Main.fontDeathText, InfoText, new Vector2(screenWidth / 2 - Main.fontDeathText.MeasureString(InfoText).X / 2, 300), Color.White);
		string prompt = "Press Enter to Continue";
		batch.DrawString(Main.fontDeathText, prompt, new Vector2(screenWidth / 2 - Main.fontDeathText.MeasureString(prompt).X / 2, 400), Color.White);
	}
}

public class Input
{
	private Microsoft.Xna.Framework.Input.KeyboardState keyboardState;
	private Microsoft.Xna.Framework.Input.KeyboardState lastState;
	
	public Input()
	{
		keyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
		lastState = keyboardState;
	}
	
	public void Update()
	{
		lastState = keyboardState;
		keyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
	}
	
	public bool RightUp
	{
		get
		{
			if (PongGame.gamestate == PongGame.GameStates.Menu)
            {
                return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up) && lastState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Up);
            }
            else
            {
                return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up);
            }
		}
	}

	public bool RightDown
	{
		get
		{
			if (PongGame.gamestate == PongGame.GameStates.Menu)
                {
                    return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down) && lastState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Down);
                }
                else
                {
                    return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down);
                }
		}
	}

	public bool LeftUp
	{
		get
		{
			if (PongGame.gamestate == PongGame.GameStates.Menu)
                {
                    return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) && lastState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.W);
                }
                else
                {
                    return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W);
                }
		}
	}

	public bool LeftDown
	{
		get
		{
			if (PongGame.gamestate == PongGame.GameStates.Menu)
                {
                    return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S) && lastState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.S);
                }
                else
                {
                    return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S);
                }
		}
	}
	
	public bool MenuSelect
	{
		get
		{
			return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter) && lastState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Enter);
		}
	}
	
	public bool EscapePressed
	{
		get
		{
			return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape) && lastState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Escape);
		}
	}
}

public static class Sound
{
	public static void PlaySound()
	{
		if(SoundHandler.customSoundInstance[SoundHandler.soundID["pong"]].State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
			Main.PlaySound(2,-1,-1,SoundHandler.soundID["pong"]);
	}
}

public class Ball
{
	private bool isVisible;
	private Vector2 position;
	private double direction;
	private Texture2D texture;
	private Rectangle size;
	private float speed;
	private float moveSpeed;
	private Vector2 resetPos;
	Random rand;
	
	SimpleTexture simpleTexture;
	
	public Ball(Vector2 screenSize)
	{
		moveSpeed = 8f;
		speed = 0;
		simpleTexture = new SimpleTexture();
		texture = simpleTexture.Create(16,16); //Main.goreTexture[Config.goreID["ball"]];
		direction = 0;
		size = new Rectangle(0, 0, texture.Width, texture.Height);
		resetPos = new Vector2(screenSize.X / 2, screenSize.Y / 2);
		position = resetPos;
		rand = new Random();
		isVisible = true;
	}
	
	public void UpdatePosition()
	{
		size.X = (int)position.X;
		size.Y = (int)position.Y;
		position.X += speed * (float)Math.Cos(direction);
		position.Y += speed * (float)Math.Sin(direction);
		
		CheckWallHit();
	}
	
	public void Stop()
	{
		isVisible = false;
		speed = 0;
	}
	
	public void Reset(bool left)
	{
		if (left) direction = 0;
		else direction = Math.PI;
		position = resetPos;
		isVisible = true;
		speed = moveSpeed;
		
		if (rand.Next(2) == 0)
            {
                direction += MathHelper.ToRadians(rand.Next(30));
            }
            else
            {
                direction -= MathHelper.ToRadians(rand.Next(30));
            }
	}
	
	private void CheckWallHit()
	{
		while (direction > 2 * Math.PI) direction -= 2 * Math.PI;
		while (direction < 0) direction += 2 * Math.PI;
		if (position.Y <= 0 || (position.Y > resetPos.Y * 2 - size.Height))
		{
			direction = 2 * Math.PI - direction;
			Sound.PlaySound();
		}
	}
	
	public double GetDirection()
	{
		return direction;
	}

	public Rectangle GetSize()
	{
		return size;
	}

	public Vector2 GetPosition()
	{
		return position;
	}
	
	public void BatHit(int block)
	{
		if (direction > Math.PI * 1.5f || direction < Math.PI * 0.5f)
		{
			switch (block)
			{
				case 1:
					direction = MathHelper.ToRadians(220);
					break;
				case 2:
					direction = MathHelper.ToRadians(215);
					break;
				case 3:
					direction = MathHelper.ToRadians(200);
					break;
				case 4:
					direction = MathHelper.ToRadians(195);
					break;
				case 5:
					direction = MathHelper.ToRadians(180);
					break;
				case 6:
					direction = MathHelper.ToRadians(180);
					break;
				case 7:
					direction = MathHelper.ToRadians(165);
					break;
				case 8:
					direction = MathHelper.ToRadians(130);
					break;
				case 9:
					direction = MathHelper.ToRadians(115);
					break;
				case 10:
					direction = MathHelper.ToRadians(110);
					break;
			}
		}
		else
		{
			switch (block)
			{
				case 1:
					direction = MathHelper.ToRadians(290);
					break;
				case 2:
					direction = MathHelper.ToRadians(295);
					break;
				case 3:
					direction = MathHelper.ToRadians(310);
					break;
				case 4:
					direction = MathHelper.ToRadians(345);
					break;
				case 5:
					direction = MathHelper.ToRadians(0);
					break;
				case 6:
					direction = MathHelper.ToRadians(0);
					break;
				case 7:
					direction = MathHelper.ToRadians(15);
					break;
				case 8:
					direction = MathHelper.ToRadians(50);
					break;
				case 9:
					direction = MathHelper.ToRadians(65);
					break;
				case 10:
					direction = MathHelper.ToRadians(70);
					break;
			}
		}
		if (rand.Next(2) == 0)
		{
			direction += MathHelper.ToRadians(rand.Next(3));
		}
		else
		{
			direction -= MathHelper.ToRadians(rand.Next(3));
		}
		
		if(speed < 12.0f)
			speed += 0.1f;
			
		Sound.PlaySound();
	}
	
	public void Draw(SpriteBatch batch)
        {
            if (isVisible)
            {
                batch.Draw(texture, position, Color.White);
            }
        }
}

public class AIBat : Bat
{
	public AIBat(Vector2 screenSize, bool side) : base(screenSize, side)
	{
	}
 
	public override void UpdatePosition(Ball ball)
	{
		if (ball.GetDirection() > 1.5 * Math.PI || ball.GetDirection() < 0.5 * Math.PI)
		{
			if (ball.GetPosition().Y - 5 > GetPosition().Y + GetSize().Height / 2)
			{
				MoveDown();
			}
			else if (ball.GetPosition().Y == GetPosition().Y + GetSize().Height / 2)
			{
			}
			else if (ball.GetPosition().Y + 5 < GetPosition().Y + GetSize().Height / 2)
			{
				MoveUp();
			}
		}
		base.UpdatePosition(ball);
	}
}

public class Bat
{
	private Vector2 position;
	private int moveSpeed;
	private Rectangle size;
	private int points;
	private int yHeight;
	private Texture2D texture;
	SimpleTexture simpleTexture;
	
	public Bat(Vector2 screenSize, bool side)
	{
		moveSpeed = 7;
		points = 0;
		simpleTexture = new SimpleTexture();
		texture = simpleTexture.Create(16,64); //Main.goreTexture[Config.goreID["bat"]];
		size = new Rectangle(0, 0, texture.Width, texture.Height);
		
		if (side) 
			position = new Vector2(30, screenSize.Y / 2 - size.Height / 2);
		else 
			position = new Vector2(screenSize.X - 30 - size.Width, screenSize.Y / 2 - size.Height / 2);
			
		yHeight = (int)screenSize.Y;
	}
	
	public void IncrementPoints()
	{
		points++;
	}

	public int GetPoints()
	{
		return points;
	}
	
	public void Draw(SpriteBatch batch)
	{
		batch.Draw(texture, position, Color.White);
	}
	
	private void SetPosition(Vector2 position)
	{
		if (position.Y < 0)
		{
			position.Y = 0;
		}
		if (position.Y > yHeight - size.Height)
		{
			position.Y = yHeight - size.Height;
		}
		this.position = position;
	}
	
	public virtual void UpdatePosition(Ball ball)
	{
		size.X = (int)position.X;
		size.Y = (int)position.Y;
	}
	
	public void MoveUp()
	{
		SetPosition(position + new Vector2(0, -moveSpeed));
	}

	public void MoveDown()
	{
		SetPosition(position + new Vector2(0, moveSpeed));
	}
	
	public Rectangle GetSize()
	{
		return size;
	}

	public Vector2 GetPosition()
	{
		return position;
	}
}
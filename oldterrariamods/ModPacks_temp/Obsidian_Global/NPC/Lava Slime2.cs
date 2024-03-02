public void Initialize(){
this.npc.scale=1;
this.npc.damage=30;
this.npc.alpha=0;
this.npc.name="Earth Slime";
}

public void AI(){

				if (this.npc.type == 81)
				{
					
					if (Main.rand.Next(30) == 0)
					{
						int num = Dust.NewDust(this.npc.position, this.npc.width, this.npc.height, 14, 0f, 0f, this.npc.alpha, this.npc.color, 1f);
						Dust expr_177 = Main.dust[num];
						expr_177.velocity *= 0.3f;
					}
				}
				if (true)
				{
					Lighting.addLight((int)((this.npc.position.X + (float)(this.npc.width / 2)) / 16f), (int)((this.npc.position.Y + (float)(this.npc.height / 2)) / 16f), 1f, 0.3f, 0.1f);
					Vector2 arg_244_0 = new Vector2(this.npc.position.X, this.npc.position.Y);
					int arg_244_1 = this.npc.width;
					int arg_244_2 = this.npc.height;
					int arg_244_3 = 6;
					float arg_244_4 = this.npc.velocity.X * 0.2f;
					float arg_244_5 = this.npc.velocity.Y * 0.2f;
					int arg_244_6 = 100;
					Color newColor = default(Color);
					int num2 = Dust.NewDust(arg_244_0, arg_244_1, arg_244_2, arg_244_3, arg_244_4, arg_244_5, arg_244_6, newColor, 1.7f);
					Main.dust[num2].noGravity = true;
				}
				if (this.npc.ai[2] > 1f)
				{
					this.npc.ai[2] -= 1f;
				}
				if (this.npc.wet)
				{
					if (this.npc.collideY)
					{
						this.npc.velocity.Y = -2f;
					}
					if (this.npc.velocity.Y < 0f && this.npc.ai[3] == this.npc.position.X)
					{
						this.npc.direction *= -1;
						this.npc.ai[2] = 200f;
					}
					if (this.npc.velocity.Y > 0f)
					{
						this.npc.ai[3] = this.npc.position.X;
					}
					if (true)
					{
						if (this.npc.velocity.Y > 2f)
						{
							this.npc.velocity.Y = this.npc.velocity.Y * 0.9f;
						}
						else
						{
							if (this.npc.directionY < 0)
							{
								this.npc.velocity.Y = this.npc.velocity.Y - 0.8f;
							}
						}
						this.npc.velocity.Y = this.npc.velocity.Y - 0.5f;
						if (this.npc.velocity.Y < -10f)
						{
							this.npc.velocity.Y = -10f;
						}
					}
					else
					{
						if (this.npc.velocity.Y > 2f)
						{
							this.npc.velocity.Y = this.npc.velocity.Y * 0.9f;
						}
						this.npc.velocity.Y = this.npc.velocity.Y - 0.5f;
						if (this.npc.velocity.Y < -4f)
						{
							this.npc.velocity.Y = -4f;
						}
					}
					if (this.npc.ai[2] == 1f)
					{
						this.npc.TargetClosest(true);
					}
				}
				this.npc.aiAction = 0;
				if (this.npc.ai[2] == 0f)
				{
					this.npc.ai[0] = -100f;
					this.npc.ai[2] = 1f;
					this.npc.TargetClosest(true);
				}
				if (this.npc.velocity.Y == 0f)
				{
					if (this.npc.ai[3] == this.npc.position.X)
					{
						this.npc.direction *= -1;
						this.npc.ai[2] = 200f;
					}
					this.npc.ai[3] = 0f;
					this.npc.velocity.X = this.npc.velocity.X * 0.8f;
					if ((double)this.npc.velocity.X > -0.1 && (double)this.npc.velocity.X < 0.1)
					{
						this.npc.velocity.X = 0f;
					}
	
					
						this.npc.ai[0] += 1f;
					
					this.npc.ai[0] += 1f;
					if (true)
					{
						this.npc.ai[0] += 2f;
					}
					if (this.npc.type == 71)
					{
						this.npc.ai[0] += 3f;
					}
					if (this.npc.type == 138)
					{
						this.npc.ai[0] += 2f;
					}
					if (this.npc.type == 81)
					{
						if (this.npc.scale >= 0f)
						{
							this.npc.ai[0] += 4f;
						}
						else
						{
							this.npc.ai[0] += 1f;
						}
					}
					if (this.npc.ai[0] >= 0f)
					{
						this.npc.netUpdate = true;
						if (this.npc.ai[2] == 1f)
						{
							this.npc.TargetClosest(true);
						}
						if (this.npc.ai[1] == 2f)
						{
							this.npc.velocity.Y = -8f;
							if (true)
							{
								this.npc.velocity.Y = this.npc.velocity.Y - 2f;
							}
							this.npc.velocity.X = this.npc.velocity.X + (float)(3 * this.npc.direction);
							if (true)
							{
								this.npc.velocity.X = this.npc.velocity.X + 0.5f * (float)this.npc.direction;
							}
							this.npc.ai[0] = -200f;
							this.npc.ai[1] = 0f;
							this.npc.ai[3] = this.npc.position.X;
						}
						else
						{
							this.npc.velocity.Y = -6f;
							this.npc.velocity.X = this.npc.velocity.X + (float)(2 * this.npc.direction);
							if (true)
							{
								this.npc.velocity.X = this.npc.velocity.X + (float)(2 * this.npc.direction);
							}
							this.npc.ai[0] = -120f;
							this.npc.ai[1] += 1f;
						}
						if (this.npc.type == 141)
						{
							this.npc.velocity.Y = this.npc.velocity.Y * 1.3f;
							this.npc.velocity.X = this.npc.velocity.X * 1.2f;
							return;
						}
					}
					else
					{
						if (this.npc.ai[0] >= -30f)
						{
							this.npc.aiAction = 1;
							return;
						}
					}
				}
				else
				{
					if (this.npc.target < 255 && ((this.npc.direction == 1 && this.npc.velocity.X < 3f) || (this.npc.direction == -1 && this.npc.velocity.X > -3f)))
					{
						if ((this.npc.direction == -1 && (double)this.npc.velocity.X < 0.1) || (this.npc.direction == 1 && (double)this.npc.velocity.X > -0.1))
						{
							this.npc.velocity.X = this.npc.velocity.X + 0.2f * (float)this.npc.direction;
							return;
						}
						this.npc.velocity.X = this.npc.velocity.X * 0.93f;
						return;
					}
				}
}
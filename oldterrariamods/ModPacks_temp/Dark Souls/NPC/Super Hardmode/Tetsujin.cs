float customAi1;
int breathCD = 30;
//int previous = 0;
bool breath = false;

#region Spawn
public bool SpawnNPC(int x,int y,int PID)
{
      Player P = Main.player[PID]; //this shortens our code up from writing this line over and over.
      
      bool Sky = P.position.Y <= (Main.rockLayer * 4);
      bool Meteor = P.zoneMeteor;
      bool Jungle = P.zoneJungle;
      bool Dungeon = P.zoneDungeon;
      bool Corruption = P.zoneEvil;
      bool Hallow = P.zoneHoly;
      bool AboveEarth  = P.position.Y < Main.worldSurface;
      bool InBrownLayer = P.position.Y >= Main.worldSurface && P.position.Y < Main.rockLayer;
      bool InGrayLayer = P.position.Y >= Main.rockLayer && P.position.Y < (Main.maxTilesY - 200)*16;
      bool InHell = P.position.Y >= (Main.maxTilesY - 200)*16;
      bool Ocean = P.position.X < 3600 || P.position.X > (Main.maxTilesX-100)*16;
	  bool SevenToNine = P.position.X > Main.maxTilesX*0.7f && P.position.X < Main.maxTilesX*0.9f; //Seven to nine/tenths wide (the right side of the map but not the very edge)
	  bool ThreeToSeven = P.position.X > Main.maxTilesX*0.3f && x < Main.maxTilesX*0.7f; //Between three and seven tenths wide (the middle of the map)
	  bool BeforeThreeAfterSeven = P.position.X < Main.maxTilesX*0.3f || P.position.X > Main.maxTilesX*0.7f; //Before 3/10ths or after 7/10ths width (a little wider than ocean bool?)
      // these are all the regular stuff you get , now lets see......

	 //if (Meteor && ModWorld.superHardmode && Main.rand.Next(30)==1) return true;
	 if (Meteor && ModWorld.superHardmode && AboveEarth && Main.rand.Next(50)==1) return true;
     if (Meteor && ModWorld.superHardmode && !AboveEarth && Main.rand.Next(100)==1) return true;
	 if (Meteor && ModWorld.superHardmode && !Main.dayTime && AboveEarth && Main.rand.Next(20)==1) return true;
	 if (Meteor && ModWorld.superHardmode && Main.bloodMoon && AboveEarth && Main.rand.Next(10)==1) return true;
	 if (Sky && SevenToNine && ModWorld.superHardmode && Main.rand.Next(80)==1) return true;
     if (Sky && !SevenToNine && ModWorld.superHardmode && Main.rand.Next(200)==1) return true;
	 if (Sky && SevenToNine && ModWorld.superHardmode && !Main.dayTime && Main.rand.Next(30)==1) return true;
	 if (Sky && SevenToNine && ModWorld.superHardmode && Main.bloodMoon && AboveEarth && Main.rand.Next(10)==1) return true;
     if (Sky && BeforeThreeAfterSeven && ModWorld.superHardmode && Main.rand.Next(150)==1) return true;

      return false;
}
#endregion
#region AI
public void AI() 
{

				


    bool flag25 = false;
    if(Main.netMode != 1)
    {
        npc.ai[1] += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
        if (npc.ai[1] >= 10f)
        {
            


			npc.TargetClosest(true);
		    if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))           
            {


	 //Player nT = Main.player[npc.target];
    if (Main.rand.Next(600) == 0) 
	{
        breath = true;
        Main.PlaySound(2, -1, -1, 20);
    }
    if (breath) 
	{

				float num48 = 5f;
				float rotation = (float) Math.Atan2(npc.Center.Y-Main.player[npc.target].Center.Y, npc.Center.X-Main.player[npc.target].Center.X);
				int num54 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y,(float)((Math.Cos(rotation) * 25)*-1),(float)((Math.Sin(rotation) * 25)*-1), "Dragon's Breath", 75, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 50;
				npc.netUpdate=true;


	  


		breathCD--;
        //}
    }
    if (breathCD <= 0) 
	{
        breath = false;
        breathCD = 30;
        Main.PlaySound(2, -1, -1, 20);
    }



//if (Main.rand.Next(35) == 0) 
//	{
//		int num65 = Projectile.NewProjectile(npc.Center.X+Main.rand.Next(-500,500), npc.Center.Y+Main.rand.Next(-500,500), 0, 0, "Dark Explosion", 70, 0f, Main.myPlayer);
//	}

if (Main.rand.Next(15)==1)
            {
			    float num48 = 13f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 70;
				    int type = Config.projectileID["Tetsujin Laser"];//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 650;
				    Main.projectile[num54].aiStyle=23;
                      Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 12);
				    customAi1 = 1f;
                }
            	npc.netUpdate=true;
            }


	}


        }
    }
	//if (npc.justHit)
	//{
	//   npc.ai[2] = 0f;
	//}
	if (npc.ai[2] >= 0f)
	{
		int num258 = 16;
		bool flag26 = false;
		bool flag27 = false;
		if (npc.position.X > npc.ai[0] - (float)num258 && npc.position.X < npc.ai[0] + (float)num258)
		{
		    flag26 = true;
		}
		else
		{
		   if ((npc.velocity.X < 0f && npc.direction > 0) || (npc.velocity.X > 0f && npc.direction < 0))
		    {
				flag26 = true;
		    }
		}
		num258 += 24;
		if (npc.position.Y > npc.ai[1] - (float)num258 && npc.position.Y < npc.ai[1] + (float)num258)
		{
			flag27 = true;
		}
		if (flag26 && flag27)
		{
			npc.ai[2] += 1f;
			if (npc.ai[2] >= 30f && num258 == 16)
			{
				flag25 = true;
			}
			if (npc.ai[2] >= 60f)
			{
				npc.ai[2] = -200f;
				npc.direction *= -1;
				npc.velocity.X = npc.velocity.X * -1f;
				npc.collideX = false;
			}
		}
		else
		{
			npc.ai[0] = npc.position.X;
			npc.ai[1] = npc.position.Y; //added -60
			npc.ai[2] = 0f;
		}
		npc.TargetClosest(true);
	}
	else
	{
		npc.ai[2] += 1f;
		if (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) > npc.position.X + (float)(npc.width / 2))
		{
			npc.direction = -1;
		}
		else
		{
		    npc.direction = 1;
		}
	}
	int num259 = (int)((npc.position.X + (float)(npc.width / 2)) / 16f) + npc.direction * 2;
	int num260 = (int)(((npc.position.Y-30) + (float)npc.height) / 16f);
    if (npc.position.Y > Main.player[npc.target].position.Y)
    {
		//npc.velocity.Y += .1f;
		//if (npc.velocity.Y > +2)
		//{
		//	npc.velocity.Y = -2;
		//}
		
		
		//int dust = Dust.NewDust(new Vector2((float) npc.position.X + (npc.width * 0.5f), (float) npc.position.Y+1), npc.width/8, npc.height/2, 15, npc.velocity.X, npc.velocity.Y+6f, 150, Color.Blue, 1f);
		//Main.dust[dust].noGravity = false;

		if (npc.direction == -1)
		{
		int dust = Dust.NewDust(npc.Center + new Vector2(npc.direction == 1 ? npc.width * 0.5f : +15, -22), npc.width/8, npc.height/2, 15, npc.velocity.X, npc.velocity.Y+6f, 150, Color.Blue, 1f);
		Main.dust[dust].noGravity = false;
		}
		if (npc.direction == 1)
		{
		int dust = Dust.NewDust(npc.Center + new Vector2(npc.direction == -1 ? npc.width * -0.5f : -26, -22), npc.width/8, npc.height/2, 15, npc.velocity.X, npc.velocity.Y+6f, 150, Color.Blue, 1f);
		Main.dust[dust].noGravity = false;
		}
			//-26 was -21

		npc.velocity.Y -= 0.05f;
		if (npc.velocity.Y < -1)
		{
			npc.velocity.Y = -1;
		}


    }
    if (npc.position.Y < Main.player[npc.target].position.Y)
    {
        npc.velocity.Y += 0.05f;
        if (npc.velocity.Y > 1)
        {
            npc.velocity.Y = 1;
        }

		//npc.velocity.Y += .2f;
		//if (npc.velocity.Y > 2)
		//{
		//	npc.velocity.Y = 2;
		//}
    }
	if (npc.collideX)
	{
		npc.velocity.X = npc.oldVelocity.X * -0.4f;
		if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f)
		{
			npc.velocity.X = 1f;
		}
		if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f)
		{
			npc.velocity.X = -1f;
		}
	}
	if (npc.collideY)
	{
		npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
		if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
		{
			npc.velocity.Y = 1f;
		}
		if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
		{
			npc.velocity.Y = -1f;
		}
	}
	float num270 = 2.5f;
	if (npc.direction == -1 && npc.velocity.X > -num270)
	{
		npc.velocity.X = npc.velocity.X - 0.1f;
		if (npc.velocity.X > num270)
		{
			npc.velocity.X = npc.velocity.X - 0.1f;
		}
		else
		{
			if (npc.velocity.X > 0f)
			{
				npc.velocity.X = npc.velocity.X + 0.05f;
			}
		}
		if (npc.velocity.X < -num270)
		{
			npc.velocity.X = -num270;
		}
	}
	else
	{
		if (npc.direction == 1 && npc.velocity.X < num270)
		{
			npc.velocity.X = npc.velocity.X + 0.1f;
			if (npc.velocity.X < -num270)
			{
				npc.velocity.X = npc.velocity.X + 0.1f;
			}
			else
		    {
				if (npc.velocity.X < 0f)
				{
					npc.velocity.X = npc.velocity.X - 0.05f;
				}
			}
			if (npc.velocity.X > num270)
			{
				npc.velocity.X = num270;
			}
		}
	}
	if (npc.directionY == -1 && (double)npc.velocity.Y > -2.5)
	{
		npc.velocity.Y = npc.velocity.Y - 0.04f;
		if ((double)npc.velocity.Y > 2.5)
		{
			npc.velocity.Y = npc.velocity.Y - 0.05f;
		}
		else
		{
			if (npc.velocity.Y > 0f)
			{
				npc.velocity.Y = npc.velocity.Y + 0.03f;
			}
		}
		if ((double)npc.velocity.Y < -2.5)
		{
			npc.velocity.Y = -2.5f;
		}
	}
	else
	{
		if (npc.directionY == 1 && (double)npc.velocity.Y < 2.5)
		{
			npc.velocity.Y = npc.velocity.Y + 0.04f;
			if ((double)npc.velocity.Y < -2.5)
			{
				npc.velocity.Y = npc.velocity.Y + 0.05f;
			}
			else
			{
				if (npc.velocity.Y < 0f)
				{
					npc.velocity.Y = npc.velocity.Y - 0.03f;
				}
			}
			if ((double)npc.velocity.Y > 2.5)
			{
				npc.velocity.Y = 2.5f;
			}
		}
	}
    return;
}
#endregion
#region Debuffs
public void DamagePlayer(Player player, ref int damage) //hook works!
{

	if (Main.rand.Next(2) == 0)
	{
		player.AddBuff(24, 600, false); //on fire
	}
	
	if (Main.rand.Next(4) == 0)
	{
                
		player.AddBuff(36, 600, false); //broken armor
        player.AddBuff(23, 120, false); //cursed
		
	}
    
	//if (Main.rand.Next(10) == 0 && player.statLifeMax > 20) 

	//{

	//			Main.NewText("You have been cursed!");
	//	player.statLifeMax -= 20;
	//}
}
#endregion 
//-------------------------------------------------------------------

#region Glowing Eye Effect 
//public void PostDraw(SpriteBatch spriteBatch)
//{
			//broken for now
//			int spriteWidth=npc.frame.Width; //use same number as ini frameCount
//			int spriteHeight = Main.npcTexture[Config.npcDefs.byName[npc.name].type].Height / Main.npcFrameCount[npc.type];
			
//			int spritePosDifX = (int)(npc.frame.Width / 2);
//			int spritePosDifY = npc.frame.Height; // was npc.frame.Height - 4;
			
//			int frame = npc.frame.Y / spriteHeight;
			
//			int offsetX = (int)(npc.position.X + (npc.width / 2) - Main.screenPosition.X - spritePosDifX + 0.5f);
//			int offsetY = (int)(npc.position.Y + npc.height - Main.screenPosition.Y - spritePosDifY);

//			SpriteEffects flop = SpriteEffects.None;
//			if(npc.spriteDirection == 1){
//				flop = SpriteEffects.FlipHorizontally;
//			}


//				//Glowing Eye Effect
//				for(int i=0;i>-1;i--)
//				{
//					//draw 3 levels of trail
//					int alphaVal=255-(0*i); //255-(1*i);
//					Color modifiedColour = new Color((int)(alphaVal),(int)(alphaVal),(int)(alphaVal),alphaVal);
//					spriteBatch.Draw(Main.goreTexture[Config.goreID["Tetsujin Glow"]],
//						new Rectangle((int)(offsetX), (int)(offsetY), spriteWidth, spriteHeight),
//						new Rectangle(0,npc.frame.Height * frame, spriteWidth, spriteHeight),
//						modifiedColour,
//						0,  //Just add this here I think
//						new Vector2(0,0),
//						flop,
//						0);  
//				}	
//}
#endregion
//-------------------------------------------------------------------
#region gore
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Tetsujin Gore 1",0.9f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Tetsujin Gore 2",0.9f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Tetsujin Gore 3",0.9f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Tetsujin Gore 3",0.9f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Tetsujin Gore 2",0.9f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Tetsujin Gore 3",0.9f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Tetsujin Gore 3",0.9f,-1);
	
}
#endregion 
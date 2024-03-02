int AIStyle = 0;

public void AI(){
    bool flag2 = false;
	int num5 = 60;
	bool flag3 = true;
	if (npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0)))
	{
		flag2 = true;
	}
	if (npc.position.X == npc.oldPosition.X || npc.ai[3] >= (float)num5 || flag2)
	{
		npc.ai[3] += 1f;
	}
	else
	{
		if ((double)Math.Abs(npc.velocity.X) > 0.9 && npc.ai[3] > 0f)
		{
			npc.ai[3] -= 1f;
		}
	}
	if (npc.ai[3] > (float)(num5 * 10))
	{
		npc.ai[3] = 0f;
	}
	if (npc.justHit)
	{
		npc.ai[3] = 0f;
	}
	if (npc.ai[3] == (float)num5)
	{
		npc.netUpdate = true;
	}
    npc.TargetClosest(true);
	if (npc.velocity.X < -1.5f || npc.velocity.X > 1.5f)
	{
		if (npc.velocity.Y == 0f)
		{
			npc.velocity *= 0.8f;
		}
	}
	else
	{
		if (npc.velocity.X < 1.2f && npc.direction == 1)
		{
			npc.velocity.X = npc.velocity.X + 0.07f;
			if (npc.velocity.X > 1.2f)
			{
				npc.velocity.X = 1.2f;
			}
		}
		else
		{
			if (npc.velocity.X > -1.2f && npc.direction == -1)
			{
				npc.velocity.X = npc.velocity.X - 0.07f;
				if (npc.velocity.X < -1.2f)
				{
					npc.velocity.X = -1.2f;
				}
			}
		}
	}
	bool flag4 = false;
	if (npc.velocity.Y == 0f)
	{
		int num29 = (int)(npc.position.Y + (float)npc.height + 8f) / 16;
		int num30 = (int)npc.position.X / 16;
		int num31 = (int)(npc.position.X + (float)npc.width) / 16;
		for (int l = num30; l <= num31; l++)
		{
			if (Main.tile[l, num29] == null)
			{
				return;
			}
			if (Main.tile[l, num29].active && Main.tileSolid[(int)Main.tile[l, num29].type])
			{
				flag4 = true;
				break;
			}
		}
	}
	if (flag4)
	{
		int num32 = (int)((npc.position.X + (float)(npc.width / 2) + (float)(15 * npc.direction)) / 16f);
		int num33 = (int)((npc.position.Y + (float)npc.height - 15f) / 16f);
		if (npc.type == 109)
		{
			num32 = (int)((npc.position.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 16) * npc.direction)) / 16f);
		}
		if (Main.tile[num32, num33] == null)
		{
			Main.tile[num32, num33] = new Tile();
		}
		if (Main.tile[num32, num33 - 1] == null)
		{
			Main.tile[num32, num33 - 1] = new Tile();
		}
		if (Main.tile[num32, num33 - 2] == null)
		{
			Main.tile[num32, num33 - 2] = new Tile();
		}
		if (Main.tile[num32, num33 - 3] == null)
		{
			Main.tile[num32, num33 - 3] = new Tile();
		}
		if (Main.tile[num32, num33 + 1] == null)
		{
			Main.tile[num32, num33 + 1] = new Tile();
		}
		if (Main.tile[num32 + npc.direction, num33 - 1] == null)
		{
			Main.tile[num32 + npc.direction, num33 - 1] = new Tile();
		}
		if (Main.tile[num32 + npc.direction, num33 + 1] == null)
		{
			Main.tile[num32 + npc.direction, num33 + 1] = new Tile();
		}
		if (Main.tile[num32, num33 - 1].active && Main.tile[num32, num33 - 1].type == 10 && flag3)
		{
			npc.ai[2] += 1f;
			npc.ai[3] = 0f;
			if (npc.ai[2] >= 60f)
			{
				npc.velocity.X = 0.5f * (float)(-(float)npc.direction);
				npc.ai[1] += 1f;
				npc.ai[2] = 0f;
				bool flag5 = false;
				if (npc.ai[1] >= 10f)
				{
					flag5 = true;
					npc.ai[1] = 10f;
				}
				WorldGen.KillTile(num32, num33 - 1, true, false, false);
				if ((Main.netMode != 1 || !flag5) && flag5 && Main.netMode != 1)
				{
					if (npc.type == 26)
					{
						WorldGen.KillTile(num32, num33 - 1, false, false, false);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num32, (float)(num33 - 1), 0f, 0);
						}
					}
					else
					{
						bool flag6 = WorldGen.OpenDoor(num32, num33, npc.direction);
						if (!flag6)
						{
							npc.ai[3] = (float)num5;
							npc.netUpdate = true;
						}
						if (Main.netMode == 2 && flag6)
						{
							NetMessage.SendData(19, -1, -1, "", 0, (float)num32, (float)num33, (float)npc.direction, 0);
						}
					}
				}
			}
		}
		else
		{
			if ((npc.velocity.X < 0f && npc.spriteDirection == -1) || (npc.velocity.X > 0f && npc.spriteDirection == 1))
			{
				if (Main.tile[num32, num33 - 2].active && Main.tileSolid[(int)Main.tile[num32, num33 - 2].type])
				{
					if (Main.tile[num32, num33 - 3].active && Main.tileSolid[(int)Main.tile[num32, num33 - 3].type])
					{
						npc.velocity.Y = -8f;
						npc.netUpdate = true;
					}
					else
					{
						npc.velocity.Y = -7f;
						npc.netUpdate = true;
					}
				}
				else
				{
					if (Main.tile[num32, num33 - 1].active && Main.tileSolid[(int)Main.tile[num32, num33 - 1].type])
					{
						npc.velocity.Y = -6f;
						npc.netUpdate = true;
					}
					else
					{
						if (Main.tile[num32, num33].active && Main.tileSolid[(int)Main.tile[num32, num33].type])
						{
							npc.velocity.Y = -5f;
							npc.netUpdate = true;
						}
						else
						{
							if (npc.directionY < 0 && npc.type != 67 && (!Main.tile[num32, num33 + 1].active || !Main.tileSolid[(int)Main.tile[num32, num33 + 1].type]) && (!Main.tile[num32 + npc.direction, num33 + 1].active || !Main.tileSolid[(int)Main.tile[num32 + npc.direction, num33 + 1].type]))
							{
								npc.velocity.Y = -8f;
								npc.velocity.X = npc.velocity.X * 1.5f;
								npc.netUpdate = true;
							}
							else
							{
								if (flag3)
								{
									npc.ai[1] = 0f;
									npc.ai[2] = 0f;
								}
							}
						}
					}
				}
			}
		}
	}
	else
	{
		if (flag3)
		{
			npc.ai[1] = 0f;
			npc.ai[2] = 0f;
		}
	}
	float differenceX = ((this.npc.position.X )- (Main.player[Main.myPlayer].position.X));
	float differenceY = ((this.npc.position.Y )- (Main.player[Main.myPlayer].position.Y));
	if( differenceX > 750f || differenceX < -750f && (differenceY > 10f || differenceY < -10f)){
		AIStyle = 2;
	}else if( differenceX > 15f || differenceX < -15f && (differenceY > 15f || differenceY < -15f)){
		AIStyle = 0;			
	}else{
		AIStyle =1;
	}
	if(AIStyle ==2){
		int num = Dust.NewDust(this.npc.position, this.npc.width, this.npc.height, 14, 0f, 0f, this.npc.alpha, this.npc.color, 1f);
		Dust dust = Main.dust[num];
		Dust expr_1A2 = dust;
		expr_1A2.velocity *= 0.3f;
		this.npc.position.X = Main.player[Main.myPlayer].position.X;
		this.npc.position.Y = Main.player[Main.myPlayer].position.Y - 20;
		int num2 = Dust.NewDust(this.npc.position, this.npc.width, this.npc.height, 14, 0f, 0f, this.npc.alpha, this.npc.color, 1f);
		Dust dust2 = Main.dust[num2];
		Dust expr_1A22 = dust2;
		expr_1A22.velocity *= 0.3f;
	}
	if(npc.life < npc.lifeMax)npc.life = npc.lifeMax; // npc is pretty much invincible
}

public void Initialize(){
	this.npc.displayName = SetName();
	if(ModPlayer.hasPet == false){
		ModPlayer.pet = this.npc;
		ModPlayer.hasPet = true;
		ModPlayer.piglet = true;
	}else{
		ModPlayer.pet.StrikeNPC(999999,2, this.npc.direction);
		ModPlayer.pet = this.npc;
		ModPlayer.hasPet = true;
		ModPlayer.piglet = true;
	}
}

public static string SetName() {
	string playerName = Main.player[Main.myPlayer].name;
	/*if(ModPlayer.pigCode == "my pet"){
		return playerName +"'s Piglet";
	}
	else if(ModPlayer.pigCode == "chadwick"){
		return "Pure Awesomeness";
	}
	else if(ModPlayer.pigCode == "gem"){
		int cd = Main.rand.Next(6);
		if(cd == 0)return "Topaz";
		if(cd == 1)return "Ruby";
		if(cd == 2)return "Emerald";
		if(cd == 3)return "Sapphire";
		if(cd == 4)return "Amethyst";
		if(cd == 5)return "Diamond";
	}
	else{*/
		int c = Main.rand.Next(34);
		if(c == 0)return "Porky";
		if(c == 1)return "Toby";
		if(c == 2)return "Pigoo";
		if(c == 3)return "Innocent Piglet";
		if(c == 4)return "Spoink";
		if(c == 5)return "Ferdinant";
		if(c == 6)return "Jeffrey";
		if(c == 7)return "Fred";
		if(c == 8)return "George";
		if(c == 9)return "Spike";
		if(c == 10)return "Piglet";
		if(c == 11)return "Felix";
		if(c == 12)return "Babè";
		if(c == 13)return "Wilbur";
		if(c == 14)return "Wilson";
		if(c == 15)return "Wolfgang";
		if(c == 16)return "Simon";
		if(c == 17)return "Sir Oinksalot";
		if(c == 18)return "Sir Pork";
		if(c == 19)return "Maxwell";
		if(c == 20)return "Maxx";
		if(c == 21)return "Cyril";
		if(c == 22)return "Tank";
		if(c == 23)return playerName;
		if(c == 24)return "Topaz";
		if(c == 25)return "Ruby";
		if(c == 26)return "Emerald";
		if(c == 27)return "Sapphire";
		if(c == 28)return "Amethyst";
		if(c == 29)return "Diamond";
		if(c == 30)return "Superpig";
		if(c == 31)return "Mr. Incredipig";
		if(c == 32)return "Batpig";
		if(c == 33)return "Phineas";
		return "PigPet_SetName(24)";
	//}
}

public void NPCLoot ()
{


	Gore.NewGore(npc.position,npc.velocity,"Pig 1",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Pig 1",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Pig 1",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Pig 1",1f,-1);



}
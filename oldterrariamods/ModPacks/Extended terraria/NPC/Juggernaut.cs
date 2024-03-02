int player = 0;
bool runonce = false;
public bool SpawnNPC(int x, int y, int playerID)
{
	player = playerID;
	if (Main.hardMode && ModWorld.superHardmode && Main.player[playerID].statDefense >= 130)
	{
		if (Main.player[playerID].zoneJungle)
		{
			if (y > Main.rockLayer + 20 && y < Main.maxTilesY - 200 && Main.rand.Next(110) == 0)
			{
				if (Main.netMode == 0)
				{
					Main.NewText("A Juggernaut has awoken!", 175, 75, 255);
				}
				else if (Main.netMode == 2)
				{
					NetMessage.SendData(25, -1, -1, "A Juggernaut has awoken!", 255, 175f, 75f, 255f, 0);
				}
				return true;
			}
		}
		else
		{
			if (y > Main.rockLayer + 20 && y < Main.maxTilesY - 200 && !Main.player[playerID].zoneDungeon && Main.rand.Next(90) == 0)
			{
				if (Main.netMode == 0)
				{
					Main.NewText("A Juggernaut has awoken!", 175, 75, 255);
				}
				else if (Main.netMode == 2)
				{
					NetMessage.SendData(25, -1, -1, "A Juggernaut has awoken!", 255, 175f, 75f, 255f, 0);
				}
				return true;
			}
		}
		return false;
	}
	else return false;
}
public void Initialize()
{
	npc.position = Main.player[player].position;
}
public void AI()
{
	if (!runonce)
	{
		npc.position = Main.player[player].position;
		runonce = true;
	}
	npc.AI(true);
	if (npc.justHit)
	{
		if (Main.rand.Next(2) == 1)
		{
			int a = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, 21, 0);
		}
		if (Main.rand.Next(10) == 1)
		{
			int a = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, 77, 0);
		}
		if (Main.rand.Next(25) == 1)
		{
			int a = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, Config.npcDefs.byName["Magma Skeleton"].type, 0);
		}
		if (Main.rand.Next(33) == 1)
  		{
			int a = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, Config.npcDefs.byName["Cursed Magma Skeleton"].type, 0);
		}
	}
}
public void DamagePlayer(Player P, ref int damage)
{
	if (Main.rand.Next(4) == 0)
	{
		P.AddBuff(36, 10800, false);
	}
	P.velocity = npc.velocity;
	P.velocity.X *= 3f;
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Juggernaut Helmet",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Head",1.7f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Piece",1.7f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Vert",1.7f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Piece",1.7f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Magma Skeleton Vert",1.7f,-1);
	if (Main.netMode == 0)
	{
		Main.NewText("A Juggernaut has been defeated!", 175, 75, 255);
	}
	else if (Main.netMode == 2)
	{
		NetMessage.SendData(25, -1, -1, "A Juggernaut has been defeated!", 255, 175f, 75f, 255f, 0);
	}
}
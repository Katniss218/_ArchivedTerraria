public int exp = 0;
public int level = 1;

public void Initialize()
{
	exp = 0;
	level = 1;
	item.toolTip2 = "Exp: "+(exp/100)+" / "+(180*level);
	item.toolTip3 = "Level: "+level+" / 10";
}

public void Effects(Player player)
{
	if (level < 10)
	{
		exp += 1;
		if (exp >= 18000*level)
		{
			level++;
			exp = 0;
		}
		item.toolTip2 = "Exp: "+(exp/100)+" / "+(180*level);
		item.toolTip3 = "Level: "+level+" / 10";
	}
	else
	{
		item.toolTip2 = "Exp: 1620 / 1620";
		item.toolTip3 = "Level: 10";
	}
	
	bool Spawned = false;
	for (int num36 = 0; num36 < 200; num36++)
	{
		if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Companion Bat"].type && Main.npc[num36].ai[0] == player.whoAmi)
		{
			Spawned = true;
			Main.npc[num36].ai[1] = level;
		}
	}
	if (!Spawned)
	{
		int Bat = NPC.NewNPC((int) player.position.X+(player.width/2), (int) player.position.Y+(player.height/2), "Companion Bat", 0);
		Main.npc[Bat].ai[0] = player.whoAmi;
		Main.npc[Bat].netUpdate = true;
		if (Main.netMode == 2 && Bat < 200)
		{
			NetMessage.SendData(23, -1, -1, "", Bat, 0f, 0f, 0f, 0);
		}
	}
}

public void Save(BinaryWriter W)
{
	W.Write(exp);
	W.Write(level);
}

public void Load(BinaryReader R,int v)
{
	exp = R.ReadInt32();
	level = R.ReadInt32();
	item.toolTip2 = "Exp: "+(exp/100)+" / "+(180*level);
	item.toolTip3 = "Level: "+level+" / 10";
}
const float s = 2.2f;
public void Effects(Player P)
{	
        if (Main.netMode == 2)
        	return;
	int y = (int)Math.Round((P.position.Y + P.velocity.Y + P.height) / 16f);
	float
	    xCenter = (P.position.X + P.velocity.X + P.width / 2f) / 16f,
	    xStart = xCenter - s,
	    xEnd = xCenter + s;
	for (int x = (int)Math.Floor(xStart); x <= (int)Math.Floor(xEnd); x++)
	{
		if (Main.tile[x, y] == null)
		    Main.tile[x, y] = new Tile();
		if (!Main.tile[x, y].active && Main.tile[x, y].liquid >= 16 && !Main.tile[x, y].lava)
		{ // non-lava if you want
			Projectile p = Main.projectile[Projectile.NewProjectile(x * 16f + 8f, y * 16f + 8f, 0f, 0f, 80, 0, 0, 0)];
			p.ai[0] = (float)x;
			p.ai[1] = (float)y;
			p.timeLeft = 60 * 6;
			Main.tile[x, y].active = true;
			Main.tile[x, y].type = 127;
			WorldGen.SquareTileFrame(x, y, true);
			//if (Main.netMode == 1)
			//	NetMessage.SendModData(ModWorld.modId, ModWorld.MSG_ICE, -1, -1, x, y); // netmessage already implemented
		}
		if (!Main.tile[x, y].active && Main.tile[x, y].liquid >= 16 && Main.tile[x, y].lava)
		{
			Projectile p2 = Main.projectile[Projectile.NewProjectile(x * 16f + 8f, y * 16f + 8f, 0f, 0f, Config.projDefs.byName["Obsidian"].type, 0, 0, 0)];
			p2.ai[0] = (float)x;
			p2.ai[1] = (float)y;
			p2.timeLeft = 60 * 6;
			Main.tile[x, y].active = true;
			Main.tile[x, y].type = (ushort)Config.tileDefs.ID["Obsidian 2"];
			WorldGen.SquareTileFrame(x, y, true);
		}
	}
}
				
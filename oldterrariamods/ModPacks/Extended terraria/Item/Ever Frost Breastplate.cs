const float s = 2.2f;
public void Effects(Player P)
{
	Lighting.addLight(((int)P.Center.X + 8) * P.direction / 16, (int)P.Center.Y / 16, 1f, 1f, 1f);
	P.starCloak = P.longInvince = P.ammoCost75 = true;
	P.rangedCrit += 10;

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
public bool UseAmmo(Player P, int shoot, Item consumed) { return new Random().Next(20) != 0; }
public void DealtPlayer(Player P, double DMG, NPC N)
{
	P.immuneTime += 30;
}
public void SetBonus(Player P)
{
	P.setBonus = "Permanent Archery buff and ice glow";
	P.ShadowTail = P.ShadowAura = P.archery = true;
	int i2 = (int)((P.position.X) / 16);
	int j2 = (int)((P.position.Y) / 16);
	Lighting.addLight(i2,j2,0f,2f,2f);
}
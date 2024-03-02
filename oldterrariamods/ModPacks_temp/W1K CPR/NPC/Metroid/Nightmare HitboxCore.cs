public void AI()
{
	/*if (!Main.npc[(int)npc.realLife].active)
	{
		npc.life = 0;
		npc.HitEffect(0, 10.0);
		npc.active = false;
	}*/
	
	if (Main.netMode == 2 && npc.whoAmI < 200)
	{
		NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
	}
}

public bool PreDraw(SpriteBatch spriteBatch)
{
	return false;
}

/*public void PostDraw(SpriteBatch spriteBatch)
{
	spriteBatch.Draw(Main.blackTileTexture, new Vector2(npc.position.X - Main.screenPosition.X, npc.position.Y - Main.screenPosition.Y), new Rectangle(0,0,npc.width,npc.height),new Color(255,0,0,255));
}*/

public void DealtNPC(double damage, Player player)
{
	if (npc.immune[player.whoAmi] <= 0)
	{
		npc.immune[player.whoAmi] = player.itemAnimation;
		player.attackCD = (int)((float)player.itemAnimationMax * 0.33f);
		foreach(NPC npc2 in Main.npc)
		{
			if (npc2.realLife == npc.whoAmI)
			{
				npc2.immune[player.whoAmi] = npc.immune[player.whoAmi];
			}
		}
	}
}
#region Spawn
public static bool SpawnNPC(int x, int y, int playerID) 
{
	if (Main.bloodMoon)
	{
		if (y < Main.rockLayer + 75 && y > (int)(Main.topWorld + 100f) && !Main.dayTime && !Main.player[playerID].zoneMeteor && Main.rand.Next(10) == 0)
		{
			return true;
		}
		else return false;
	}
	else return false;
}
#endregion

#region Loot
public void NPCLoot()
{
	//generate particle effect
	Color color = new Color();
	Rectangle rectangle = new Rectangle((int)npc.position.X,(int)(npc.position.Y + ((npc.height - npc.width)/2)),npc.width,npc.width);//npc.frame;
	int count = 50;
	float vectorReduce = .4f;
	for (int i = 1; i <= count; i++)
	    {
		//int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (npc.velocity.X * 0.2f) + (npc.direction * 3), npc.velocity.Y * 0.2f, 100, color, 1.9f);
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 5, 0, 0, 50, Color.White, 1.0f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

	    Gore.NewGore(npc.position,npc.velocity,"Swollen Eye Gore 1",1.2f,-1);
	    Gore.NewGore(npc.position,npc.velocity,"Swollen Eye Gore 2",1.2f,-1);
	    Gore.NewGore(npc.position,npc.velocity,"Swollen Eye Gore 2",1.2f,-1);
}
#endregion
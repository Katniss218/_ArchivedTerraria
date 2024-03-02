public int numProjectiles = 4;
public int timer = 0;

public void Initialize()
{
	numProjectiles = 4;
}

public void AI()
{
	timer++;
	
	if(timer >= 7)
	{
	timer = 0;
	int targetID = -1;
	float distanceTarget = -1;
	foreach (NPC npc in Main.npc)
	{
		if (npc.active && !npc.friendly)
		{
			float distance = projectile.Distance(npc.Center);
			if (distanceTarget == -1f || distance < distanceTarget)
			{
				distanceTarget = distance;
				targetID = npc.whoAmI;
			}
		}
	}
	
	if (numProjectiles > 0)
	{
		if (targetID != -1)
		{
		float num48 = 0.5f;
		float rotation = (float) Math.Atan2(projectile.Center.Y-Main.npc[targetID].Center.Y, projectile.Center.X-Main.npc[targetID].Center.X);
		rotation += Config.syncedRand.Next(-50,50)/100;
		int num54 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), "Restless Soul", 50, 0f, Main.myPlayer);
		}
		numProjectiles -= 1;
	}
	}
	
	Color color = new Color();
	int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 65, 0f, 0f, 80, color, 2.0f);
	Main.dust[dust].noGravity = true;
	projectile.AI(true);
}
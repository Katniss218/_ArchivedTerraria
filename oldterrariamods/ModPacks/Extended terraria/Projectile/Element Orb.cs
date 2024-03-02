public void AI()
{
    projectile.AI(true);
    int dust = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    75,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    60,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust].noGravity = true;

    int dust2 = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    55,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    60,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust2].noGravity = true;

    int dust3 = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    3,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    60,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust3].noGravity = true;

    int dust4 = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    29,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    60,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust4].noGravity = true;

}
public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	int randomNum = Main.rand.Next(8);
	if (randomNum == 0) 
	{ 
		npc.AddBuff(20, 300);
	}
	else if (randomNum == 1) 
	{ 
		npc.AddBuff(24, 150);
	}
	else if (randomNum == 2) 
	{
		npc.AddBuff(31, 120);
	}
	else if (randomNum == 3) 
	{
		npc.AddBuff(32, 300);
	}
	else if (randomNum == 4) 
	{
		npc.AddBuff(33, 300);
	}
	else if (randomNum == 5) 
	{ 
		npc.AddBuff(36, 300);
	}
	else if (randomNum == 6) 
	{
		npc.AddBuff(39, 300);
	}
	else if (randomNum == 7) 
	{
		npc.AddBuff("Freeze", 300);
	}
}
public void DamagePVP(ref int damage, Player enemyPlayer)
{
	int randomNum = Main.rand.Next(8);
	if (randomNum == 0) 
	{ 
		enemyPlayer.AddBuff(20, 300, false);
	}
	else if (randomNum == 1) 
	{ 
		enemyPlayer.AddBuff(24, 150, false);
	}
	else if (randomNum == 2) 
	{
		enemyPlayer.AddBuff(31, 120, false);
	}
	else if (randomNum == 3) 
	{
		enemyPlayer.AddBuff(32, 300, false);
	}
	else if (randomNum == 4) 
	{
		enemyPlayer.AddBuff(33, 300, false);
	}
	else if (randomNum == 5) 
	{ 
		enemyPlayer.AddBuff(36, 300, false);
	}
	else if (randomNum == 6) 
	{
		enemyPlayer.AddBuff(39, 300, false);
	}
	else if (randomNum == 7) 
	{
		enemyPlayer.AddBuff("Frozen", 300, false);
	}
}

public void PostKill()
{
    projectile.AI(true);
    int dust = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    75,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    60,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust].noGravity = true;

    int dust2 = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    55,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    60,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust2].noGravity = true;

    int dust3 = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    3,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    60,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust3].noGravity = true;

    int dust4 = Dust.NewDust(
    projectile.position,					//position
    projectile.width,                                           //box width
    projectile.height,                                          //box height
    29,                                                          //type
    projectile.velocity.X,					//X velocity
    projectile.velocity.Y,		                        //Y velocity
    60,                                                         //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust4].noGravity = true;

}
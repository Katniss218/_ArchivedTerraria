bool spawnNew=true;

public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
    npc.AddBuff(24, 120, false);
}

public void AI()
{
	if(spawnNew){
		projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
		Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
		spawnNew=false;
	}
	if(projectile.timeLeft<10){
		projectile.damage=0;
	}
	if (Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
	{       
		Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0, 0, 100, default(Color), 0.8f);
	}
	projectile.alpha=(int)255-projectile.timeLeft*8;
	projectile.velocity=new Vector2(0,0);
	Lighting.addLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), projectile.timeLeft*0.03f, projectile.timeLeft*0.02f, 0);
	
}
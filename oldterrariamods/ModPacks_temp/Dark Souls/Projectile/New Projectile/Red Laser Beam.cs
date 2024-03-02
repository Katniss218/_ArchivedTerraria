bool spawnNew=true;
float myNumber=0;
public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
    npc.AddBuff(24, 120, false);
}

public void AI()
{
	if(spawnNew){
		myNumber=projectile.knockBack;
		projectile.knockBack=0;
		projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
		
		if (Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
		{       
			myNumber=0;
		}
		
		if(myNumber>1){
			Projectile.NewProjectile(
				(float)((projectile.position.X + projectile.width/2) + projectile.width * Math.Cos(projectile.rotation)),
				(float)((projectile.position.Y + projectile.height/2) + projectile.width * Math.Sin(projectile.rotation)),
				projectile.velocity.X,
				projectile.velocity.Y,
				Config.projDefs.byName["Red Laser Beam"].type,
				projectile.damage,
				myNumber-1f,
				projectile.owner);
		}else{
			Projectile.NewProjectile(
				(float)(projectile.position.X + projectile.width/2),
				(float)(projectile.position.Y + projectile.height/2),
				projectile.velocity.X,
				projectile.velocity.Y,
				Config.projDefs.byName["Red Laser Beam End"].type,
				(int)(projectile.damage*3),
				0,
				projectile.owner);
				
			projectile.Kill();
		}
		spawnNew=false;
	}
	if(projectile.timeLeft<10){
		projectile.damage=0;
	}
	projectile.alpha=(int)255-projectile.timeLeft*8;
	projectile.velocity=new Vector2(0,0);
	Lighting.addLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), projectile.timeLeft*0.03f, projectile.timeLeft*0.02f, 0);

}
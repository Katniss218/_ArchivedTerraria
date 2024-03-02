public void DamageNPC(NPC targetNPC, ref int damage, ref float knockback)
{
    damage = targetNPC.defense + projectile.damage;
	if (projectile.penetrate <= 0)
    {
        projectile.Kill();
    }
}
public void DealtPVP(double damage, Player enemyPlayer)
{
    damage = enemyPlayer.statDefense + projectile.damage;
	if (projectile.penetrate <= 0)
    {
        projectile.Kill();
    }
}

bool reposition=true;
float sinwaveCounter= -1.4f;
public void AI()
{
    if (reposition){
    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
	
	projectile.velocity.X*=0.45f;
    projectile.velocity.Y*=0.45f;

    reposition=false;
	projectile.alpha=255;
    }
	projectile.alpha-=51;	
	
	for(int i=0;i<10;i++){
		bool bulletHit=false;
		Rectangle myBox = new Rectangle((int)projectile.position.X,(int)projectile.position.Y,projectile.width,projectile.height);
		foreach(NPC targetNPC in Main.npc)
		{
			if(targetNPC.townNPC || bulletHit){continue;}
			Rectangle npcBox = new Rectangle((int)targetNPC.position.X,(int)targetNPC.position.Y,targetNPC.width,targetNPC.height);

			if(myBox.Intersects(npcBox) && !bulletHit && targetNPC.life>0 && !targetNPC.dontTakeDamage){//on collide
				bulletHit=true;
				npcBox=Rectangle.Empty;
				break;
			}
			npcBox=Rectangle.Empty;
		}
		
				//dust fx
		if(i%2==0){
			if(sinwaveCounter>0){//tracer
				Vector2 DustPos = projectile.position;
			
				int DustIndex = Dust.NewDust(DustPos, 0, 0, 6, 0, 0, 100, default(Color), 1.7f);
				Main.dust[DustIndex].noGravity=true;
				Main.dust[DustIndex].velocity=new Vector2 (0,0);
			}else{//fire effect
			    Vector2 DustPos = projectile.position;
				int DustWidth = projectile.width;
				int DustHeight = projectile.height;

				Dust.NewDust(DustPos, DustWidth, DustHeight, 6, 0, 0, 100, default(Color), 1.1f);
				int DustIndex = Dust.NewDust(DustPos, DustWidth, DustHeight, 31, 0, 0, 100, default(Color), 3f);
				Main.dust[DustIndex].noGravity=true;
			}
		}
		if(sinwaveCounter>0){
			//sine wave top
			Vector2 DustTopPos = projectile.position + 
				new Vector2((float)(15 * Math.Cos(sinwaveCounter) * Math.Cos(projectile.rotation)),
				(float)(15 * Math.Sin(sinwaveCounter) * Math.Sin(projectile.rotation)));
		
			int sineTop = Dust.NewDust(DustTopPos, 0, 0, 60, 0, 0, 100, default(Color), 1f);
			Main.dust[sineTop].noGravity=true;
			Main.dust[sineTop].velocity=new Vector2 (0,0);
			//sine wave bottom
			Vector2 DustBotPos = projectile.position + 
				new Vector2((float)(-15 * Math.Cos(sinwaveCounter) * Math.Cos(projectile.rotation)),
				(float)(-15 * Math.Sin(sinwaveCounter) * Math.Sin(projectile.rotation)));
		
			int sineBot = Dust.NewDust(DustBotPos, 0, 0, 60, 0, 0, 100, default(Color), 1f);
			Main.dust[sineBot].noGravity=true;
			Main.dust[sineBot].velocity=new Vector2 (0,0);
		}
		sinwaveCounter+=0.2f;
		
		if(bulletHit){
			break;
		}
	
		Vector2 velo2 = Collision.TileCollision(projectile.position, projectile.velocity, projectile.width, projectile.height, false, false);
		if(projectile.velocity != velo2){
			projectile.position += velo2;
			projectile.velocity *= new Vector2(0.1f,0.1f);
			
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			projectile.Kill();
		}	
	
		projectile.position += projectile.velocity;
	}

	Lighting.addLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 0.9f, 0.2f, 0.1f);
}

public void PreKill(){
	Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
}
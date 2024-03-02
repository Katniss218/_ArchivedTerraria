public void AI()
{	
	Color color = Color.Transparent;
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 5, 0, 0, 0, color, 1.0f);
	Main.dust[dust].noGravity = true;
}

public void PostKill()
{
      Projectile P = projectile;
      Main.PlaySound(2, (int)P.Center.X, (int)P.Center.Y, SoundHandler.soundID["Eye_Projectile"]);
      for(int i = 0; i < 20; i++)
      {
             int d = Dust.NewDust(P.position,P.width,P.height,5,P.velocity.X*-0.2f,P.velocity.Y*-0.2f,0,default(Color),1.2f);
             Main.dust[d].noGravity = true;
             Main.dust[d].velocity*=2f;
             Main.dust[d].noLight= true;
			 
             d = Dust.NewDust(P.position,P.width,P.height,5,P.velocity.X*-0.2f,P.velocity.Y*-0.2f,100,default(Color),1.2f);
             Main.dust[d].velocity*=2f;            
             Main.dust[d].noLight= true;
      }                                                                                 
}
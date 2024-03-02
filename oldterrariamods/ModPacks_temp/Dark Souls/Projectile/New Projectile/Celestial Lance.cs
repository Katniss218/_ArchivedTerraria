public void AI()
{
    projectile.AI(true);
	//for(int i=0;i<2;i++){
	//	if(Main.rand.Next(2) == 1){
	//		int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15,0 , 0, 150, default(Color), 1f);
	//		Main.dust[dust].velocity *= new Vector2(0.5f,0.5f);
	//	}else{
	//		int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 150, default(Color), 1.2f);
	//		Main.dust[dust].velocity *= new Vector2(0.2f,0.2f);
	//	}
	//}
	Lighting.addLight((int)((projectile.position.X + (float)projectile.width) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 0.8f, 0.7f, 0.1f);
}
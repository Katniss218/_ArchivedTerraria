public void DealtNPC(NPC npc, double damage, Player player)
{
	if (Main.rand.Next(8) == 0) //50% chance to occur
	{
		npc.AddBuff(24, 300, false);
	}
}

public void AI()
{
	

						Vector2 arg_23A6_0 = new Vector2(this.projectile.position.X, this.projectile.position.Y);
													int arg_23A6_1 = this.projectile.width;
													int arg_23A6_2 = this.projectile.height;
													int arg_23A6_3 = 6;
													float arg_23A6_4 = this.projectile.velocity.X * 0.2f;
													float arg_23A6_5 = this.projectile.velocity.Y * 0.2f;
													int arg_23A6_6 = 100;
													Color newColor = default(Color);
													int num44 = Dust.NewDust(arg_23A6_0, arg_23A6_1, arg_23A6_2, arg_23A6_3, arg_23A6_4, arg_23A6_5, arg_23A6_6, newColor, 3.5f);
													Main.dust[num44].noGravity = true;

	if (projectile.wet)
	{
	projectile.Kill();
	}
}





//public void AI(){

				
//if(this.projectile.timeLeft<120){
//this.projectile.active=false;
//if(this.projectile.velocity.Y<10){
//Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, this.projectile.velocity.X, -this.projectile.velocity.Y,  Config.projDefs.byName["FireSpirit"].type, (int) (this.projectile.damage), (int) (this.projectile.knockBack), 0);
//Main.NewText( " has awoken!", 175, 75, 255);
//}
//}

						//Vector2 arg_23A6_0 = new Vector2(this.projectile.position.X, this.projectile.position.Y);
						//							int arg_23A6_1 = this.projectile.width;
						//							int arg_23A6_2 = this.projectile.height;
						//							int arg_23A6_3 = 6;
						//							float arg_23A6_4 = this.projectile.velocity.X * 0.2f;
						//							float arg_23A6_5 = this.projectile.velocity.Y * 0.2f;
						//							int arg_23A6_6 = 100;
						//							Color newColor = default(Color);
						//							int num44 = Dust.NewDust(arg_23A6_0, arg_23A6_1, arg_23A6_2, arg_23A6_3, arg_23A6_4, arg_23A6_5, arg_23A6_6, newColor, 3.5f);
						//							Main.dust[num44].noGravity = true;
					

//					this.projectile.ai[0] += 1f;
				
				
//				this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X) + 1.57f;
//				if (this.projectile.velocity.Y > 16f)
//				{
//					this.projectile.velocity.Y = 16f;
//					return;
//				}
//}
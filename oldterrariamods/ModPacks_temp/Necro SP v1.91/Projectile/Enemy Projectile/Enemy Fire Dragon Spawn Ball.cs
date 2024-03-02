public void AI(){

				if (this.projectile.ai[1] == 0f)
				{
					Main.PlaySound(2, (int)this.projectile.position.X, (int)this.projectile.position.Y, 5);
					this.projectile.ai[1] = 1f;
				}
				
					this.projectile.ai[0] += 1f;


					if (this.projectile.ai[0] >= 20f)
					{
						this.projectile.ai[0] = 20f;
						this.projectile.velocity.Y = this.projectile.velocity.Y + 0.07f;
					}

				
				this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X) + 1.57f;
				if (this.projectile.velocity.Y > 16f)
				{
					this.projectile.velocity.Y = 16f;
					return;
				}

					Vector2 arg_244_01 = new Vector2(this.projectile.position.X, this.projectile.position.Y);
					int arg_244_11 = this.projectile.width;
					int arg_244_21 = this.projectile.height;
					int arg_244_31 = 6;
					float arg_244_41 = this.projectile.velocity.X * 0.2f;
					float arg_244_51 = this.projectile.velocity.Y * 0.2f;
					int arg_244_61 = 100;
					Color newColor2 = default(Color);
					int aa = Dust.NewDust(arg_244_01, arg_244_11, arg_244_21, arg_244_31, arg_244_41, arg_244_51, arg_244_61, newColor2, 1.7f);
					Main.dust[aa].noGravity = true;

}


public void Kill(){
int a = NPC.NewNPC((int)this.projectile.position.X,(int) this.projectile.position.Y-30, Config.npcDefs.byName["Fire Dragon"].type, 0);
this.projectile.active=false;

}
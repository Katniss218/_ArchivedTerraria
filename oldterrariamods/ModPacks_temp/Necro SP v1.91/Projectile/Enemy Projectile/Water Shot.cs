public void AI()
{
    projectile.frameCounter++;
    if (projectile.frameCounter > 3)
    {
        projectile.frame++;
        projectile.frameCounter = 0;
    }
    if (projectile.frame >= 5)
    {
        projectile.frame = 0;
        return;
    }
						    Vector2 arg_1B0_0 = this.projectile.position;
							int arg_1B0_1 = this.projectile.width;
							int arg_1B0_2 = this.projectile.height;
							int arg_1B0_3 = 13;
                            if(Main.rand.Next(3)==0){
                            arg_1B0_3 = 33;
                            }

                            if(Main.rand.Next(3)==0){
                            arg_1B0_3 = 63;
                            }

							float arg_1B0_4 = 0f;
							float arg_1B0_5 = 0f;
							int arg_1B0_6 = 0;
							Color newColor = default(Color);

							int num2 = Dust.NewDust(arg_1B0_0, arg_1B0_1, arg_1B0_2, arg_1B0_3, arg_1B0_4, arg_1B0_5, arg_1B0_6, newColor, 2f);
							if (Main.rand.Next(2) == 0)
							{
							Main.dust[num2].noGravity = true;
                            }

    Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
    Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);
    if (projrec.Intersects(prec))
    {
    Main.player[Main.myPlayer].AddBuff("Freezing", 300, true);
    }
}
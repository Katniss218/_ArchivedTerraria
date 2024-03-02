public void AI()
{
                            Vector2 arg_1B0_0 = this.projectile.position;
							int arg_1B0_1 = this.projectile.width;
							int arg_1B0_2 = this.projectile.height;
							int arg_1B0_3 = 13;
							float arg_1B0_4 = 0f;
							float arg_1B0_5 = 0f;
							int arg_1B0_6 = 0;
							Color newColor = default(Color);

							int num2 = Dust.NewDust(arg_1B0_0, arg_1B0_1, arg_1B0_2, arg_1B0_3, arg_1B0_4, arg_1B0_5, arg_1B0_6, newColor, 1f);
							if (Main.rand.Next(2) == 0)
							Main.dust[num2].noGravity = true;
}
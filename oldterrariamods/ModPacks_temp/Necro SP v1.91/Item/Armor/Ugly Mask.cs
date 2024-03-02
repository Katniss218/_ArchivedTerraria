public void Effects(Player player){
for(int i=0; i< 4; i++){
int maxValue = 1;
				float num = (float)Main.screenWidth / 1920f;
				int num2 = (int)(500f * num);
				if ((float)Main.snowDust < (float)num2 * (Main.gfxQuality / 2f + 0.5f) + (float)num2 * 0.1f && Main.rand.Next(maxValue) == 0)
				{
					int num3 = Main.rand.Next(Main.screenWidth + 1000) - 500;
					int num4 = (int)Main.screenPosition.Y;
					if (Main.rand.Next(5) == 0)
					{
						num3 = Main.rand.Next(500) - 500;
					}
					else
					{
						if (Main.rand.Next(5) == 0)
						{
							num3 = Main.rand.Next(500) + Main.screenWidth;
						}
					}
					if (num3 < 0 || num3 > Main.screenWidth)
					{
						num4 += Main.rand.Next((int)((double)Main.screenHeight * 0.5)) + (int)((double)Main.screenHeight * 0.1);
					}
					num3 += (int)Main.screenPosition.X;
					int num5 = Dust.NewDust(new Vector2((float)num3, (float)num4), 100, 0, 0, 0.4f, 0.1f, 5, Color.Red, 1.0f);
					Main.dust[num5].velocity.Y = 2f + (float)Main.rand.Next(30) * 0.1f;
					Dust expr_1BD_cp_0 = Main.dust[num5];
					expr_1BD_cp_0.velocity.Y = expr_1BD_cp_0.velocity.Y * Main.dust[num5].scale;
					Main.dust[num5].velocity.X = Main.windSpeed + (float)Main.rand.Next(10) * 2f;
				}
}
}

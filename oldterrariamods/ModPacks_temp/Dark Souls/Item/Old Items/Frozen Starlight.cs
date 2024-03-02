public static void Effects(Player player)
{
						int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
						int j2 = (int)(player.position.Y + 2f) / 16;
						Lighting.addLight(i2, j2, 0.25f, 0.25f, 1.5f);
}
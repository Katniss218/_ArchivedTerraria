public void Effects(Player player)
{
	int i2 = (int)((Main.mouseX + Main.screenPosition.X) / 16);
	int j2 = (int)((Main.mouseY + Main.screenPosition.Y) / 16);
	Lighting.addLight(i2,j2,2.5f,2.5f,2.5f);
}
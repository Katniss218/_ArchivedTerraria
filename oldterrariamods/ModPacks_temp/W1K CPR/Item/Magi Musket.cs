public void UseItem(Player player, int playerID)
{
	if (playerID == Main.myPlayer)
	{
	int Musket = -1;
	if ((player.position.X + (player.width/2)) < (Main.mouseX + Main.screenPosition.X))
	{
	player.direction = 1;
	Musket = Projectile.NewProjectile(
    	(float) (player.position.X + (player.width/2))-7-40-Main.rand.Next(40),
    	(float) (player.position.Y + (player.height/2))-Main.rand.Next(-20,40),
    	0,
    	0,
    	"MagiMusket", //Type
    	(int) (item.damage*player.magicDamage), //Damage
    	2.0f,
    	playerID
    );
	}
	else
	{
	player.direction = -1;
	Musket = Projectile.NewProjectile(
    	(float) (player.position.X + (player.width/2))-7+40+Main.rand.Next(40),
    	(float) (player.position.Y + (player.height/2))-Main.rand.Next(-20,40),
    	0,
    	0,
    	"MagiMusket", //Type
    	(int) (item.damage*player.magicDamage), //Damage
    	item.knockBack,
    	playerID
    );
	}
	if ((Main.projectile[Musket].position.X + (Main.projectile[Musket].width/2)) > (Main.mouseX + Main.screenPosition.X))
	{
		Main.projectile[Musket].rotation = (float) Math.Atan2((Main.mouseY + Main.screenPosition.Y)-(Main.projectile[Musket].position.Y + Main.projectile[Musket].height * 0.5f),(Main.mouseX + Main.screenPosition.X) - (Main.projectile[Musket].position.X + Main.projectile[Musket].width * 0.5f));
	}
	else
	{
		Main.projectile[Musket].rotation = (float) Math.Atan2((Main.mouseY + Main.screenPosition.Y)-(Main.projectile[Musket].position.Y + Main.projectile[Musket].height * 0.5f),(Main.mouseX + Main.screenPosition.X) - (Main.projectile[Musket].position.X + Main.projectile[Musket].width * 0.5f));
		//Main.projectile[Musket].rotation = (float) Math.Atan2((Main.projectile[Musket].position.Y + Main.projectile[Musket].height * 0.5f)-(Main.mouseY + Main.screenPosition.Y),(Main.projectile[Musket].position.X + Main.projectile[Musket].width * 0.5f)-(Main.mouseX + Main.screenPosition.X));
	}
	NetMessage.SendData(27, -1, -1, "", Musket, 0f, 0f, 0f, 0);
	}
}
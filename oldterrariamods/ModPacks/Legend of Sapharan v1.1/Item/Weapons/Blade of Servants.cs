public static void UseItem(Player player, int playerID)
{
    Projectile.NewProjectile(
    (float) (Main.mouseX + Main.screenPosition.X)-100+Main.rand.Next(200),
    (float) (Main.mouseY + Main.screenPosition.Y)-500.0f,
    (float) (-40+Main.rand.Next(80))/10,
    14.9f,
    Config.projectileID["Eye"],
    10,
    3.0f,
    playerID);

    Projectile.NewProjectile(
    (float) (Main.mouseX + Main.screenPosition.X)-100+Main.rand.Next(200),
    (float) (Main.mouseY + Main.screenPosition.Y)-500.0f,
    (float) (-40+Main.rand.Next(80))/10,
    14.9f,
    Config.projectileID["Eye"],
    10,
    3.0f,
    playerID);

    Projectile.NewProjectile(
    (float) (Main.mouseX + Main.screenPosition.X)-100+Main.rand.Next(200),
    (float) (Main.mouseY + Main.screenPosition.Y)-500.0f,
    (float) (-40+Main.rand.Next(80))/10,
    14.9f,
    Config.projectileID["Eye"],
    10,
    3.0f,
    playerID);
	
	Projectile.NewProjectile(
    (float) (Main.mouseX + Main.screenPosition.X)-100+Main.rand.Next(200),
    (float) (Main.mouseY + Main.screenPosition.Y)-500.0f,
    (float) (-40+Main.rand.Next(80))/10,
    14.9f,
    Config.projectileID["Eye"],
    10,
    3.0f,
    playerID);
	
	Projectile.NewProjectile(
    (float) (Main.mouseX + Main.screenPosition.X)-100+Main.rand.Next(200),
    (float) (Main.mouseY + Main.screenPosition.Y)-500.0f,
    (float) (-40+Main.rand.Next(80))/10,
    14.9f,
    Config.projectileID["Eye"],
    10,
    3.0f,
    playerID);
}
public void UseItem(Player player, int playerID)
{
    if (playerID == Main.myPlayer)
    {
        if (Main.rand.Next(4) == 0)
        {
        Projectile.NewProjectile(
        (float) (Main.mouseX + Main.screenPosition.X)-100+Main.rand.Next(200),
        (float) (Main.mouseY + Main.screenPosition.Y)-500.0f,
        (float) (-40+Main.rand.Next(80))/10,
        14.9f,
        Config.projectileID["Spell Meteor"], //Type
        50, //Damage
        2.0f,
        playerID);
        }
    }
}
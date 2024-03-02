public void UseItem(Player player, int playerID)
{
    if (playerID == Main.myPlayer)
    {
        if (Main.rand.Next(10) == 0)
        {
            Projectile.NewProjectile(
            (float) (player.position.X),
            (float) (player.position.Y),
            (float) (-40+Main.rand.Next(80))/10,
            14.9f,
            Config.projectileID["Spell Fire 2 Ball"], //Type
            20, //Damage
            2.0f,
            playerID);
        }
    }
}
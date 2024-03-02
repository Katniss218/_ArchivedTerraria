#region AI
public void AI()
{
	projectile.rotation++;
    int dust = Dust.NewDust(this.projectile.position, 108, 180, 64, Main.rand.Next(10)-5, Main.rand.Next(10)-5, 100, Color.Red, 2.0f);
    Main.dust[dust].noGravity = true;
    Main.dust[dust].rotation = this.projectile.rotation;

	if (projectile.velocity.X <= 10 && projectile.velocity.Y <= 10 && projectile.velocity.X >= -10 && projectile.velocity.Y >= -10)
	{
	projectile.velocity.X *= 1.01f;
	projectile.velocity.Y *= 1.01f;
	}


        Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
        Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);
        if (projrec.Intersects(prec))
        {
        Main.player[Main.myPlayer].AddBuff(30, 300, false);
        Main.player[Main.myPlayer].AddBuff(13, 900, false);
        }
}
#endregion
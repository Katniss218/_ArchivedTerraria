public void AI()
{
	projectile.rotation++;
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 100, Color.Red, 2.0f);
	Main.dust[dust].noGravity = true;

	if (projectile.velocity.X <= 10 && projectile.velocity.Y <= 10 && projectile.velocity.X >= -10 && projectile.velocity.Y >= -10)
	{
	projectile.velocity.X *= 1.01f;
	projectile.velocity.Y *= 1.01f;
	}

Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

if (projrec.Intersects(prec) && Main.rand.Next(2)==0)
{
	Main.player[Main.myPlayer].AddBuff(36, 120, false); //broken armor
	Main.player[Main.myPlayer].AddBuff(33, 600, false); //weak
	Main.player[Main.myPlayer].AddBuff(24, 180, false); //on fire!
}

if (projrec.Intersects(prec) && Main.rand.Next(8)==0)
{
	Main.player[Main.myPlayer].AddBuff("Curse Buildup", 3600, false);
	Main.player[Main.myPlayer].AddBuff("Fracturing Armor", 1800, false);
		
}

}
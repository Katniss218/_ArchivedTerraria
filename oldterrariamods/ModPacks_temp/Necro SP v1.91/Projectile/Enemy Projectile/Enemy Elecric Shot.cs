#region AI
public void AI()
{
	projectile.rotation++;
    Projectile P = projectile;
    Vector2 PC = P.position+new Vector2(P.width/2,P.height/2);
    if(P.wet)P.Kill();
    int DustIndex = Dust.NewDust(
    new Vector2(P.position.X + P.velocity.X, P.position.Y + P.velocity.Y), 
    P.width, 
    P.height, 
    57, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 0.2f, 100, default(Color), 1.5f);
    Main.dust[DustIndex].noGravity = true;
    P.rotation = (float)Math.Atan2((double)P.velocity.Y, (double)P.velocity.X) + (float)(Math.PI/2);

	if (projectile.velocity.X <= 10 && projectile.velocity.Y <= 10 && projectile.velocity.X >= -10 && projectile.velocity.Y >= -10)
	{
	projectile.velocity.X *= 1.01f;
	projectile.velocity.Y *= 1.01f;
	}


        Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
        Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);
        if (projrec.Intersects(prec))
        {
        Main.player[Main.myPlayer].AddBuff(33, 300, false);
        Main.player[Main.myPlayer].AddBuff(37, 300, false);
        }
}
#endregion
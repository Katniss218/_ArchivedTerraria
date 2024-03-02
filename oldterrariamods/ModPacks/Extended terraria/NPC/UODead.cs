//public class Ultrablivion_NPC
//{
    int CD = 0;
    public void AI()
    {
        npc.alpha++;
        CD++;
        if (CD > 20)
        {
            Vector2 PM = new Vector2(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2);
            Main.projectile[Projectile.NewProjectile(PM.X, PM.Y, 0f, 0f, 30, 0, 0f, 255)].Kill();
            CD = 0;
        }
        if (npc.alpha > 254)
        {
            npc.life = 0;
            npc.active = false;
            npc.NPCLoot();
        }
    }
    public void NPCLoot()
    {
        NPC N = npc;
        Rectangle R = new Rectangle((int)N.position.X, (int)(N.position.Y + ((N.height - N.width) / 2)), N.width, N.width);
	    int C = 50;
	    float vR = .4f;
	    for (int i = 1; i <= C; i++)
	    {
		    int d = Dust.NewDust(N.position, R.Width, R.Height, 54, 0, 0, 100, new Color(), 2f);
            Dust D = Main.dust[d];
		    D.noGravity = true;
		    D.velocity.X = vR * (D.position.X - (N.position.X + (N.width / 2)));
		    D.velocity.Y = vR * (D.position.Y - (N.position.Y + (N.height / 2)));
        }
	    for (int i2 = 1; i2 <= C; i2++)
	    {
		    int d = Dust.NewDust(N.position, R.Width, R.Height, -1, 0, 0, 100, new Color(), 2f);
            Dust D = Main.dust[d];
		    D.noGravity = true;
		    D.velocity.X = vR * (D.position.X - (N.position.X + (N.width / 2)));
		    D.velocity.Y = vR * (D.position.Y - (N.position.Y + (N.height / 2)));
        }
	    for (int i2 = 1; i2 <= C; i2++)
	    {
		    int d = Dust.NewDust(N.position, R.Width, R.Height, 15, 0, 0, 100, new Color(), 2f);
            Dust D = Main.dust[d];
		    D.noGravity = true;
		    D.velocity.X = vR * (D.position.X - (N.position.X + (N.width / 2)));
		    D.velocity.Y = vR * (D.position.Y - (N.position.Y + (N.height / 2)));
        }
        //ModWorld.Berseker();
    }
//}
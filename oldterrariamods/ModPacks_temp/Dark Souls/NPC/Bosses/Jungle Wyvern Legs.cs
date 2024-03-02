public void AI()
{
npc.TargetClosest(true);


if (!Main.npc[(int)npc.ai[1]].active)
{
    npc.life = 0;
for (int num36 = 0; num36 < 50; num36++)
{



int pdust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y-30), npc.width, npc.height, 62, 0, 0, 100, Color.Red, 6.0f);
Main.dust[pdust].noGravity = true;	



}
    npc.HitEffect(0, 10.0);
    npc.active = false;
}
if (npc.position.X > Main.npc[(int)npc.ai[1]].position.X)
{
	npc.spriteDirection = 1;
}
if (npc.position.X < Main.npc[(int)npc.ai[1]].position.X)
{
	npc.spriteDirection = -1;
}
Color color = new Color();
int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 100, color, 1.0f);
Main.dust[dust].noGravity = true;

npc.AI(true);
}




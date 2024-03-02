public void Effects(Player player)

{

if (player.controlRight)
{
int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width-20, player.height, 6, 0, 0, 100, Color.White, 2f);
        Main.dust[dust].noGravity = true;
}
if (player.controlLeft)
{
int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width+20, player.height, 6, 0, 0, 100, Color.White, 2f);
        Main.dust[dust].noGravity = true;
}
if (player.controlJump)
{
int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width+20, player.height+20, 6, 0, 0, 100, Color.White, 2f);
        Main.dust[dust].noGravity = true;
}
}
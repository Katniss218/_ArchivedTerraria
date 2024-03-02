int timer=0;

public void Effects(Player player)

{
timer++;

if (timer == 1){
int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width-20, player.height, 14, 0, 0, 100, Color.White, 2f);
        Main.dust[dust].noGravity = true;
timer = 0;
}

if (player.controlRight)
{
int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width-20, player.height, 27, 0, 0, 100, Color.White, 2f);
        Main.dust[dust].noGravity = true;
}
if (player.controlLeft)
{
int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width+20, player.height, 27, 0, 0, 100, Color.White, 2f);
        Main.dust[dust].noGravity = true;
}
if (player.controlJump)
{
int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width+20, player.height+20, 27, 0, 0, 100, Color.White, 2f);
        Main.dust[dust].noGravity = true;
}
}
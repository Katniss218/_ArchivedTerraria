public void Save(BinaryWriter W)
{
     W.Write(item.toolTip);
}
public void Load(BinaryReader R,int v)
{
    item.toolTip = R.ReadString();
}

public void Initialize() {
	item.toolTip = "Hello, my name is " + Main.player[Main.myPlayer].name + ".";
	}

public void UseItemEffect(Player player, Rectangle rectangle) {
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 72, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 1000, color, 1.5f);
	Main.dust[dust].noGravity = true;
	}
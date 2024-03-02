public void Effects(Player P)
{
	P.rangedDamage += 0.35f;
}
public bool UseAmmo(Player P, int shoot, Item consumed) { return new Random().Next(10) != 0; }
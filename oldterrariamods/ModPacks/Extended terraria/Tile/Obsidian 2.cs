int
    X = 0,
    Y = 0,
    count = 0;

public void Initialize(int x, int y)
{
	X = x;
	Y = y;
}
public void Update()
{
	count++;
	if (count >= 420)
	{
		WorldGen.KillTile(X, Y, false, false, false);
	}
}
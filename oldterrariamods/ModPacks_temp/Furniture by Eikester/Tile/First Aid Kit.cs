public int counter = 0;
int x; 
int y;

public void Initialize(int _x, int _y)
{
	x = _x;
	y = _y;
}

public void UseTile(Player player, int x, int y)
{
	if(counter>0 && player.statLife<40)
	{
		Main.NewText("You can't use this atm, please wait a moment!", 255, 10, 10);
		return;
	}
	
	if(player.statLife>40)
	{
		Main.NewText("You are in a good condition!", 10, 255, 10);
		return;
	}
		
	if(player.statLife<40 && player.statLifeMax>40)
	{
		player.statLife+=20;
		counter=1000;
	}
}

public void Update()
{
	counter-=1;
	
	if(counter < 0)
		counter=0;
}
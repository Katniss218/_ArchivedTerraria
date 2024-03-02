public bool textShown = false;
int x,y;

public void Initialize(int _x, int _y)
{
	x = _x;
	y = _y;
}

public string GetTimeOfDay()
{
	string text12 = "AM";
	double num145 = Main.time;
	if (!Main.dayTime)
	{
		num145 += 54000.0;
	}
	num145 = num145 / 86400.0 * 24.0;
	double num146 = 7.5;
	num145 = num145 - num146 - 12.0;
	if (num145 < 0.0)
	{
		num145 += 24.0;
	}
	if (num145 >= 12.0)
	{
		text12 = "PM";
	}
	int num147 = (int)num145;
	double num148 = num145 - (double)num147;
	num148 = (double)((int)(num148 * 60.0));
	string text13 = string.Concat(num148);
	if (num148 < 10.0)
	{
		text13 = "0" + text13;
	}
	if (num147 > 12)
	{
		num147 -= 12;
	}
	if (num147 == 0)
	{
		num147 = 12;
	}
	
	text13 = "00";
	
	string text11 = string.Concat(new object[]
	{
		"Time: ", 
		num147, 
		":", 
		text13, 
		" ", 
		text12
	});
	
	textShown=false;
	
	return text11;
}

public void UseTile(Player player, int x, int y)
{
	Main.NewText(GetTimeOfDay(), 255, 215, 0);
}

public void Update()
{
	if(SoundHandler.customSoundInstance[SoundHandler.soundID["Kuckucksuhrloop"]].State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
		Main.PlaySound(2,x*16,y*16,SoundHandler.soundID["Kuckucksuhrloop"]);

	if( (Main.dayTime && (Main.time >= 26990.0f && Main.time <= 27010.0f) ) ||
		(!Main.dayTime && (Main.time >= 16190.0f && Main.time <= 16210.0f) ) )
	{
		if(SoundHandler.customSoundInstance[SoundHandler.soundID["Kuckucksuhralarm"]].State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
			Main.PlaySound(2,x*16,y*16,SoundHandler.soundID["Kuckucksuhralarm"]);
			
		if(textShown == false && ((Main.dayTime && Main.time == 27000f) || (!Main.dayTime && Main.time == 16200f)))
		{
			Main.NewText(GetTimeOfDay(), 255, 215, 0);
			textShown=true;
		}
	}
}
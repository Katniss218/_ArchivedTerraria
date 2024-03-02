public void UseTile(Player player, int x, int y)
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
	
	string text11 = string.Concat(new object[]
	{
		"Time: ", 
		num147, 
		":", 
		text13, 
		" ", 
		text12
	});
	
	Main.NewText(text11, 255, 215, 0);
}

public static void AddLight(int i, int j, ref float R, ref float G, ref float B)
{	
	if(Main.tile[i, j].frameNumber == 0)
	{
		R = .1f; 
		G = 1.05f;
		B = .97f;
	}
}
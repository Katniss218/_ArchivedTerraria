public void AddLight(int i, int j, ref float R, ref float G, ref float B)
{	
	if(Main.tile[i, j].frameNumber == 0)
	{
		R = .42f; 
		G = .81f;
		B = .52f;
	}
}
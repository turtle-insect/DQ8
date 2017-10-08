namespace DQ8
{
	class Util
	{
		public static uint BlockSize = 0x10B78;
		public static uint ItemCount = 430;
		public static uint ItemAddress = 0x0ADC;

		public static void WriteNumber(uint address, uint size, uint value, uint min, uint max)
		{
			if (value < min) value = min;
			if (value > max) value = max;
			SaveData.Instance().WriteNumber(address, size, value);
		}
	}
}

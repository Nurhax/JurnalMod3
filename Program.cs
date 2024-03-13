public class KodeBuah
{
    public enum namaBuah
    {
        Apel, Aprikot, Alpukat, Pisang, Paprika, Blackberry,
        Ceri, Kelapa, Jagung, Kurma, Durian, Anggur, Melon, Semangka
    }

    public static string getKodeBuah(namaBuah buah)
    {
        string[] KodeBuah = {"A00","B00","C00","D00","E00","F00"
                ,"H00","I00","J00","K00","L00","M00","N00","O00"};
        return KodeBuah[(int)buah];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        KodeBuah.namaBuah namaBuah = KodeBuah.namaBuah.Semangka;
        string Buah = KodeBuah.getKodeBuah(namaBuah);
        Console.WriteLine("Nama Buah:" + namaBuah);
        Console.WriteLine("Kode Buah:" + Buah);
    }
}
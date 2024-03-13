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

public class PosisiKarakterGame
{
    //NIM = 1302223050
    // NIM % 3 = 0
    public enum StatePemain {Berdiri,Jongkok,Tengkurap,Terbang};
    public enum Trigger {TombolW,TombolS,TombolX};

    public StatePemain currentState = StatePemain.Berdiri;


    public class Transisi
    {
        public StatePemain stateAwal;
        public StatePemain stateAkhir;
        public Trigger trigger;
        public Transisi(StatePemain stateAwal, StatePemain stateAkhir, Trigger trigger)
        {
            this.stateAwal = stateAwal;
            this.stateAkhir = stateAkhir;
            this.trigger = trigger;
        }
    }

    Transisi[] Transition =
        {
            new Transisi(StatePemain.Berdiri, StatePemain.Jongkok, Trigger.TombolS),
            new Transisi(StatePemain.Jongkok, StatePemain.Berdiri, Trigger.TombolW),
            new Transisi(StatePemain.Berdiri, StatePemain.Terbang, Trigger.TombolW),
            new Transisi(StatePemain.Terbang, StatePemain.Berdiri, Trigger.TombolS),
            new Transisi(StatePemain.Terbang, StatePemain.Jongkok, Trigger.TombolX),
            new Transisi(StatePemain.Jongkok, StatePemain.Tengkurap, Trigger.TombolS),
            new Transisi(StatePemain.Tengkurap, StatePemain.Jongkok, Trigger.TombolW)
        };

    public StatePemain getNextStatePemain(StatePemain stateAwal, Trigger trigger)
    {
        StatePemain stateAkhir = stateAwal;
        for (int i = 0; i < Transition.Length; i++)
        {
            Transisi perubahan = Transition[i];
            if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
            {
                stateAkhir = perubahan.stateAkhir;
            }
        }
        return stateAkhir;
    }

    public void ActivateTrigger(Trigger trigger)
    {
        currentState = getNextStatePemain(currentState, trigger);
        Console.WriteLine();
        if(trigger == Trigger.TombolS)
        {
            Console.WriteLine("tombol arah bawah ditekan");
        }else if(trigger == Trigger.TombolW)
        {
            Console.WriteLine("tombol arah atas ditekan");
        }

        Console.WriteLine("Saat ini pemain sedang:" + currentState);
    }


}


public class Program
{
    public static void Main(string[] args)
    {
        //Table driven construction
        KodeBuah.namaBuah namaBuah = KodeBuah.namaBuah.Apel;
        string Buah = KodeBuah.getKodeBuah(namaBuah);
        int i = 0;
        for(i = 0; i < 13; i++)
        {
            Console.WriteLine("Nama Buah:" + namaBuah);
            Console.WriteLine("Kode Buah:" + Buah);
            Console.WriteLine();
            namaBuah++;
            Buah = KodeBuah.getKodeBuah(namaBuah);
        }

        //State driven construction
        PosisiKarakterGame Pemain = new PosisiKarakterGame();
        Console.WriteLine("Kondisi pemain saat ini: " + Pemain.currentState);
        Pemain.ActivateTrigger(PosisiKarakterGame.Trigger.TombolW);
        Pemain.ActivateTrigger(PosisiKarakterGame.Trigger.TombolS);
        
    }


}
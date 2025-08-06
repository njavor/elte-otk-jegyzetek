/*
* Be: diakdb ∈ N, atlagok ∈ R[1..diakdb]
* Sa: neotosdb ∈ N, neotosok ∈ R[1..neotosdb]
* Ki: osztalyatlag ∈ R    // 4,5 és afeletti átlagok nélküli átlag
* Ef: ∀i ∈ [1..diakdb]: (1 ≤ atlagok[i] ≤ 5)
* Uf: (neotosdb, neotosok) = KIVÁLOGAT(i=1..diakdb, atlagok[i] < 4.5, atlagok[i])
*     és osztalyatlag=SZUM(i=1..neotosdb, neotosok[i])/neotosdb
*
* Visszavezetés
*     db ~ neotosdb
*     kivelemek ~ neotosok
*     1..elemszám ~ 1..diakdb
*     T(elemek[i]) ~ atlagok[i] < 4.5
*     elemek[i] ~ atlagok[i]
* 
*     össz ~ osztalyatlag
*     1..elemszám ~ 1..neotosdb
*     elemek[i] ~ neotosok[i]
* 
* Algoritmus
*     Változó:
*         i: Egész
*     neotosdb := 0
*     osztalyatlag := 0
*     Ciklus i=1-től diakdb-ig
*         Ha atlagok[i]<4.5 akkor
*             neotosdb := neotosdb + 1
*             osztalyatlag := osztalyatlag + atlagok[i]
*         Elágazás vége
*     Ciklus vége
*     osztalyatlag := osztalyatlag / neotosdb
*/
namespace osszeepites_pelda
{
    internal class Program
    {
        static int BeEgesz(string sorszoveg, int minert, int maxert, string errorszoveg)
        {
            int res;
            bool hiba;
            do
            {
                Console.Write(sorszoveg);
                hiba = !int.TryParse(Console.ReadLine(), out res) || res < minert || res > maxert;
                if (hiba)
                {
                    Console.WriteLine("Hiba! " + errorszoveg);
                }
            } while (hiba);
            return res;
        }
        
        static void Main(string[] args)
        {
            int diakdb = BeEgesz("diakdb: ", 0, int.MaxValue(), "Nem negatív egész számot adj meg!");
            double[] atlagok = new double[diakdb];
            for(int i=0; i<diakdb; i++)
            {
                atlagok[i] = BeEgesz($"atlagok[{i+1}]: ", 1, 5, "1 és 5 közötti valós számot adj meg!")
            }

            int neotosdb = 0, osztalyatlag = 0;
            for(int i=0; i<diakdb; i++)
            {
                if(atlagok[i] < 4.5)
                {
                    neotosdb++;
                    osztalyatlag += atlagok[i];
                }
            }
            osztalyatlag /= neotosdb;
            Console.WriteLine($"Az ötös tanulók nélküli osztályátlag: {osztalyatlag}")
        }
    }
}

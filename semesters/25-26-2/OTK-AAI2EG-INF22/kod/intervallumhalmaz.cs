class IntervallumHalmaz
{
    int MaxDb = 100;
    int db;
    int[] kezd;
    int[] veg;

    public IntervallumHalmaz()
    {
        db = 0;
        kezd = new int[MaxDb];
        veg = new int[MaxDb];
    }
    public IntervallumHalmaz(int db, int[] kezd, int[] veg)
    {
        this.db = db;
        this.kezd = kezd;
        this.veg = veg;
    }


    public void Beolvasas()
    {
        db = int.Parse(Console.ReadLine());
        for (int i = 0; i < db; i++)
        {
            string[] sor = Console.ReadLine().Split();
            kezd[i] = int.Parse(sor[0]);
            veg[i] = int.Parse(sor[1]);
        }
    }
    public void Kiiras()
    {
        Console.WriteLine(db);
        for (int i = 0; i < db; i++)
        {
            Console.WriteLine(kezd[i] + " " + veg[i]);
        }
    }
    

    public void Intervallumhalmazba(int kezd, int veg)
    {
        this.kezd[db] = kezd;
        this.veg[db] = veg;
        db++;
    }
    public void Multihalmazbol(int kezd, int veg)
    {
        // tudú
    }
    public void Urites()
    {
        db = 0;
    }
    

    public bool ElemeE(int ertek)
    {
        int i = 0;
        while (i < db && (ertek < kezd[i] || ertek > veg[i])) i++;
        return i < db;
    }
    public bool UresE()
    {
        return db == 0;
    }
    

    public IntervallumHalmaz Unio(IntervallumHalmaz masik)
    {
        if (db == 0) return masik;
        if (masik.db == 0) return this;
        IntervallumHalmaz unio = new IntervallumHalmaz();
        int udb = 0;
        int i = 0;
        int j = 0;

        int akt_kezd;
        int akt_veg;

        if (kezd[i] < masik.kezd[j])
        {
            akt_kezd = kezd[i];
            akt_veg = veg[i];
            i++;
        }
        else
        {
            akt_kezd = masik.kezd[j];
            akt_veg = masik.veg[j];
            j++;
        }

        while (i < db && j < masik.db)
        {
            if (kezd[i] < masik.kezd[j])
            {
                if (akt_veg < kezd[i])
                {
                    unio.kezd[udb] = akt_kezd;
                    unio.veg[udb] = akt_veg;
                    udb++;

                    akt_kezd = kezd[i];
                    akt_veg = veg[i];
                    i++;
                }
                else
                {
                    akt_veg = Math.Max(akt_veg, veg[i]);
                    i++;
                }
            }
            else
            {
                if (akt_veg < masik.kezd[j])
                {
                    unio.kezd[udb] = akt_kezd;
                    unio.veg[udb] = akt_veg;
                    udb++;

                    akt_kezd = masik.kezd[j];
                    akt_veg = masik.veg[j];
                    j++;
                }
                else
                {
                    akt_veg = Math.Max(akt_veg, masik.veg[j]);
                    j++;
                }
            }
        }
        while (i < db)
        {
            if (akt_veg < kezd[i])
            {
                unio.kezd[udb] = akt_kezd;
                unio.veg[udb] = akt_veg;
                udb++;

                akt_kezd = kezd[i];
                akt_veg = veg[i];
                i++;
            }
            else
            {
                akt_veg = Math.Max(akt_veg, veg[i]);
                i++;
            }
        }
        while (j < masik.db)
        {
            if (akt_veg < masik.kezd[j])
            {
                unio.kezd[udb] = akt_kezd;
                unio.veg[udb] = akt_veg;
                udb++;

                akt_kezd = masik.kezd[j];
                akt_veg = masik.veg[j];
                j++;
            }
            else
            {
                akt_veg = Math.Max(akt_veg, masik.veg[j]);
                j++;
            }
        }

        unio.kezd[udb] = akt_kezd;
        unio.veg[udb] = akt_veg;
        udb++;

        unio.db = udb;
        return unio;
    }
    public IntervallumHalmaz Metszet(IntervallumHalmaz masik)
    {
        IntervallumHalmaz metszet = new IntervallumHalmaz();
        int mdb = 0;
        int i = 0;
        int j = 0;
        while (i < db && j < masik.db)
        {
            if (veg[i] < masik.kezd[j]) { i++; }
            else if (kezd[i] > masik.veg[j]) { j++; }
            else
            {
                metszet.kezd[mdb] = Math.Max(kezd[i], masik.kezd[j]);
                metszet.veg[mdb] = Math.Min(veg[i], masik.veg[j]);
                mdb++;
                if (veg[i] < masik.veg[j]) { i++; }
                else if (masik.veg[j] < veg[i]) { j++; }
                else
                {
                    i++;
                    j++;
                }
            }
        }
        metszet.db = mdb;
        return metszet;
    }
    public IntervallumHalmaz Komplementer(IntervallumHalmaz masik)
    {
        IntervallumHalmaz komplementer = new IntervallumHalmaz();
        if (db == 0) komplementer = komplementer.Unio(new IntervallumHalmaz(1, new int[] { 1 }, new int[] { 10 }));
        else
        {
            if (kezd[0] > k) komplementer.Intervallumhalmazba(k, kezd[0] - 1);
            for (int i = 0; i < db - 1; i++)
            {
                if (kezd[i + 1] - veg[i] > 1) komplementer.Intervallumhalmazba(veg[i] + 1, kezd[i + 1] - 1);
            }
            if (veg[db - 1] < v) komplementer.Intervallumhalmazba(veg[db - 1] + 1, v);
        }
        return komplementer;
    }
}
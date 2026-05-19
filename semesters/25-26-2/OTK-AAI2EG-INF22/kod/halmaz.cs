class Halmaz
{
    int MaxDb = 100;
    int db;
    int[] elemek;

    public Halmaz()
    {
        db = 0;
        elemek = new int[MaxDb];
    }

    public void Beolvasas()
    {
        db = int.Parse(Console.ReadLine());
        for (int i = 0; i < db; i++)
        {
            elemek[i] = int.Parse(Console.ReadLine());
        }
    }
    public void Kiiras()
    {
        Console.WriteLine(db);
        for (int i = 0; i < db; i++)
        {
            Console.Write(elemek[i] + " ");
        }
        Console.WriteLine();
    }


    public void Halmazba(int elem)
    {
        if (!ElemeE(elem))
        {
            elemek[db] = elem;
            db++;
        }
    }
    public void Halmazbol(int elem)
    {
        int i = 0;
        while (i < db && elemek[i] != elem) i++;
        if (i < db)
        {
            elemek[i] = elemek[db - 1];
            db--;
        }
    }
    public void Urites()
    {
        db = 0;
    }


    public bool ElemeE(int elem)
    {
        int i = 0;
        while (i < db && elemek[i] != elem) i++;
        return i < db;
    }
    public bool UresE()
    {
        return db == 0;
    }
    public bool ReszeE(Halmaz masik)
    {
        if (masik.db < this.db) return false;

        int i = 0;
        while (i < db && masik.ElemeE(elemek[i])) i++;
        return i >= db;
    }
    public bool EgyenloE(Halmaz masik)
    {
        if (db != masik.db) return false;
        for (int i = 0; i < db; i++)
        {
            if (!masik.ElemeE(elemek[i])) return false;
        }
        return true;
    }


    public Halmaz Unio(Halmaz masik)
    {
        Halmaz unio = new Halmaz();
        for (int i = 0; i < this.db; i++) unio.Halmazba(this.elemek[i]);
        for (int i = 0; i < masik.db; i++) unio.Halmazba(masik.elemek[i]);
        return unio;
    }
    public Halmaz Metszet(Halmaz masik)
    {
        Halmaz metszet = new Halmaz();
        for (int i = 0; i < this.db; i++)
        {
            if (masik.ElemeE(elemek[i])) metszet.Halmazba(elemek[i]);
        }
        return metszet;
    }
    public Halmaz Kulonbseg(Halmaz masik)
    {
        Halmaz kulonbseg = new Halmaz();
        for (int i = 0; i < this.db; i++)
        {
            if (!masik.ElemeE(elemek[i])) kulonbseg.Halmazba(elemek[i]);
        }
        return kulonbseg;
    }
}
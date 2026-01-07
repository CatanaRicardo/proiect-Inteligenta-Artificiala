class Program{

    static void Main(){
        Console.WriteLine("=== PROIECT IA ===");
        Console.WriteLine("Sistem de inferenta predicativa cu unificare\n");
        DemonstratieNumarPar();
        DemonstratieTriunghi();
        Console.ReadKey();
    }

    static void DemonstratieNumarPar(){
        Console.WriteLine("Teorema 1: Un numar par are patratul par\n");

        KnowledgeBase kb = new KnowledgeBase();

        Console.WriteLine("Premise initiale:");
        kb.AddFact(new Predicate("Par", "n"));
        kb.AddFact(new Predicate("Patrat", "n", "n2"));
        Console.WriteLine(" - Par(n)");
        Console.WriteLine(" - Patrat(n, n2)\n");

        kb.Rules.Add(new Rule(
            new List<Predicate>
            {
                new Predicate("Par", "?X"),
                new Predicate("Patrat", "?X", "?Y")
            },
            new Predicate("Par", "?Y")
        ));

        new InferenceEngine().ForwardChaining(kb);

        kb.PrintFacts();
        Console.WriteLine("Concluzie: Patratul unui numar par este par.\n");
    }

    static void DemonstratieTriunghi(){
        Console.WriteLine("Teorema 2: Un triunghi echilateral este isoscel\n");

        KnowledgeBase kb = new KnowledgeBase();

        Console.WriteLine("Premise initiale:");
        kb.AddFact(new Predicate("Echilateral", "t"));
        Console.WriteLine(" - Echilateral(t)\n");

        kb.Rules.Add(new Rule(
            new List<Predicate>
            {
                new Predicate("Echilateral", "?T")
            },
            new Predicate("Isoscel", "?T")
        ));

        new InferenceEngine().ForwardChaining(kb);

        kb.PrintFacts();
        Console.WriteLine("Concluzie: Triunghiul echilateral este isoscel.\n");
    }
}















































































































































































































































































































































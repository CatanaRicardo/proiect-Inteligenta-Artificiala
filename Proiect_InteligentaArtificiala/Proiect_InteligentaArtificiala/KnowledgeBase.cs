class KnowledgeBase{
    public List<Predicate> Facts { get; } = new List<Predicate>();
    public List<Rule> Rules { get; } = new List<Rule>();

    public void AddFact(Predicate fact){
        if (!Facts.Any(f => f.ToString() == fact.ToString()))
            Facts.Add(fact);
    }

    public void PrintFacts(){
        Console.WriteLine("Fapte cunoscute:");
        foreach (var f in Facts)
            Console.WriteLine(" - " + f);
    }
}
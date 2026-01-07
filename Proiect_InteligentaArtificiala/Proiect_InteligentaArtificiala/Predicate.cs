class Predicate{  
    // Reprezinta un predicat logic, care poate contine variabile (?X, ?Y)
    public string Name { get; }
    public List<string> Arguments { get; }

    public Predicate(string name, params string[] args){
        Name = name;
        Arguments = args.ToList();
    }

    // Verifica daca doua predicate se pot unifica
    public bool CanUnify(Predicate other, Dictionary<string, string> substitution){
        if (Name != other.Name || Arguments.Count != other.Arguments.Count)
            return false;

        for (int i = 0; i < Arguments.Count; i++){
            string a = Arguments[i];
            string b = other.Arguments[i];

            if (IsVariable(a))
                substitution[a] = b;
            else if (IsVariable(b))
                substitution[b] = a;
            else if (a != b)
                return false;
        }

        return true;
    }

    public Predicate ApplySubstitution(Dictionary<string, string> substitution){
        var newArgs = Arguments
            .Select(a => substitution.ContainsKey(a) ? substitution[a] : a)
            .ToArray();

        return new Predicate(Name, newArgs);
    }

    private bool IsVariable(string s) => s.StartsWith("?");

    public override string ToString(){
        return $"{Name}({string.Join(", ", Arguments)})";
    }
}
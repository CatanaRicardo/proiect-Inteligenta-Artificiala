class Rule{
    public List<Predicate> Premises { get; }
    public Predicate Conclusion { get; }

    public Rule(List<Predicate> premises, Predicate conclusion){
        Premises = premises;
        Conclusion = conclusion;
    }

    public override string ToString(){
        return $"{string.Join(" si ", Premises)} => {Conclusion}";
    }
}